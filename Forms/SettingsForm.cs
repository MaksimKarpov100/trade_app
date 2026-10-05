using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            txtHost.Text = Properties.Settings.Default.Host;
            numPort.Value = Properties.Settings.Default.Port;
            txtUser.Text = Properties.Settings.Default.User;
            txtPassword.Text = Properties.Settings.Default.Password;
            txtDatabase.Text = Properties.Settings.Default.Database;
        }

        private void Save()
        {
            Properties.Settings.Default.Host = txtHost.Text;
            Properties.Settings.Default.Port = (int)numPort.Value;
            Properties.Settings.Default.User = txtUser.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.Database = txtDatabase.Text;
            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if (Program.CanConnect(false) == false) return;
            if (Program.DatabaseExists() == false)
            {
                MessageBox.Show("База не найдена. Восстановите структуру.");
                return;
            }
            MessageBox.Show("Подключение успешно.");
            Hide();
            new LoginForm().ShowDialog();
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Save();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Resources\\trade.sql";
            if (File.Exists(path) == false) { MessageBox.Show("trade.sql не найден: " + path); return; }
            string script = File.ReadAllText(path);

            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(false));
                conn.Open();
                MySqlScript s = new MySqlScript(conn, script);
                s.Execute();
                conn.Close();

                AddRoles();
                AddTestUsers();

                MessageBox.Show("Структура БД восстановлена.\n\n" +
                    "admin / admin (Администратор)\n" +
                    "manager / manager (Менеджер)\n" +
                    "user / user (Клиент)");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void AddRoles()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO Role (RoleID, RoleName) VALUES " +
                "(1, 'Клиент'), (2, 'Менеджер'), (3, 'Администратор')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void AddTestUsers()
        {
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO User " +
                "(UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserRole) VALUES " +
                "('Админ', 'Админ', 'Админович', 'admin', 'admin', 3), " +
                "('Петров', 'Пётр', 'Петрович', 'manager', 'manager', 2), " +
                "('Иванов', 'Иван', 'Иванович', 'user', 'user', 1)", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}