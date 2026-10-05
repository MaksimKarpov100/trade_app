namespace trade_app.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle, lblHost, lblPort, lblUser, lblPassword, lblDatabase;
        private System.Windows.Forms.TextBox txtHost, txtUser, txtPassword, txtDatabase;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Button btnSave, btnRestore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblTitle.Text = "Настройки";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(75, 22);
            this.lblTitle.AutoSize = true;

            this.lblHost.Text = "Сервер:";
            this.lblHost.Location = new System.Drawing.Point(15, 85);
            this.lblHost.AutoSize = true;
            this.txtHost.Location = new System.Drawing.Point(180, 82);
            this.txtHost.Size = new System.Drawing.Size(250, 25);

            this.lblPort.Text = "Порт:";
            this.lblPort.Location = new System.Drawing.Point(15, 120);
            this.lblPort.AutoSize = true;
            this.numPort.Location = new System.Drawing.Point(180, 117);
            this.numPort.Size = new System.Drawing.Size(100, 25);
            this.numPort.Maximum = 65535;
            this.numPort.Minimum = 1;
            this.numPort.Value = 3306;

            this.lblUser.Text = "Пользователь:";
            this.lblUser.Location = new System.Drawing.Point(15, 155);
            this.lblUser.AutoSize = true;
            this.txtUser.Location = new System.Drawing.Point(180, 152);
            this.txtUser.Size = new System.Drawing.Size(250, 25);

            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Location = new System.Drawing.Point(15, 190);
            this.lblPassword.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(180, 187);
            this.txtPassword.Size = new System.Drawing.Size(250, 25);
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblDatabase.Text = "База данных:";
            this.lblDatabase.Location = new System.Drawing.Point(15, 225);
            this.lblDatabase.AutoSize = true;
            this.txtDatabase.Location = new System.Drawing.Point(180, 222);
            this.txtDatabase.Size = new System.Drawing.Size(250, 25);

            this.btnSave.Text = "Установить соединение";
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(40, 275);
            this.btnSave.Size = new System.Drawing.Size(200, 45);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnRestore.Text = "Восстановить БД";
            this.btnRestore.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestore.Location = new System.Drawing.Point(250, 275);
            this.btnRestore.Size = new System.Drawing.Size(200, 45);
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            this.ClientSize = new System.Drawing.Size(490, 340);
            this.Controls.Add(this.picLogo); this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHost); this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblPort); this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblUser); this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPassword); this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblDatabase); this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.btnSave); this.Controls.Add(this.btnRestore);
            this.Text = "Настройки подключения";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
        }
    }
}