namespace trade_app.Forms
{
    partial class OrderViewForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.Label lblFioLabel;
        private System.Windows.Forms.TextBox txtFio;
        private System.Windows.Forms.Label lblPickupLabel;
        private System.Windows.Forms.TextBox txtPickup;
        private System.Windows.Forms.Label lblBirthLabel;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.Label lblPhoneLabel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddressLabel;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Label lblOrderNum;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblDeliveryDate;

        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;

        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Label lblSumNoDisc;
        private System.Windows.Forms.Label lblDiscPercent;
        private System.Windows.Forms.Label lblDiscSum;
        private System.Windows.Forms.Label lblSumTotal;

        private System.Windows.Forms.Label lblReq;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();

            this.grpClient = new System.Windows.Forms.GroupBox();
            this.lblFioLabel = new System.Windows.Forms.Label();
            this.txtFio = new System.Windows.Forms.TextBox();
            this.lblPickupLabel = new System.Windows.Forms.Label();
            this.txtPickup = new System.Windows.Forms.TextBox();
            this.lblBirthLabel = new System.Windows.Forms.Label();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.lblPhoneLabel = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.lblOrderNum = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();

            this.grpCart = new System.Windows.Forms.GroupBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.colArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            this.lblSumNoDisc = new System.Windows.Forms.Label();
            this.lblDiscPercent = new System.Windows.Forms.Label();
            this.lblDiscSum = new System.Windows.Forms.Label();
            this.lblSumTotal = new System.Windows.Forms.Label();

            this.lblReq = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.grpClient.SuspendLayout();
            this.grpCart.SuspendLayout();
            this.SuspendLayout();

