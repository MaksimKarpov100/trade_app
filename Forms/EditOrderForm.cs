using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class EditOrderForm : Form
    {
        private int orderId;

        public EditOrderForm(int orderId, int statusId, DateTime deliveryDate)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            this.orderId = orderId;

            lblOrderId.Text = "Заказ №" + orderId;

            LoadStatuses();
            cmbStatus.SelectedValue = statusId;
            dtpDelivery.Value = deliveryDate;
        }

        private void LoadStatuses()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT StatusID, StatusName FROM OrderStatus ORDER BY StatusID", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbStatus.DataSource = dt;
            cmbStatus.DisplayMember = "StatusName";
            cmbStatus.ValueMember = "StatusID";
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE `Order` SET OrderStatusID=@s, OrderDeliveryDate=@d WHERE OrderID=@id", conn);
                cmd.Parameters.AddWithValue("@s", cmbStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@d", dtpDelivery.Value);
                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Заказ обновлён.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}