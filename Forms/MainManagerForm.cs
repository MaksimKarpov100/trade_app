using System;
using System.Windows.Forms;

namespace trade_app.Forms
{
    public partial class MainManagerForm : Form
    {
        private bool logout = false;

        public MainManagerForm(string fio)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            lblUser.Text = fio;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm f = new OrdersForm(lblUser.Text);
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e) { logout = true; Close(); }

        private void MainManagerForm_FormClosing(object sender, FormClosingEventArgs e)
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