            // picLogo
            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblTitle
            this.lblTitle.Text = "Просмотр заказа";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 20);
            this.lblTitle.AutoSize = true;

            // grpClient
            this.grpClient.Text = "Клиент";
            this.grpClient.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpClient.Location = new System.Drawing.Point(20, 75);
            this.grpClient.Size = new System.Drawing.Size(950, 225);
            this.grpClient.Controls.Add(this.lblFioLabel);
            this.grpClient.Controls.Add(this.txtFio);
            this.grpClient.Controls.Add(this.lblPickupLabel);
            this.grpClient.Controls.Add(this.txtPickup);
            this.grpClient.Controls.Add(this.lblBirthLabel);
            this.grpClient.Controls.Add(this.txtBirth);
            this.grpClient.Controls.Add(this.lblPhoneLabel);
            this.grpClient.Controls.Add(this.txtPhone);
            this.grpClient.Controls.Add(this.lblAddressLabel);
            this.grpClient.Controls.Add(this.txtAddress);

            // ФИО
            this.lblFioLabel.Text = "ФИО клиента:";
            this.lblFioLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblFioLabel.Location = new System.Drawing.Point(15, 30);
            this.lblFioLabel.AutoSize = true;

            this.txtFio.Location = new System.Drawing.Point(15, 55);
            this.txtFio.Size = new System.Drawing.Size(450, 26);
            this.txtFio.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtFio.ReadOnly = true;
            this.txtFio.BackColor = System.Drawing.Color.WhiteSmoke;

            // Пункт выдачи
            this.lblPickupLabel.Text = "Пункт выдачи:";
            this.lblPickupLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPickupLabel.Location = new System.Drawing.Point(490, 30);
            this.lblPickupLabel.AutoSize = true;

            this.txtPickup.Location = new System.Drawing.Point(490, 55);
            this.txtPickup.Size = new System.Drawing.Size(440, 26);
            this.txtPickup.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtPickup.ReadOnly = true;
            this.txtPickup.BackColor = System.Drawing.Color.WhiteSmoke;

            // Дата рождения
            this.lblBirthLabel.Text = "Дата рождения:";
            this.lblBirthLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblBirthLabel.Location = new System.Drawing.Point(15, 95);
            this.lblBirthLabel.AutoSize = true;

            this.txtBirth.Location = new System.Drawing.Point(15, 120);
            this.txtBirth.Size = new System.Drawing.Size(215, 26);
            this.txtBirth.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtBirth.ReadOnly = true;
            this.txtBirth.BackColor = System.Drawing.Color.WhiteSmoke;

            // Телефон
            this.lblPhoneLabel.Text = "Контактный телефон:";
            this.lblPhoneLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPhoneLabel.Location = new System.Drawing.Point(250, 95);
            this.lblPhoneLabel.AutoSize = true;

            this.txtPhone.Location = new System.Drawing.Point(250, 120);
            this.txtPhone.Size = new System.Drawing.Size(215, 26);
            this.txtPhone.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtPhone.ReadOnly = true;
            this.txtPhone.BackColor = System.Drawing.Color.WhiteSmoke;

            // Адрес
            this.lblAddressLabel.Text = "Адрес проживания:";
            this.lblAddressLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblAddressLabel.Location = new System.Drawing.Point(15, 160);
            this.lblAddressLabel.AutoSize = true;

            this.txtAddress.Location = new System.Drawing.Point(15, 185);
            this.txtAddress.Size = new System.Drawing.Size(915, 26);
            this.txtAddress.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtAddress.ReadOnly = true;
            this.txtAddress.BackColor = System.Drawing.Color.WhiteSmoke;

            // Метки заказа
            this.lblOrderNum.Text = "Номер заказа: —";
            this.lblOrderNum.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderNum.Location = new System.Drawing.Point(20, 315);
            this.lblOrderNum.AutoSize = true;

            this.lblOrderDate.Text = "Дата заказа: —";
            this.lblOrderDate.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderDate.Location = new System.Drawing.Point(320, 315);
            this.lblOrderDate.AutoSize = true;

            this.lblDeliveryDate.Text = "Дата выполнения: —";
            this.lblDeliveryDate.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryDate.Location = new System.Drawing.Point(620, 315);
            this.lblDeliveryDate.AutoSize = true;

            // grpCart
            this.grpCart.Text = "Состав заказа";
            this.grpCart.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpCart.Location = new System.Drawing.Point(20, 350);
            this.grpCart.Size = new System.Drawing.Size(950, 250);
            this.grpCart.Controls.Add(this.dgvCart);

            this.dgvCart.Location = new System.Drawing.Point(10, 30);
            this.dgvCart.Size = new System.Drawing.Size(930, 210);
            this.dgvCart.ReadOnly = true;
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;

            this.colArticle.HeaderText = "Артикул"; this.colArticle.Name = "colArticle"; this.colArticle.FillWeight = 80F;
            this.colName.HeaderText = "Наименование"; this.colName.Name = "colName"; this.colName.FillWeight = 300F;
            this.colQty.HeaderText = "Количество"; this.colQty.Name = "colQty"; this.colQty.FillWeight = 80F;
            this.colPrice.HeaderText = "Цена"; this.colPrice.Name = "colPrice"; this.colPrice.FillWeight = 80F;

            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colArticle, this.colName, this.colQty, this.colPrice});

            // Статус
            this.lblStatusLabel.Text = "Статус заказа";
            this.lblStatusLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblStatusLabel.Location = new System.Drawing.Point(20, 615);
            this.lblStatusLabel.AutoSize = true;

            this.lblStatus.Text = "—";
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(20, 640);
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.lblStatus.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Суммы
            this.lblSumNoDisc.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblSumNoDisc.Location = new System.Drawing.Point(560, 615);
            this.lblSumNoDisc.AutoSize = true;

            this.lblDiscPercent.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDiscPercent.Location = new System.Drawing.Point(560, 640);
            this.lblDiscPercent.AutoSize = true;

            this.lblDiscSum.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDiscSum.Location = new System.Drawing.Point(560, 665);
            this.lblDiscSum.AutoSize = true;

            this.lblSumTotal.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblSumTotal.Location = new System.Drawing.Point(560, 690);
            this.lblSumTotal.AutoSize = true;

            // lblReq
            this.lblReq.Text = "Для доступа к оформлению чека\nнеобходимо сменить статус на выполнен";
            this.lblReq.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblReq.Location = new System.Drawing.Point(20, 685);
            this.lblReq.AutoSize = true;

            // Кнопки
            this.btnCheck.Text = "Оформить чек";
            this.btnCheck.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheck.Location = new System.Drawing.Point(20, 745);
            this.btnCheck.Size = new System.Drawing.Size(260, 40);
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);

            this.btnClose.Text = "Закрыть просмотр";
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(700, 745);
            this.btnClose.Size = new System.Drawing.Size(270, 40);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(255, 204, 204);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // OrderViewForm
            this.ClientSize = new System.Drawing.Size(990, 810);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.lblOrderNum);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.grpCart);
            this.Controls.Add(this.lblStatusLabel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSumNoDisc);
            this.Controls.Add(this.lblDiscPercent);
            this.Controls.Add(this.lblDiscSum);
            this.Controls.Add(this.lblSumTotal);
            this.Controls.Add(this.lblReq);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnClose);

            this.Text = "Просмотр заказа";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.grpCart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}