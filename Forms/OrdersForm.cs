using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class OrdersForm : Form
    {
        private bool logout = false;
        private DataTable all;
        private int page = 1;
        private const int PageSize = 20;

        public OrdersForm(string fio)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            lblUser.Text = fio;
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Создаём колонки, если их нет
                CreateColumnsIfMissing();

                LoadOrders();

                // Диапазон дат
                if (all != null && all.Rows.Count > 0)
                {
                    DateTime minDate = DateTime.MaxValue;
                    DateTime maxDate = DateTime.MinValue;

                    for (int i = 0; i < all.Rows.Count; i++)
                    {
                        DateTime d = Convert.ToDateTime(all.Rows[i]["OrderDate"]);
                        if (d < minDate) minDate = d;
                        if (d > maxDate) maxDate = d;
                    }

                    dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
                    dtpTo.ValueChanged -= dtpTo_ValueChanged;

                    dtpFrom.Value = minDate;
                    dtpTo.Value = maxDate;

                    dtpFrom.ValueChanged += dtpFrom_ValueChanged;
                    dtpTo.ValueChanged += dtpTo_ValueChanged;
                }

                ShowPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка открытия формы заказов:\n\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        // Программно создаём колонки
        private void CreateColumnsIfMissing()
        {
            AddCol("colOrderID", "№ заказа", "OrderID", 60F, false);
            AddCol("colClient", "ФИО клиента", "ClientName", 170F, false);
            AddCol("colDate", "Дата заказа", "OrderDate", 90F, false);
            AddCol("colDelivery", "Дата доставки", "DeliveryDate", 90F, false);
            AddCol("colStatus", "Статус", "StatusName", 80F, false);
            AddCol("colSostav", "Состав заказа", "Sostav", 260F, false);
            AddCol("colSum", "Сумма заказа", "SumNoDisc", 100F, false);
            AddCol("colDisc", "Скидка", "DiscountSum", 80F, false);
            AddCol("colStatusID", "", "StatusID", 0F, true);
            AddCol("colMinStock", "", "MinStock", 0F, true);
        }

        private void AddCol(string name, string header, string prop, float weight, bool hidden)
        {
            if (dgvOrders.Columns.Contains(name)) return;

            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.Name = name;
            c.HeaderText = header;
            c.DataPropertyName = prop;
            c.FillWeight = weight == 0F ? 50F : weight;
            if (hidden) c.Visible = false;
            dgvOrders.Columns.Add(c);
        }

        private void LoadOrders()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();

            string sql =
                "SELECT o.OrderID AS OrderID, " +
                "       IFNULL(o.OrderClientName, '') AS ClientName, " +
                "       o.OrderDate AS OrderDate, " +
                "       o.OrderDeliveryDate AS DeliveryDate, " +
                "       os.StatusName AS StatusName, " +
                "       o.OrderStatusID AS StatusID, " +
                "       o.OrderCode AS OrderCode, " +
                "       (SELECT GROUP_CONCAT(CONCAT(pr.ProductName, ' x', op.Quantity) SEPARATOR ', ') " +
                "        FROM OrderProduct op " +
                "        JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "        WHERE op.OrderID = o.OrderID) AS Sostav, " +
                "       (SELECT IFNULL(SUM(pr.ProductCost * op.Quantity), 0) " +
                "        FROM OrderProduct op " +
                "        JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "        WHERE op.OrderID = o.OrderID) AS SumNoDisc, " +
                "       (SELECT IFNULL(SUM(pr.ProductCost * op.Quantity * pr.ProductCurrentDiscount / 100), 0) " +
                "        FROM OrderProduct op " +
                "        JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "        WHERE op.OrderID = o.OrderID) AS DiscountSum, " +
                "       (SELECT MIN(pr.ProductQuantityInStock) " +
                "        FROM OrderProduct op " +
                "        JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "        WHERE op.OrderID = o.OrderID) AS MinStock " +
                "FROM `Order` o " +
                "JOIN OrderStatus os ON os.StatusID = o.OrderStatusID " +
                "ORDER BY o.OrderID DESC";

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
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1);

            bool anyStatus = chkAccepted.Checked || chkCompleted.Checked || chkCanceled.Checked;

            for (int i = 0; i < all.Rows.Count; i++)
            {
                DataRow r = all.Rows[i];

                string oid = r["OrderID"].ToString();
                bool searchOk = search == "" || oid.Contains(search);

                DateTime od = Convert.ToDateTime(r["OrderDate"]);
                bool dateOk = od >= from && od < to;

                int statusId = Convert.ToInt32(r["StatusID"]);
                bool statusOk = true;
                if (anyStatus)
                {
                    statusOk = (chkAccepted.Checked && statusId == 1) ||
                               (chkCompleted.Checked && statusId == 2) ||
                               (chkCanceled.Checked && statusId == 3);
                }

                if (searchOk && dateOk && statusOk)
                    filtered.ImportRow(r);
            }

            string sort = "";
            if (cmbSort.SelectedItem != null) sort = cmbSort.SelectedItem.ToString();
            if (sort == "Сумма заказа ↑") filtered.DefaultView.Sort = "SumNoDisc ASC";
            else if (sort == "Сумма заказа ↓") filtered.DefaultView.Sort = "SumNoDisc DESC";
            else if (sort == "Дата заказа ↑") filtered.DefaultView.Sort = "OrderDate ASC";
            else if (sort == "Дата заказа ↓") filtered.DefaultView.Sort = "OrderDate DESC";

            DataTable sorted = filtered.DefaultView.ToTable();

            int total = sorted.Rows.Count;
            int pages = (total + PageSize - 1) / PageSize;
            if (pages < 1) pages = 1;
            if (page > pages) page = pages;
            int start = (page - 1) * PageSize;
            int end = Math.Min(start + PageSize, total);

            DataTable shown = sorted.Clone();
            for (int i = start; i < end; i++) shown.ImportRow(sorted.Rows[i]);

            dgvOrders.DataSource = shown;

            // Цвета + сумма оплаченных — через DataRowView
            decimal sumPaid = 0;
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                DataGridViewRow row = dgvOrders.Rows[i];
                DataRowView drv = (DataRowView)row.DataBoundItem;
                if (drv == null) continue;
                DataRow r = drv.Row;

                int minStock = 0;
                if (r["MinStock"] != DBNull.Value)
                    minStock = Convert.ToInt32(r["MinStock"]);

                if (minStock > 3)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(32, 178, 170);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(32, 178, 170);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 140, 0);
                }

                int st = Convert.ToInt32(r["StatusID"]);
                if (st == 2)
                    sumPaid += Convert.ToDecimal(r["SumNoDisc"]);
            }

            lblRecords.Text = "Кол-во записей: " + total;
            lblPage.Text = page + " из " + pages;
            lblSumPaid.Text = "Сумма оплаченных заказов: " + sumPaid.ToString("0") + " руб.";
        }

        // ============ СОБЫТИЯ ============
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            page = 1;
            ShowPage();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            page = 1;
            ShowPage();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            page = 1;
            ShowPage();
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            page = 1;
            ShowPage();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPage();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            chkAccepted.Checked = false;
            chkCompleted.Checked = false;
            chkCanceled.Checked = false;
            cmbSort.SelectedIndex = 0;

            if (all != null && all.Rows.Count > 0)
            {
                DateTime minDate = DateTime.MaxValue;
                DateTime maxDate = DateTime.MinValue;

                for (int i = 0; i < all.Rows.Count; i++)
                {
                    DateTime d = Convert.ToDateTime(all.Rows[i]["OrderDate"]);
                    if (d < minDate) minDate = d;
                    if (d > maxDate) maxDate = d;
                }

                dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
                dtpTo.ValueChanged -= dtpTo_ValueChanged;

                dtpFrom.Value = minDate;
                dtpTo.Value = maxDate;

                dtpFrom.ValueChanged += dtpFrom_ValueChanged;
                dtpTo.ValueChanged += dtpTo_ValueChanged;
            }

            page = 1;
            ShowPage();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                ShowPage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            ShowPage();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colOrderID"].Value);
            OrderViewForm f = new OrderViewForm(orderId);
            f.ShowDialog();

            LoadOrders();
            ShowPage();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Отчёт Excel будет реализован позже.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            logout = true;
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout = true;
            Close();
        }

        private void OrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logout) return;
            if (e.CloseReason != CloseReason.UserClosing) return;

            DialogResult answer = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                e.Cancel = true;
            else
                Application.Exit();
        }
    }
}