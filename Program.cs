using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using trade_app.Forms;

namespace trade_app
{
    internal static class Program
    {
        public const int InactivitySeconds = 30;
        public const int BlockSeconds = 10;
        public const int PageSize = 20;

        public static string ConnStr(bool withDb)
        {
            string host = Properties.Settings.Default.Host;
            string port = Properties.Settings.Default.Port.ToString();
            string user = Properties.Settings.Default.User;
            string password = Properties.Settings.Default.Password;
            string db = Properties.Settings.Default.Database;

            string result = "server=" + host + ";port=" + port + ";user=" + user +
                            ";password=" + password + ";charset=utf8mb4;";
            if (withDb == true) result = result + "database=" + db + ";";
            return result;
        }

        public static bool CanConnect(bool withDb)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnStr(withDb));
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения:\n" + ex.Message);
                return false;
            }
        }

        public static bool DatabaseExists()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnStr(false));
                conn.Open();
                string sql = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA " +
                             "WHERE SCHEMA_NAME='" + Properties.Settings.Default.Database + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object r = cmd.ExecuteScalar();
                conn.Close();
                return r != null;
            }
            catch { return false; }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (CanConnect(false) == false)
            {
                Application.Run(new SettingsForm());
                return;
            }

            if (DatabaseExists() == false)
            {
                MessageBox.Show("База данных не найдена. Восстановите структуру.");
                Application.Run(new SettingsForm());
                return;
            }

            MessageBox.Show("Подключение успешно.");
            Application.Run(new LoginForm());
        }
    }
}