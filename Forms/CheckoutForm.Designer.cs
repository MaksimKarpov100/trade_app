namespace trade_app.Forms
{
    partial class CheckoutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblFio, lblBirth, lblPhone, lblAddress, lblPickup;
        private System.Windows.Forms.ComboBox cmbFio;
        private System.Windows.Forms.Button btnRefreshClients;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox txtPhone, txtAddress;
        private System.Windows.Forms.ComboBox cmbPickupPoint;

        private System.Windows.Forms.Label lblSum, lblDiscount, lblCode;
        private System.Windows.Forms.Button btnConfirm, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblFio = new System.Windows.Forms.Label();
            this.cmbFio = new System.Windows.Forms.ComboBox();
            this.btnRefreshClients = new System.Windows.Forms.Button();

            this.lblBirth = new System.Windows.Forms.Label();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();

            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();

            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.lblPickup = new System.Windows.Forms.Label();
            this.cmbPickupPoint = new System.Windows.Forms.ComboBox();

            this.lblSum = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // Форма
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.ClientSize = new System.Drawing.Size(680, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оформление заказа";

            // picLogo
            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = "Оформление заказа";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 20);
            this.lblTitle.AutoSize = true;

            int labelX = 30;
            int fieldX = 220;
            int fieldW = 380;

            // ФИО
            this.lblFio.Text = "ФИО клиента:";
            this.lblFio.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblFio.Location = new System.Drawing.Point(labelX, 90);
            this.lblFio.AutoSize = true;

            this.cmbFio.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbFio.Location = new System.Drawing.Point(fieldX, 87);
            this.cmbFio.Size = new System.Drawing.Size(fieldW - 50, 26);

            this.btnRefreshClients.Text = "⟳";
            this.btnRefreshClients.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshClients.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnRefreshClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshClients.Location = new System.Drawing.Point(fieldX + fieldW - 40, 86);
            this.btnRefreshClients.Size = new System.Drawing.Size(40, 27);
            this.btnRefreshClients.UseVisualStyleBackColor = false;
            this.btnRefreshClients.Click += new System.EventHandler(this.btnRefreshClients_Click);

            // Дата рождения
            this.lblBirth.Text = "Дата рождения:";
            this.lblBirth.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblBirth.Location = new System.Drawing.Point(labelX, 135);
            this.lblBirth.AutoSize = true;

            this.dtpBirth.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirth.Location = new System.Drawing.Point(fieldX, 132);
            this.dtpBirth.Size = new System.Drawing.Size(fieldW, 26);
            this.dtpBirth.ShowCheckBox = true;
            this.dtpBirth.Checked = false;

            // Телефон
            this.lblPhone.Text = "Контактный телефон:";
            this.lblPhone.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(labelX, 180);
            this.lblPhone.AutoSize = true;

            this.txtPhone.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtPhone.Location = new System.Drawing.Point(fieldX, 177);
            this.txtPhone.Size = new System.Drawing.Size(fieldW, 26);

            // Адрес
            this.lblAddress.Text = "Адрес проживания:";
            this.lblAddress.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Location = new System.Drawing.Point(labelX, 225);
            this.lblAddress.AutoSize = true;

            this.txtAddress.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtAddress.Location = new System.Drawing.Point(fieldX, 222);
            this.txtAddress.Size = new System.Drawing.Size(fieldW, 50);
            this.txtAddress.Multiline = true;

            // Пункт выдачи
            this.lblPickup.Text = "Пункт выдачи:";
            this.lblPickup.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblPickup.Location = new System.Drawing.Point(labelX, 295);
            this.lblPickup.AutoSize = true;

            this.cmbPickupPoint.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbPickupPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPickupPoint.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.cmbPickupPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPickupPoint.Location = new System.Drawing.Point(fieldX, 292);
            this.cmbPickupPoint.Size = new System.Drawing.Size(fieldW, 26);

            // Итоги
            this.lblSum.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblSum.Location = new System.Drawing.Point(30, 355);
            this.lblSum.AutoSize = true;

            this.lblDiscount.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
            this.lblDiscount.Location = new System.Drawing.Point(30, 385);
            this.lblDiscount.AutoSize = true;

            this.lblCode.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(0, 120, 0);
            this.lblCode.Location = new System.Drawing.Point(30, 425);
            this.lblCode.AutoSize = true;

            // Кнопки
            this.btnConfirm.Text = "Подтвердить заказ";
            this.btnConfirm.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(30, 490);
            this.btnConfirm.Size = new System.Drawing.Size(280, 45);
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(340, 490);
            this.btnCancel.Size = new System.Drawing.Size(180, 45);
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // CheckoutForm
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFio);
            this.Controls.Add(this.cmbFio);
            this.Controls.Add(this.btnRefreshClients);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPickup);
            this.Controls.Add(this.cmbPickupPoint);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}