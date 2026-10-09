using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class MainAdminForm : Form
    {
        private bool logout = false;
        private DataTable all;
        private int page = 1;

        public MainAdminForm(string fio)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            lblUser.Text = fio;
        }

        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            if (dgvProducts.Columns.Contains("colPhotoRaw") == false)
            {
                DataGridViewTextBoxColumn colRaw = new DataGridViewTextBoxColumn();
                colRaw.Name = "colPhotoRaw";
                colRaw.HeaderText = "";
                colRaw.DataPropertyName = "ProductPhoto";
                colRaw.Visible = false;
                colRaw.ReadOnly = true;
                dgvProducts.Columns.Add(colRaw);
            }

            LoadCategories();
            LoadManufacturers();
            LoadData();
            ShowPage();
        }

        private void LoadCategories()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow empty = dt.NewRow();
            empty["CategoryID"] = -1;
            empty["CategoryName"] = "Все категории";
            dt.Rows.InsertAt(empty, 0);

            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            conn.Close();
        }

        private void LoadManufacturers()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT ManufacturerID, ManufacturerName FROM Manufacturer ORDER BY ManufacturerName", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow empty = dt.NewRow();
            empty["ManufacturerID"] = -1;
            empty["ManufacturerName"] = "Все производители";
            dt.Rows.InsertAt(empty, 0);

            cmbManufacturer.DataSource = dt;
            cmbManufacturer.DisplayMember = "ManufacturerName";
            cmbManufacturer.ValueMember = "ManufacturerID";
            conn.Close();
        }

        private void LoadData()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            string sql = "SELECT ProductArticleNumber, ProductName, ProductDescription, " +
                         "ProductCost, ProductCurrentDiscount, ProductQuantityInStock, ProductPhoto, " +
                         "CategoryID, ManufacturerID " +
                         "FROM Product ORDER BY ProductName";
            MySqlDataAdapter a = new MySqlDataAdapter(sql, conn);
            all = new DataTable();
            a.Fill(all);
            conn.Close();
        }

        private void ShowPage()
        {
            if (all == null) return;

            DataTable filtered = all.Clone();
            string search = txtSearch.Text.Trim().ToLower();

            int categoryId = -1;
            if (cmbCategory.SelectedValue != null)
                categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            int manufacturerId = -1;
            if (cmbManufacturer.SelectedValue != null)
                manufacturerId = Convert.ToInt32(cmbManufacturer.SelectedValue);

            string filter = "Все диапазоны";
            if (cmbFilter.SelectedItem != null) filter = cmbFilter.SelectedItem.ToString();

            for (int i = 0; i < all.Rows.Count; i++)
            {
                DataRow r = all.Rows[i];
                string name = r["ProductName"].ToString().ToLower();
                decimal d = Convert.ToDecimal(r["ProductCurrentDiscount"]);
                int catId = Convert.ToInt32(r["CategoryID"]);
                int manId = Convert.ToInt32(r["ManufacturerID"]);

                bool nameOk = search == "" || name.Contains(search);
                bool discOk = filter == "Все диапазоны" ||
                              (filter == "0-9,99%" && d < 10) ||
                              (filter == "10-14,99%" && d >= 10 && d < 15) ||
                              (filter == "15% и более" && d >= 15);
                bool catOk = categoryId == -1 || catId == categoryId;
                bool manOk = manufacturerId == -1 || manId == manufacturerId;

                if (nameOk && discOk && catOk && manOk)
                    filtered.ImportRow(r);
            }

            string sort = "";
            if (cmbSort.SelectedItem != null) sort = cmbSort.SelectedItem.ToString();
            if (sort == "Цена ↑") filtered.DefaultView.Sort = "ProductCost ASC";
            else if (sort == "Цена ↓") filtered.DefaultView.Sort = "ProductCost DESC";

            DataTable sorted = filtered.DefaultView.ToTable();
            int total = sorted.Rows.Count;
            int pages = (total + Program.PageSize - 1) / Program.PageSize;
            if (pages < 1) pages = 1;
            if (page > pages) page = pages;

            int start = (page - 1) * Program.PageSize;
            int end = Math.Min(start + Program.PageSize, total);

            DataTable shown = sorted.Clone();
            for (int i = start; i < end; i++) shown.ImportRow(sorted.Rows[i]);

            dgvProducts.DataSource = shown;

            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                DataGridViewRow row = dgvProducts.Rows[i];
                string photoName = "";
                if (dgvProducts.Columns.Contains("colPhotoRaw") &&
                    row.Cells["colPhotoRaw"].Value != null)
                    photoName = row.Cells["colPhotoRaw"].Value.ToString();

                if (dgvProducts.Columns.Contains("colPhoto"))
                {
                    if (photoName == "")
                        row.Cells["colPhoto"].Value = Properties.Resources.picture;
                    else
                    {
                        string fullPath = AppDomain.CurrentDomain.BaseDirectory + "Photos\\" + photoName;
                        if (File.Exists(fullPath))
                        {
                            Image img = Image.FromFile(fullPath);
                            row.Cells["colPhoto"].Value = new Bitmap(img, 50, 50);
                        }
                        else row.Cells["colPhoto"].Value = Properties.Resources.picture;
                    }
                }
            }

            lblCount.Text = "Показано " + (end - start) + " из " + total;
            lblPage.Text = "Страница " + page + " из " + pages;
            btnPrev.Enabled = page > 1;
            btnNext.Enabled = page < pages;

            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                DataGridViewRow row = dgvProducts.Rows[i];
                if (dgvProducts.Columns.Contains("colDiscount"))
                {
                    decimal d = Convert.ToDecimal(row.Cells["colDiscount"].Value);
                    if (d > 15)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(127, 255, 0);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(127, 255, 0);
                    }
                    if (d > 0 && dgvProducts.Columns.Contains("colCost"))
                        row.Cells["colCost"].Style.BackColor = Color.FromArgb(102, 255, 102);
                }
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProducts.Columns.Contains("colEdit") &&
                dgvProducts.Columns[e.ColumnIndex].Name == "colEdit")
            {
                string article = dgvProducts.Rows[e.RowIndex].Cells["colArticle"].Value.ToString();
                ProductEditForm f = new ProductEditForm(article);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    ShowPage();
                }
            }
        }

        private void dgvProducts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int i = dgvProducts.HitTest(e.X, e.Y).RowIndex;
                if (i >= 0) dgvProducts.Rows[i].Selected = true;

                ContextMenuStrip m = new ContextMenuStrip();
                m.Items.Add("Добавить", null, Add_Click);
                m.Items.Add("Редактировать", null, Edit_Click);
                m.Show(dgvProducts, e.Location);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ProductEditForm f = new ProductEditForm(null);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                ShowPage();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;
            string article = dgvProducts.SelectedRows[0].Cells["colArticle"].Value.ToString();
            ProductEditForm f = new ProductEditForm(article);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                ShowPage();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { page = 1; ShowPage(); }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { page = 1; ShowPage(); }
        private void cmbManufacturer_SelectedIndexChanged(object sender, EventArgs e) { page = 1; ShowPage(); }
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) { ShowPage(); }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) { page = 1; ShowPage(); }
        private void btnPrev_Click(object sender, EventArgs e) { if (page > 1) { page--; ShowPage(); } }
        private void btnNext_Click(object sender, EventArgs e) { page++; ShowPage(); }
        private void btnImport_Click(object sender, EventArgs e) { new ImportForm().ShowDialog(); }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm f = new OrdersForm(lblUser.Text);
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e) { logout = true; Close(); }

        private void MainAdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout) return;
            if (e.CloseReason != CloseReason.UserClosing) return;
            DialogResult answer = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) e.Cancel = true;
            else Application.Exit();
        }
    }
}