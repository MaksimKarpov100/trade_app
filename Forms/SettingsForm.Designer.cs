namespace trade_app.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle, lblHost, lblDatabase, lblUser, lblPassword, lblPort, lblSqlPath;
        private System.Windows.Forms.TextBox txtHost, txtDatabase, txtUser, txtPassword, txtSqlPath;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Button btnChooseSql, btnSave, btnRestore;

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
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblSqlPath = new System.Windows.Forms.Label();
            this.txtSqlPath = new System.Windows.Forms.TextBox();
            this.btnChooseSql = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblTitle.Text = "Настройки подключения";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(75, 22);
            this.lblTitle.AutoSize = true;

            this.lblHost.Text = "Название сервера:"; this.lblHost.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblHost.Location = new System.Drawing.Point(20, 80); this.lblHost.AutoSize = true;
            this.txtHost.Location = new System.Drawing.Point(220, 77); this.txtHost.Size = new System.Drawing.Size(280, 25);

            this.lblDatabase.Text = "Название базы данных:"; this.lblDatabase.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDatabase.Location = new System.Drawing.Point(20, 115); this.lblDatabase.AutoSize = true;
            this.txtDatabase.Location = new System.Drawing.Point(220, 112); this.txtDatabase.Size = new System.Drawing.Size(280, 25);

            this.lblUser.Text = "Имя пользователя:"; this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblUser.Location = new System.Drawing.Point(20, 150); this.lblUser.AutoSize = true;
            this.txtUser.Location = new System.Drawing.Point(220, 147); this.txtUser.Size = new System.Drawing.Size(280, 25);

            this.lblPassword.Text = "Пароль пользователя:"; this.lblPassword.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPassword.Location = new System.Drawing.Point(20, 185); this.lblPassword.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(220, 182); this.txtPassword.Size = new System.Drawing.Size(280, 25);
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblPort.Text = "Порт:"; this.lblPort.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPort.Location = new System.Drawing.Point(20, 220); this.lblPort.AutoSize = true;
            this.numPort.Location = new System.Drawing.Point(220, 217); this.numPort.Size = new System.Drawing.Size(120, 25);
            this.numPort.Maximum = 65535; this.numPort.Minimum = 1; this.numPort.Value = 3306;

            this.lblSqlPath.Text = "SQL-скрипт структуры:"; this.lblSqlPath.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblSqlPath.Location = new System.Drawing.Point(20, 265); this.lblSqlPath.AutoSize = true;
            this.txtSqlPath.Location = new System.Drawing.Point(220, 262); this.txtSqlPath.Size = new System.Drawing.Size(280, 25);
            this.txtSqlPath.ReadOnly = true;

            this.btnChooseSql.Text = "Обзор…";
            this.btnChooseSql.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnChooseSql.Location = new System.Drawing.Point(510, 260);
            this.btnChooseSql.Size = new System.Drawing.Size(80, 28);
            this.btnChooseSql.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnChooseSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseSql.Click += new System.EventHandler(this.btnChooseSql_Click);

            this.btnSave.Text = "Установить соединение";
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(30, 320);
            this.btnSave.Size = new System.Drawing.Size(270, 45);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnRestore.Text = "Восстановить БД";
            this.btnRestore.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestore.Location = new System.Drawing.Point(320, 320);
            this.btnRestore.Size = new System.Drawing.Size(270, 45);
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            this.ClientSize = new System.Drawing.Size(620, 390);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHost); this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblDatabase); this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblUser); this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPassword); this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPort); this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblSqlPath); this.Controls.Add(this.txtSqlPath);
            this.Controls.Add(this.btnChooseSql);
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