namespace trade_app.Forms
{
    partial class CheckoutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle, lblFio, lblPickup, lblSum, lblDiscount, lblCode;
        private System.Windows.Forms.TextBox txtFio;
        private System.Windows.Forms.ComboBox cmbPickupPoint;
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
            this.txtFio = new System.Windows.Forms.TextBox();
            this.lblPickup = new System.Windows.Forms.Label();
            this.cmbPickupPoint = new System.Windows.Forms.ComboBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblTitle.Text = "Оформление заказа";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 20);
            this.lblTitle.AutoSize = true;

            this.lblFio.Text = "ФИО клиента:";
            this.lblFio.Location = new System.Drawing.Point(20, 90);
            this.lblFio.AutoSize = true;
            this.txtFio.Location = new System.Drawing.Point(180, 87);
            this.txtFio.Size = new System.Drawing.Size(350, 25);

            this.lblPickup.Text = "Пункт выдачи:";
            this.lblPickup.Location = new System.Drawing.Point(20, 130);
            this.lblPickup.AutoSize = true;
            this.cmbPickupPoint.Location = new System.Drawing.Point(180, 127);
            this.cmbPickupPoint.Size = new System.Drawing.Size(350, 25);
            this.cmbPickupPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblSum.Text = "Сумма: 0 руб.";
            this.lblSum.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblSum.Location = new System.Drawing.Point(20, 175);
            this.lblSum.AutoSize = true;

            this.lblDiscount.Text = "Скидка: 0 руб.";
            this.lblDiscount.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(300, 175);
            this.lblDiscount.AutoSize = true;

            this.lblCode.Text = "Код получения: 000";
            this.lblCode.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblCode.Location = new System.Drawing.Point(20, 215);
            this.lblCode.AutoSize = true;

            this.btnConfirm.Text = "Подтвердить заказ";
            this.btnConfirm.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(30, 270);
            this.btnConfirm.Size = new System.Drawing.Size(240, 45);
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(290, 270);
            this.btnCancel.Size = new System.Drawing.Size(240, 45);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(560, 340);
            this.Controls.Add(this.picLogo); this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFio); this.Controls.Add(this.txtFio);
            this.Controls.Add(this.lblPickup); this.Controls.Add(this.cmbPickupPoint);
            this.Controls.Add(this.lblSum); this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnConfirm); this.Controls.Add(this.btnCancel);
            this.Text = "Оформление заказа";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}