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
            txtSqlPath.Text = Properties.Settings.Default.SqlPath;
        }

        private void Save()
        {
            Properties.Settings.Default.Host = txtHost.Text;
            Properties.Settings.Default.Port = (int)numPort.Value;
            Properties.Settings.Default.User = txtUser.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.Database = txtDatabase.Text;
            Properties.Settings.Default.SqlPath = txtSqlPath.Text;
            Properties.Settings.Default.Save();
        }

        private string SafeConnStr()
        {
            string pass = Properties.Settings.Default.Password;
            string hidden = pass == "" ? "" : new string('*', pass.Length);
            return "server=" + Properties.Settings.Default.Host +
                   ";port=" + Properties.Settings.Default.Port +
                   ";user=" + Properties.Settings.Default.User +
                   ";password=" + hidden +
                   ";database=" + Properties.Settings.Default.Database + ";";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if (Program.CanConnect(false) == false) return;

            if (Program.DatabaseExists() == false)
            {
                MessageBox.Show("База не найдена. Восстановите структуру.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Подключение успешно.\n\nСтрока подключения:\n" + SafeConnStr(),
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Hide();
            new LoginForm().ShowDialog();
            Close();
        }

        private void btnChooseSql_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Выберите SQL-скрипт структуры БД";
            dlg.Filter = "SQL-скрипты (*.sql)|*.sql|Все файлы (*.*)|*.*";

            if (txtSqlPath.Text != "" && File.Exists(txtSqlPath.Text))
            {
                dlg.InitialDirectory = Path.GetDirectoryName(txtSqlPath.Text);
                dlg.FileName = Path.GetFileName(txtSqlPath.Text);
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtSqlPath.Text = dlg.FileName;
                Save();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Save();

            if (txtSqlPath.Text == "" || File.Exists(txtSqlPath.Text) == false)
            {
                DialogResult answer = MessageBox.Show(
                    "SQL-файл не выбран или не найден.\n\nВыбрать файл сейчас?",
                    "Файл не выбран", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes) btnChooseSql_Click(sender, e);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "База данных будет пересоздана.\nВсе текущие данные будут удалены.\n\nПродолжить?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            string script = File.ReadAllText(txtSqlPath.Text);

            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(false));
                conn.Open();
                MySqlScript s = new MySqlScript(conn, script);
                s.Execute();
                conn.Close();

                MySqlConnection conn2 = new MySqlConnection(Program.ConnStr(true));
                conn2.Open();

                MySqlCommand cmdRoles = new MySqlCommand(
                    "INSERT IGNORE INTO Role (RoleID, RoleName) VALUES " +
                    "(1, 'Клиент'), (2, 'Менеджер'), (3, 'Администратор')", conn2);
                cmdRoles.ExecuteNonQuery();

                MySqlCommand cmdUsers = new MySqlCommand(
                    "INSERT IGNORE INTO User " +
                    "(UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserRole) VALUES " +
                    "('Админ', 'Админ', 'Админович', 'admin', 'admin', 3), " +
                    "('Петров', 'Пётр', 'Петрович', 'manager', 'manager', 2), " +
                    "('Иванов', 'Иван', 'Иванович', 'user', 'user', 1)", conn2);
                cmdUsers.ExecuteNonQuery();

                conn2.Close();

                MessageBox.Show(
                    "Структура БД восстановлена.\n\n" +
                    "Доступные учётные записи:\n" +
                    "  admin / admin — Администратор\n" +
                    "  manager / manager — Менеджер\n" +
                    "  user / user — Клиент",
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка восстановления:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}