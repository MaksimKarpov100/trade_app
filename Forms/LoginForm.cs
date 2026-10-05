using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class LoginForm : Form
    {
        private Captcha captcha = new Captcha();
        private int fails = 0;
        private bool blocked = false;

        public LoginForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;

            // Подсказки в полях
            txtLogin.Text = "";
            txtPassword.Text = "";

            // Первый фокус — на логин
            txtLogin.Focus();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "🙈";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "👁";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            captcha.Generate();
            captcha.Show(lblCaptcha);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            Hide();
            new MainClientForm(null).ShowDialog();
            Show();
            txtLogin.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (blocked) return;

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (login == "")
            {
                MessageBox.Show("Введите логин.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (password == "")
            {
                MessageBox.Show("Введите пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Проверка CAPTCHA (со 2-й попытки)
            if (fails >= 1)
            {
                if (txtCaptcha.Text.Trim().ToUpper() != captcha.Code.ToUpper())
                {
                    MessageBox.Show("Неверная капча.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    captcha.Generate();
                    captcha.Show(lblCaptcha);
                    txtCaptcha.Clear();
                    txtCaptcha.Focus();

                    blocked = true;
                    btnLogin.Enabled = false;
                    Timer t = new Timer();
                    t.Interval = Program.BlockSeconds * 1000;
                    t.Tick += delegate
                    {
                        t.Stop();
                        blocked = false;
                        btnLogin.Enabled = true;
                    };
                    t.Start();
                    return;
                }
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT u.UserSurname, u.UserName, u.UserPatronymic, r.RoleName " +
                    "FROM User u JOIN Role r ON r.RoleID=u.UserRole " +
                    "WHERE u.UserLogin=@l AND u.UserPassword=@p", conn);
                cmd.Parameters.AddWithValue("@l", login);
                cmd.Parameters.AddWithValue("@p", password);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string fio = reader["UserSurname"] + " " + reader["UserName"] + " " + reader["UserPatronymic"];
                    string role = reader["RoleName"].ToString();
                    reader.Close();
                    conn.Close();
                    Hide();

                    if (role == "Администратор") new MainAdminForm(fio).ShowDialog();
                    else if (role == "Менеджер") new MainManagerForm(fio).ShowDialog();
                    else new MainClientForm(fio).ShowDialog();

                    Show();
                    txtLogin.Clear();
                    txtPassword.Clear();
                    txtCaptcha.Clear();
                    txtLogin.Focus();
                }
                else
                {
                    reader.Close();
                    conn.Close();

                    fails = fails + 1;
                    MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    lblCaptcha.Visible = true;
                    txtCaptcha.Visible = true;
                    btnRefresh.Visible = true;
                    lblCaptchaTitle.Visible = true;

                    captcha.Generate();
                    captcha.Show(lblCaptcha);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Вы точно хотите выйти?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                e.Cancel = true;
            else
                Application.Exit();
        }
    }
}