using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class CheckoutForm : Form
    {
        private string userFio;
        private int newOrderId;
        private int receiveCode;

        public CheckoutForm(string userFio)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            this.userFio = userFio;

            LoadPickupPoints();
            LoadClients();

            if (userFio != null && userFio.Contains("Гостевой режим") == false)
            {
                cmbFio.Text = userFio;
                cmbFio.Enabled = false;
            }

            lblSum.Text = "Сумма: " + Cart.SumTotal().ToString("0.00") + " руб.";
            lblDiscount.Text = "Скидка: " + Cart.SumDiscount().ToString("0.00") + " руб.";

            Random rnd = new Random();
            receiveCode = rnd.Next(100, 1000);
            lblCode.Text = "Код получения: " + receiveCode;
        }

        private void LoadPickupPoints()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT PickupPointID, Address FROM PickupPoint ORDER BY Address", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbPickupPoint.DataSource = dt;
            cmbPickupPoint.DisplayMember = "Address";
            cmbPickupPoint.ValueMember = "PickupPointID";
            conn.Close();
        }

        private void LoadClients()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT DISTINCT OrderClientName FROM `Order` " +
                "WHERE OrderClientName IS NOT NULL AND OrderClientName != '' " +
                "ORDER BY OrderClientName", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbFio.DataSource = dt;
            cmbFio.DisplayMember = "OrderClientName";
            conn.Close();
        }

        private void btnRefreshClients_Click(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbFio.Text.Trim() == "")
            {
                MessageBox.Show("Выберите или введите ФИО клиента.");
                return;
            }
            if (cmbPickupPoint.SelectedItem == null)
            {
                MessageBox.Show("Выберите пункт выдачи.");
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Введите контактный телефон.");
                txtPhone.Focus();
                return;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Введите адрес проживания.");
                txtAddress.Focus();
                return;
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
                conn.Open();

                MySqlCommand cmdMax = new MySqlCommand(
                    "SELECT IFNULL(MAX(OrderID), 0) + 1 FROM `Order`", conn);
                newOrderId = Convert.ToInt32(cmdMax.ExecuteScalar());

                int days = Cart.DeliveryDays();
                DateTime deliveryDate = DateTime.Now.AddDays(days);

                string sqlOrder =
                    "INSERT INTO `Order` " +
                    "(OrderID, OrderStatusID, OrderDate, OrderDeliveryDate, " +
                    " OrderPickupPointID, OrderClientName, OrderClientBirthDate, " +
                    " OrderClientPhone, OrderClientAddress, OrderCode) " +
                    "VALUES (@id, 1, NOW(), @delivery, @pickup, @fio, @birth, @phone, @address, @code)";

                MySqlCommand cmdOrder = new MySqlCommand(sqlOrder, conn);
                cmdOrder.Parameters.AddWithValue("@id", newOrderId);
                cmdOrder.Parameters.AddWithValue("@delivery", deliveryDate);
                cmdOrder.Parameters.AddWithValue("@pickup", cmbPickupPoint.SelectedValue);
                cmdOrder.Parameters.AddWithValue("@fio", cmbFio.Text.Trim());
                cmdOrder.Parameters.AddWithValue("@birth",
                    dtpBirth.Checked ? (object)dtpBirth.Value.Date : DBNull.Value);
                cmdOrder.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmdOrder.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmdOrder.Parameters.AddWithValue("@code", receiveCode);
                cmdOrder.ExecuteNonQuery();

                for (int i = 0; i < Cart.Items.Count; i++)
                {
                    CartItem item = Cart.Items[i];
                    MySqlCommand cmdItem = new MySqlCommand(
                        "INSERT INTO OrderProduct (OrderID, ProductArticleNumber, Quantity) " +
                        "VALUES (@id, @article, @qty)", conn);
                    cmdItem.Parameters.AddWithValue("@id", newOrderId);
                    cmdItem.Parameters.AddWithValue("@article", item.Article);
                    cmdItem.Parameters.AddWithValue("@qty", item.Quantity);
                    cmdItem.ExecuteNonQuery();
                }
                conn.Close();

                SaveTalon(days, deliveryDate);
                MessageBox.Show("Заказ №" + newOrderId + " оформлен.\nКод получения: " + receiveCode);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void SaveTalon(int days, DateTime deliveryDate)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Word (*.rtf)|*.rtf";
            dlg.FileName = "Талон_заказа_" + newOrderId + ".rtf";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            StreamWriter w = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
            w.WriteLine(@"{\rtf1\ansi\deff0");
            w.WriteLine(@"{\fonttbl{\f0 Comic Sans MS;}}");
            w.WriteLine(@"\f0\fs24");
            w.WriteLine(@"\b\fs32 ТАЛОН НА ПОЛУЧЕНИЕ ЗАКАЗА\b0\fs24\par\par");
            w.WriteLine(@"Дата заказа: " + DateTime.Now.ToString("dd.MM.yyyy") + @"\par");
            w.WriteLine(@"Номер заказа: " + newOrderId + @"\par");
            w.WriteLine(@"\b\fs40 Код получения: " + receiveCode + @"\b0\fs24\par\par");
            w.WriteLine(@"ФИО клиента: " + cmbFio.Text.Trim() + @"\par");
            w.WriteLine(@"Пункт выдачи: " + cmbPickupPoint.Text + @"\par");
            w.WriteLine(@"Срок доставки: " + days + @" дн.\par");
            w.WriteLine(@"Дата доставки: " + deliveryDate.ToString("dd.MM.yyyy") + @"\par\par");
            w.WriteLine(@"\b Состав заказа:\b0\par");
            w.WriteLine(@"-----------------------------------\par");

            for (int i = 0; i < Cart.Items.Count; i++)
            {
                CartItem item = Cart.Items[i];
                w.WriteLine(item.Name + @" — " + item.Quantity + @" шт × " +
                            item.Price.ToString("0.00") + @" = " +
                            item.TotalWithDiscount().ToString("0.00") + @"\par");
            }

            w.WriteLine(@"-----------------------------------\par");
            w.WriteLine(@"Сумма без скидки: " + Cart.SumNoDiscount().ToString("0.00") + @" руб.\par");
            w.WriteLine(@"Скидка: " + Cart.SumDiscount().ToString("0.00") + @" руб.\par");
            w.WriteLine(@"\b ИТОГО: " + Cart.SumTotal().ToString("0.00") + @" руб.\b0\par");
            w.WriteLine(@"}");
            w.Close();

            System.Diagnostics.Process.Start(dlg.FileName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}