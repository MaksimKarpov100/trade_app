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

        public OrdersForm(string fio)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            lblUser.Text = fio;
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
            ShowPage();
        }

        private void LoadOrders()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();

            string sql =
                "SELECT o.OrderID, o.OrderDate, o.OrderDeliveryDate, o.OrderClientName, " +
                "       os.StatusName AS StatusName, o.OrderStatusID, o.OrderCode, " +
                "       IFNULL(p.Address, '') AS PickupAddress, " +
                "       (SELECT GROUP_CONCAT(CONCAT(pr.ProductName, ' x', op.Quantity) SEPARATOR ', ') " +
                "        FROM OrderProduct op " +
                "        JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "        WHERE op.OrderID = o.OrderID) AS Sostav, " +
                "       (SELECT IFNULL(SUM(pr.ProductCost * op.Quantity), 0) " +
                "        FROM OrderProduct op " +
                "        JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "        WHERE op.OrderID = o.OrderID) AS SumNoDiscount, " +
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
                "LEFT JOIN PickupPoint p ON p.PickupPointID = o.OrderPickupPointID " +
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
            string filter = "Все диапазоны";
            if (cmbFilter.SelectedItem != null)
            {
                filter = cmbFilter.SelectedItem.ToString();
            }

            for (int i = 0; i < all.Rows.Count; i++)
            {
                DataRow r = all.Rows[i];
                decimal sumNoDisc = Convert.ToDecimal(r["SumNoDiscount"]);
                decimal disc = Convert.ToDecimal(r["DiscountSum"]);
                decimal percent = 0;
                if (sumNoDisc > 0)
                {
                    percent = disc * 100 / sumNoDisc;
                }

                bool discOk = filter == "Все диапазоны" ||
                              (filter == "0-10%" && percent >= 0 && percent <= 10) ||
                              (filter == "11-14%" && percent >= 11 && percent <= 14) ||
                              (filter == "15% и более" && percent >= 15);

                if (discOk)
                {
                    filtered.ImportRow(r);
                }
            }

            string sort = "";
            if (cmbSort.SelectedItem != null)
            {
                sort = cmbSort.SelectedItem.ToString();
            }
            if (sort == "Стоимость ↑")
            {
                filtered.DefaultView.Sort = "SumNoDiscount ASC";
            }
            else if (sort == "Стоимость ↓")
            {
                filtered.DefaultView.Sort = "SumNoDiscount DESC";
            }

            DataTable sorted = filtered.DefaultView.ToTable();
            dgvOrders.DataSource = sorted;

            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                DataGridViewRow row = dgvOrders.Rows[i];
                int minStock = 0;
                if (row.Cells["colMinStock"].Value != DBNull.Value)
                {
                    minStock = Convert.ToInt32(row.Cells["colMinStock"].Value);
                }

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
            }

            lblCount.Text = "Показано " + dgvOrders.Rows.Count + " из " + all.Rows.Count;
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPage();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPage();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            ShowPage();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["colOrderID"].Value);
            int statusId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["colStatusID"].Value);
            DateTime deliveryDate = Convert.ToDateTime(dgvOrders.Rows[e.RowIndex].Cells["colDelivery"].Value);

            EditOrderForm f = new EditOrderForm(orderId, statusId, deliveryDate);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
                ShowPage();
            }
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

            DialogResult answer = MessageBox.Show(
                "Вы точно хотите выйти?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}