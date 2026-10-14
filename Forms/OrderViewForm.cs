using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class OrderViewForm : Form
    {
        private int orderId;

        public OrderViewForm(int orderId)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            this.orderId = orderId;
            LoadOrder();
        }

        private void LoadOrder()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();

            string sqlOrder =
                "SELECT o.OrderID, o.OrderDate, o.OrderDeliveryDate, " +
                "       o.OrderClientName, o.OrderCode, os.StatusName, " +
                "       IFNULL(o.OrderClientBirthDate, '') AS BirthDate, " +
                "       IFNULL(o.OrderClientPhone, '')     AS Phone, " +
                "       IFNULL(o.OrderClientAddress, '')   AS Address, " +
                "       IFNULL(p.Address, '') AS PickupAddress " +
                "FROM `Order` o " +
                "JOIN OrderStatus os ON os.StatusID = o.OrderStatusID " +
                "LEFT JOIN PickupPoint p ON p.PickupPointID = o.OrderPickupPointID " +
                "WHERE o.OrderID = @id";

            MySqlCommand cmd = new MySqlCommand(sqlOrder, conn);
            cmd.Parameters.AddWithValue("@id", orderId);
            MySqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                txtFio.Text = r["OrderClientName"].ToString();
                txtBirth.Text = r["BirthDate"].ToString();
                txtPhone.Text = r["Phone"].ToString();
                txtAddress.Text = r["Address"].ToString();
                txtPickup.Text = r["PickupAddress"].ToString();

                lblOrderNum.Text = "Номер заказа: " + r["OrderID"].ToString();
                lblOrderDate.Text = "Дата заказа: " +
                    Convert.ToDateTime(r["OrderDate"]).ToString("dd.MM.yyyy");
                lblDeliveryDate.Text = "Дата выполнения: " +
                    Convert.ToDateTime(r["OrderDeliveryDate"]).ToString("dd.MM.yyyy");
                lblStatus.Text = r["StatusName"].ToString();
            }
            r.Close();

            string sqlItems =
                "SELECT pr.ProductArticleNumber, pr.ProductName, op.Quantity, " +
                "       pr.ProductCost, pr.ProductCurrentDiscount " +
                "FROM OrderProduct op " +
                "JOIN Product pr ON pr.ProductArticleNumber = op.ProductArticleNumber " +
                "WHERE op.OrderID = @id";

            MySqlCommand cmdItems = new MySqlCommand(sqlItems, conn);
            cmdItems.Parameters.AddWithValue("@id", orderId);
            MySqlDataAdapter da = new MySqlDataAdapter(cmdItems);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvCart.Rows.Clear();

            decimal sumNoDisc = 0, sumDisc = 0, discPercent = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string article = row["ProductArticleNumber"].ToString();
                string name = row["ProductName"].ToString();
                int qty = Convert.ToInt32(row["Quantity"]);
                decimal cost = Convert.ToDecimal(row["ProductCost"]);
                int discount = Convert.ToInt32(row["ProductCurrentDiscount"]);

                decimal lineNoDisc = cost * qty;
                decimal lineDisc = lineNoDisc * discount / 100;

                sumNoDisc += lineNoDisc;
                sumDisc += lineDisc;

                dgvCart.Rows.Add(article, name, qty, cost.ToString("0.00"));
            }

            if (sumNoDisc > 0) discPercent = sumDisc * 100 / sumNoDisc;
            decimal sumTotal = sumNoDisc - sumDisc;

            lblSumNoDisc.Text = "Сумма покупки: " + sumNoDisc.ToString("0") + " руб.";
            lblDiscPercent.Text = "Скидка: " + discPercent.ToString("0") + " %";
            lblDiscSum.Text = "Скидка: " + sumDisc.ToString("0") + " руб.";
            lblSumTotal.Text = "Сумма с учетом скидки: " + sumTotal.ToString("0") + " руб.";

            string status = lblStatus.Text;
            btnCheck.Enabled = (status == "Завершен" || status == "Выполнен");

            conn.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оформление чека будет реализовано позже.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}