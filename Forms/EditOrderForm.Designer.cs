namespace trade_app.Forms
{
    partial class EditOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle, lblOrderId, lblStatus, lblDelivery;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpDelivery;
        private System.Windows.Forms.Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.dtpDelivery = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // picLogo
            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = "Изменение заказа";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 20);
            this.lblTitle.AutoSize = true;

            // lblOrderId
            this.lblOrderId.Text = "Заказ №";
            this.lblOrderId.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderId.Location = new System.Drawing.Point(20, 80);
            this.lblOrderId.AutoSize = true;

            // lblStatus
            this.lblStatus.Text = "Статус:";
            this.lblStatus.Location = new System.Drawing.Point(20, 130);
            this.lblStatus.AutoSize = true;

            // cmbStatus
            this.cmbStatus.Location = new System.Drawing.Point(180, 127);
            this.cmbStatus.Size = new System.Drawing.Size(280, 25);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblDelivery
            this.lblDelivery.Text = "Дата доставки:";
            this.lblDelivery.Location = new System.Drawing.Point(20, 170);
            this.lblDelivery.AutoSize = true;

            // dtpDelivery
            this.dtpDelivery.Location = new System.Drawing.Point(180, 167);
            this.dtpDelivery.Size = new System.Drawing.Size(280, 25);
            this.dtpDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(30, 220);
            this.btnSave.Size = new System.Drawing.Size(200, 45);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(250, 220);
            this.btnCancel.Size = new System.Drawing.Size(200, 45);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // EditOrderForm
            this.ClientSize = new System.Drawing.Size(490, 290);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblDelivery);
            this.Controls.Add(this.dtpDelivery);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Изменение заказа";
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