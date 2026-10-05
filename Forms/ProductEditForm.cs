using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class ProductEditForm : Form
    {
        private string article;
        private string selectedPhotoName = "";

        public ProductEditForm(string article)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            this.article = article;

            FillCombo(cmbCategory, "SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName", "CategoryName", "CategoryID");
            FillCombo(cmbManufacturer, "SELECT ManufacturerID, ManufacturerName FROM Manufacturer ORDER BY ManufacturerName", "ManufacturerName", "ManufacturerID");
            FillCombo(cmbSupplier, "SELECT SupplierID, SupplierName FROM Supplier ORDER BY SupplierName", "SupplierName", "SupplierID");
            FillCombo(cmbUnit, "SELECT UnitID, UnitName FROM Unit ORDER BY UnitName", "UnitName", "UnitID");
            FillCombo(cmbStatus, "SELECT ProductStatusID, ProductStatusName FROM ProductStatus ORDER BY ProductStatusName", "ProductStatusName", "ProductStatusID");

            if (article == null)
            {
                Text = "Добавление товара";
                picPhoto.Image = Properties.Resources.picture;
            }
            else
            {
                Text = "Редактирование товара";
                txtArticle.ReadOnly = true;
                LoadProduct();
            }
        }

        private void FillCombo(ComboBox cmb, string sql, string display, string value)
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb.DataSource = dt;
            cmb.DisplayMember = display;
            cmb.ValueMember = value;
            conn.Close();
        }

        private void LoadProduct()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Product WHERE ProductArticleNumber=@a", conn);
            cmd.Parameters.AddWithValue("@a", article);
            MySqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                txtArticle.Text = r["ProductArticleNumber"].ToString();
                txtName.Text = r["ProductName"].ToString();
                txtDescription.Text = r["ProductDescription"].ToString();
                numCost.Value = Convert.ToDecimal(r["ProductCost"]);
                numMaxDiscount.Value = Convert.ToDecimal(r["ProductMaxDiscount"]);
                numDiscount.Value = Convert.ToDecimal(r["ProductCurrentDiscount"]);
                numQuantity.Value = Convert.ToDecimal(r["ProductQuantityInStock"]);

                cmbCategory.SelectedValue = Convert.ToInt32(r["CategoryID"]);
                cmbManufacturer.SelectedValue = Convert.ToInt32(r["ManufacturerID"]);
                cmbSupplier.SelectedValue = Convert.ToInt32(r["SupplierID"]);
                cmbUnit.SelectedValue = Convert.ToInt32(r["UnitID"]);
                cmbStatus.SelectedValue = Convert.ToInt32(r["ProductStatusID"]);

                string photo = "";
                if (r["ProductPhoto"] != DBNull.Value) photo = r["ProductPhoto"].ToString();
                selectedPhotoName = photo;

                if (photo == "") picPhoto.Image = Properties.Resources.picture;
                else
                {
                    string fullPath = AppDomain.CurrentDomain.BaseDirectory + "Photos\\" + photo;
                    if (File.Exists(fullPath))
                    {
                        Image img = Image.FromFile(fullPath);
                        picPhoto.Image = new Bitmap(img, 150, 150);
                    }
                    else picPhoto.Image = Properties.Resources.picture;
                }
            }
            r.Close(); conn.Close();
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string ext = Path.GetExtension(dlg.FileName);
            string newName = txtArticle.Text.Trim() + ext;
            string photosDir = AppDomain.CurrentDomain.BaseDirectory + "Photos\\";
            if (Directory.Exists(photosDir) == false) Directory.CreateDirectory(photosDir);
            string destPath = photosDir + newName;

            try
            {
                File.Copy(dlg.FileName, destPath, true);
                selectedPhotoName = newName;
                Image img = Image.FromFile(destPath);
                picPhoto.Image = new Bitmap(img, 150, 150);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            selectedPhotoName = "";
            picPhoto.Image = Properties.Resources.picture;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtArticle.Text.Trim() == "" || txtName.Text.Trim() == "")
            { MessageBox.Show("Артикул и наименование обязательны."); return; }

            if (numDiscount.Value > numMaxDiscount.Value)
            { MessageBox.Show("Скидка не может быть больше максимальной."); return; }

            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();

            if (article == null)
            {
                MySqlCommand check = new MySqlCommand(
                    "SELECT COUNT(*) FROM Product WHERE ProductArticleNumber=@a", conn);
                check.Parameters.AddWithValue("@a", txtArticle.Text);
                long n = Convert.ToInt64(check.ExecuteScalar());
                if (n > 0) { MessageBox.Show("Такой артикул уже есть."); conn.Close(); return; }
            }

            string sql;
            if (article == null)
                sql = "INSERT INTO Product (ProductArticleNumber, ProductName, ProductDescription, CategoryID, " +
                      "ProductPhoto, ManufacturerID, SupplierID, UnitID, ProductCost, " +
                      "ProductMaxDiscount, ProductCurrentDiscount, ProductQuantityInStock, ProductStatusID) " +
                      "VALUES (@a, @n, @d, @c, @photo, @m, @s, @u, @cost, @maxd, @curd, @q, @st)";
            else
                sql = "UPDATE Product SET ProductName=@n, ProductDescription=@d, CategoryID=@c, " +
                      "ProductPhoto=@photo, ManufacturerID=@m, SupplierID=@s, UnitID=@u, " +
                      "ProductCost=@cost, ProductMaxDiscount=@maxd, ProductCurrentDiscount=@curd, " +
                      "ProductQuantityInStock=@q, ProductStatusID=@st WHERE ProductArticleNumber=@a";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@a", txtArticle.Text);
            cmd.Parameters.AddWithValue("@n", txtName.Text);
            cmd.Parameters.AddWithValue("@d", txtDescription.Text);
            cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@photo", selectedPhotoName);
            cmd.Parameters.AddWithValue("@m", cmbManufacturer.SelectedValue);
            cmd.Parameters.AddWithValue("@s", cmbSupplier.SelectedValue);
            cmd.Parameters.AddWithValue("@u", cmbUnit.SelectedValue);
            cmd.Parameters.AddWithValue("@cost", numCost.Value);
            cmd.Parameters.AddWithValue("@maxd", numMaxDiscount.Value);
            cmd.Parameters.AddWithValue("@curd", numDiscount.Value);
            cmd.Parameters.AddWithValue("@q", numQuantity.Value);
            cmd.Parameters.AddWithValue("@st", cmbStatus.SelectedValue);
            cmd.ExecuteNonQuery();
            conn.Close();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}