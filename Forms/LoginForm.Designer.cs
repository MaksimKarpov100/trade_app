namespace trade_app.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Label lblTitle, lblLogin, lblPassword, lblCaptchaTitle;
        private System.Windows.Forms.TextBox txtLogin, txtPassword, txtCaptcha;
        private System.Windows.Forms.Button btnShowPassword, btnRefresh, btnLogin, btnGuest, btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.lblCaptchaTitle = new System.Windows.Forms.Label();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGuest = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();

            // picLogo
            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = "Авторизация";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(75, 22);
            this.lblTitle.AutoSize = true;

            // lblLogin
            this.lblLogin.Text = "Логин:";
            this.lblLogin.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogin.Location = new System.Drawing.Point(25, 85);
            this.lblLogin.AutoSize = true;

            // txtLogin
            this.txtLogin.Location = new System.Drawing.Point(25, 110);
            this.txtLogin.Size = new System.Drawing.Size(240, 27);
            this.txtLogin.Font = new System.Drawing.Font("Comic Sans MS", 11F);

            // lblPassword
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(25, 150);
            this.lblPassword.AutoSize = true;

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(25, 175);
            this.txtPassword.Size = new System.Drawing.Size(200, 27);
            this.txtPassword.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnShowPassword
            this.btnShowPassword.Text = "👁";
            this.btnShowPassword.Location = new System.Drawing.Point(230, 175);
            this.btnShowPassword.Size = new System.Drawing.Size(35, 27);
            this.btnShowPassword.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);

            // lblCaptchaTitle
            this.lblCaptchaTitle.Text = "Проверка (введите символы):";
            this.lblCaptchaTitle.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblCaptchaTitle.Location = new System.Drawing.Point(300, 85);
            this.lblCaptchaTitle.AutoSize = true;
            this.lblCaptchaTitle.Visible = false;

            // picCaptcha (заменяет Label)
            this.picCaptcha.Location = new System.Drawing.Point(300, 115);
            this.picCaptcha.Size = new System.Drawing.Size(220, 70);
            this.picCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaptcha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picCaptcha.Visible = false;
            this.picCaptcha.TabStop = false;

            // txtCaptcha
            this.txtCaptcha.Location = new System.Drawing.Point(300, 195);
            this.txtCaptcha.Size = new System.Drawing.Size(150, 27);
            this.txtCaptcha.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.txtCaptcha.Visible = false;

            // btnRefresh
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.Location = new System.Drawing.Point(460, 195);
            this.btnRefresh.Size = new System.Drawing.Size(60, 27);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnLogin
            this.btnLogin.Text = "Войти";
            this.btnLogin.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(25, 240);
            this.btnLogin.Size = new System.Drawing.Size(240, 40);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnGuest
            this.btnGuest.Text = "Войти как гость";
            this.btnGuest.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnGuest.Location = new System.Drawing.Point(25, 290);
            this.btnGuest.Size = new System.Drawing.Size(240, 35);
            this.btnGuest.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);

            // btnExit
            this.btnExit.Text = "Выйти";
            this.btnExit.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnExit.Location = new System.Drawing.Point(25, 335);
            this.btnExit.Size = new System.Drawing.Size(240, 35);
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(255, 204, 204);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(560, 400);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.lblCaptchaTitle);
            this.Controls.Add(this.picCaptcha);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.btnExit);

            this.Text = "Авторизация";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);
        }
    }
}