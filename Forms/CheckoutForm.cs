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

            if (userFio != null && userFio.Contains("Гостевой режим") == false)
            {
                txtFio.Text = userFio;
                txtFio.ReadOnly = true;
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtFio.Text.Trim() == "") { MessageBox.Show("Введите ФИО клиента."); return; }
            if (cmbPickupPoint.SelectedItem == null) { MessageBox.Show("Выберите пункт выдачи."); return; }

            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
                conn.Open();

                MySqlCommand cmdMax = new MySqlCommand(
                    "SELECT IFNULL(MAX(OrderID), 0) + 1 FROM `Order`", conn);
                newOrderId = Convert.ToInt32(cmdMax.ExecuteScalar());

                int days = Cart.DeliveryDays();
                DateTime deliveryDate = DateTime.Now.AddDays(days);

                string sqlOrder = "INSERT INTO `Order` " +
                    "(OrderID, OrderStatusID, OrderDate, OrderDeliveryDate, OrderPickupPointID, OrderClientName, OrderCode) " +
                    "VALUES (@id, 1, NOW(), @delivery, @pickup, @fio, @code)";
                MySqlCommand cmdOrder = new MySqlCommand(sqlOrder, conn);
                cmdOrder.Parameters.AddWithValue("@id", newOrderId);
                cmdOrder.Parameters.AddWithValue("@delivery", deliveryDate);
                cmdOrder.Parameters.AddWithValue("@pickup", cmbPickupPoint.SelectedValue);
                cmdOrder.Parameters.AddWithValue("@fio", txtFio.Text.Trim());
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
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void SaveTalon(int days, DateTime deliveryDate)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Текстовый файл (*.txt)|*.txt";
            dlg.FileName = "Талон_заказа_" + newOrderId + ".txt";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            StreamWriter w = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);
            w.WriteLine("════════════════════════════════════════");
            w.WriteLine("        ТАЛОН НА ПОЛУЧЕНИЕ ЗАКАЗА");
            w.WriteLine("════════════════════════════════════════");
            w.WriteLine();
            w.WriteLine("Дата заказа:    " + DateTime.Now.ToString("dd.MM.yyyy"));
            w.WriteLine("Номер заказа:   " + newOrderId);
            w.WriteLine();
            w.WriteLine("       КОД ПОЛУЧЕНИЯ:  " + receiveCode);
            w.WriteLine();
            w.WriteLine("ФИО клиента:    " + txtFio.Text.Trim());
            w.WriteLine("Пункт выдачи:   " + cmbPickupPoint.Text);
            w.WriteLine("Срок доставки:  " + days + " дн.");
            w.WriteLine("Дата доставки:  " + deliveryDate.ToString("dd.MM.yyyy"));
            w.WriteLine();
            w.WriteLine("────────────────────────────────────────");
            w.WriteLine("                СОСТАВ ЗАКАЗА");
            w.WriteLine("────────────────────────────────────────");
            w.WriteLine();

            for (int i = 0; i < Cart.Items.Count; i++)
            {
                CartItem item = Cart.Items[i];
                w.WriteLine(item.Name + "  —  " + item.Quantity + " шт × " +
                            item.Price.ToString("0.00") + " = " +
                            item.TotalWithDiscount().ToString("0.00"));
            }

            w.WriteLine();
            w.WriteLine("────────────────────────────────────────");
            w.WriteLine("Сумма без скидки:  " + Cart.SumNoDiscount().ToString("0.00") + " руб.");
            w.WriteLine("Скидка:            " + Cart.SumDiscount().ToString("0.00") + " руб.");
            w.WriteLine("ИТОГО:             " + Cart.SumTotal().ToString("0.00") + " руб.");
            w.WriteLine("════════════════════════════════════════");
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