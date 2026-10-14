namespace trade_app.Forms
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle, lblUser;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.DataGridView dgvOrders;

        // ===== Панель полных персональных данных =====
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.Label lblFioFullLabel, lblBirthFullLabel,
            lblPhoneFullLabel, lblAddressFullLabel;
        private System.Windows.Forms.TextBox txtFioFull, txtBirthFull,
            txtPhoneFull, txtAddressFull;

        private System.Windows.Forms.Label lblRecords, lblPage, lblSumPaid;
        private System.Windows.Forms.Button btnPrev, btnNext;

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblDateFrom, lblDateTo, lblStatusTitle;
        private System.Windows.Forms.DateTimePicker dtpFrom, dtpTo;
        private System.Windows.Forms.CheckBox chkAccepted, chkCompleted, chkCanceled;
        private System.Windows.Forms.Label lblLegendTitle, lblLegend1, lblLegend2;

        private System.Windows.Forms.GroupBox grpSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.Button btnViewOrder, btnExcel, btnMenu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();

            this.dgvOrders = new System.Windows.Forms.DataGridView();

            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.lblFioFullLabel = new System.Windows.Forms.Label();
            this.txtFioFull = new System.Windows.Forms.TextBox();
            this.lblBirthFullLabel = new System.Windows.Forms.Label();
            this.txtBirthFull = new System.Windows.Forms.TextBox();
            this.lblPhoneFullLabel = new System.Windows.Forms.Label();
            this.txtPhoneFull = new System.Windows.Forms.TextBox();
            this.lblAddressFullLabel = new System.Windows.Forms.Label();
            this.txtAddressFull = new System.Windows.Forms.TextBox();

            this.lblRecords = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblSumPaid = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();

            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.chkAccepted = new System.Windows.Forms.CheckBox();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.chkCanceled = new System.Windows.Forms.CheckBox();
            this.lblLegendTitle = new System.Windows.Forms.Label();
            this.lblLegend1 = new System.Windows.Forms.Label();
            this.lblLegend2 = new System.Windows.Forms.Label();

            this.grpSort = new System.Windows.Forms.GroupBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();

            this.btnViewOrder = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpPersonal.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpSort.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblUser);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1600, 65);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(190, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Учёт заказов";

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(130, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(10, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 35);
            this.btnLogout.Text = "← Выход";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // dgvOrders — колонки генерируются автоматически из DataTable,
            // потом в коде прячем лишние и переименовываем заголовки
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left));
            this.dgvOrders.AutoGenerateColumns = true;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvOrders.ColumnHeadersHeight = 32;
            this.dgvOrders.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.dgvOrders.Location = new System.Drawing.Point(20, 80);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowTemplate.Height = 30;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(760, 460);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);

            // grpPersonal
            this.grpPersonal.Text = "Персональные данные клиента";
            this.grpPersonal.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpPersonal.Location = new System.Drawing.Point(800, 80);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(760, 460);
            this.grpPersonal.TabIndex = 20;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            this.grpPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Right));

            this.lblFioFullLabel.Text = "ФИО:";
            this.lblFioFullLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblFioFullLabel.Location = new System.Drawing.Point(20, 40);
            this.lblFioFullLabel.AutoSize = true;

            this.txtFioFull.Location = new System.Drawing.Point(20, 65);
            this.txtFioFull.Size = new System.Drawing.Size(720, 26);
            this.txtFioFull.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtFioFull.ReadOnly = true;
            this.txtFioFull.BackColor = System.Drawing.Color.White;

            this.lblBirthFullLabel.Text = "Дата рождения:";
            this.lblBirthFullLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblBirthFullLabel.Location = new System.Drawing.Point(20, 110);
            this.lblBirthFullLabel.AutoSize = true;

            this.txtBirthFull.Location = new System.Drawing.Point(20, 135);
            this.txtBirthFull.Size = new System.Drawing.Size(320, 26);
            this.txtBirthFull.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtBirthFull.ReadOnly = true;
            this.txtBirthFull.BackColor = System.Drawing.Color.White;

            this.lblPhoneFullLabel.Text = "Контактный телефон:";
            this.lblPhoneFullLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPhoneFullLabel.Location = new System.Drawing.Point(360, 110);
            this.lblPhoneFullLabel.AutoSize = true;

            this.txtPhoneFull.Location = new System.Drawing.Point(360, 135);
            this.txtPhoneFull.Size = new System.Drawing.Size(380, 26);
            this.txtPhoneFull.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtPhoneFull.ReadOnly = true;
            this.txtPhoneFull.BackColor = System.Drawing.Color.White;

            this.lblAddressFullLabel.Text = "Адрес проживания:";
            this.lblAddressFullLabel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblAddressFullLabel.Location = new System.Drawing.Point(20, 185);
            this.lblAddressFullLabel.AutoSize = true;

            this.txtAddressFull.Location = new System.Drawing.Point(20, 210);
            this.txtAddressFull.Size = new System.Drawing.Size(720, 100);
            this.txtAddressFull.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.txtAddressFull.Multiline = true;
            this.txtAddressFull.ReadOnly = true;
            this.txtAddressFull.BackColor = System.Drawing.Color.White;

            this.grpPersonal.Controls.Add(this.lblFioFullLabel);
            this.grpPersonal.Controls.Add(this.txtFioFull);
            this.grpPersonal.Controls.Add(this.lblBirthFullLabel);
            this.grpPersonal.Controls.Add(this.txtBirthFull);
            this.grpPersonal.Controls.Add(this.lblPhoneFullLabel);
            this.grpPersonal.Controls.Add(this.txtPhoneFull);
            this.grpPersonal.Controls.Add(this.lblAddressFullLabel);
            this.grpPersonal.Controls.Add(this.txtAddressFull);

            // lblRecords
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecords.Location = new System.Drawing.Point(20, 555);
            this.lblRecords.Name = "lblRecords";

            // lblPage
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPage.Location = new System.Drawing.Point(240, 555);
            this.lblPage.Name = "lblPage";

            // btnPrev
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(340, 552);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 28);
            this.btnPrev.Text = "◄";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // btnNext
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(390, 552);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 28);
            this.btnNext.Text = "►";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // lblSumPaid
            this.lblSumPaid.AutoSize = true;
            this.lblSumPaid.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblSumPaid.Location = new System.Drawing.Point(500, 555);
            this.lblSumPaid.Name = "lblSumPaid";

            // grpSearch
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpSearch.Location = new System.Drawing.Point(20, 590);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(200, 90);
            this.grpSearch.TabIndex = 7;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Поиск";

            this.txtSearch.Location = new System.Drawing.Point(15, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // grpFilter
            this.grpFilter.Controls.Add(this.lblDateFrom);
            this.grpFilter.Controls.Add(this.dtpFrom);
            this.grpFilter.Controls.Add(this.lblDateTo);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.lblStatusTitle);
            this.grpFilter.Controls.Add(this.chkAccepted);
            this.grpFilter.Controls.Add(this.chkCompleted);
            this.grpFilter.Controls.Add(this.chkCanceled);
            this.grpFilter.Controls.Add(this.lblLegendTitle);
            this.grpFilter.Controls.Add(this.lblLegend1);
            this.grpFilter.Controls.Add(this.lblLegend2);
            this.grpFilter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpFilter.Location = new System.Drawing.Point(230, 590);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(500, 200);
            this.grpFilter.TabIndex = 8;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Фильтрация";

            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDateFrom.Location = new System.Drawing.Point(15, 30);
            this.lblDateFrom.Text = "Дата заказа от:";

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(140, 27);
            this.dtpFrom.Size = new System.Drawing.Size(140, 26);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);

            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDateTo.Location = new System.Drawing.Point(15, 65);
            this.lblDateTo.Text = "до:";

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(140, 62);
            this.dtpTo.Size = new System.Drawing.Size(140, 26);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);

            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblStatusTitle.Location = new System.Drawing.Point(300, 30);
            this.lblStatusTitle.Text = "Статус:";

            this.chkAccepted.AutoSize = true;
            this.chkAccepted.Location = new System.Drawing.Point(300, 55);
            this.chkAccepted.Text = "Принят";
            this.chkAccepted.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Location = new System.Drawing.Point(300, 80);
            this.chkCompleted.Text = "Выполнен";
            this.chkCompleted.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

            this.chkCanceled.AutoSize = true;
            this.chkCanceled.Location = new System.Drawing.Point(300, 105);
            this.chkCanceled.Text = "Отменён";
            this.chkCanceled.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

            this.lblLegendTitle.AutoSize = true;
            this.lblLegendTitle.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblLegendTitle.Location = new System.Drawing.Point(15, 130);
            this.lblLegendTitle.Text = "Цвета строк:";

            this.lblLegend1.AutoSize = true;
            this.lblLegend1.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.lblLegend1.ForeColor = System.Drawing.Color.FromArgb(32, 178, 170);
            this.lblLegend1.Location = new System.Drawing.Point(16, 155);
            this.lblLegend1.Text = "■ — все товары > 3";

            this.lblLegend2.AutoSize = true;
            this.lblLegend2.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.lblLegend2.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.lblLegend2.Location = new System.Drawing.Point(15, 170);
            this.lblLegend2.Text = "■ — есть товары < 3";

            // grpSort
            this.grpSort.Controls.Add(this.cmbSort);
            this.grpSort.Controls.Add(this.btnReset);
            this.grpSort.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpSort.Location = new System.Drawing.Point(750, 590);
            this.grpSort.Name = "grpSort";
            this.grpSort.Size = new System.Drawing.Size(400, 200);
            this.grpSort.TabIndex = 9;
            this.grpSort.TabStop = false;
            this.grpSort.Text = "Сортировка";

            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbSort.Items.AddRange(new object[] {
                "Без сортировки",
                "Сумма заказа ↑",
                "Сумма заказа ↓",
                "Дата заказа ↑",
                "Дата заказа ↓"});
            this.cmbSort.Location = new System.Drawing.Point(15, 30);
            this.cmbSort.Size = new System.Drawing.Size(370, 26);
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            this.btnReset.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(15, 70);
            this.btnReset.Size = new System.Drawing.Size(370, 40);
            this.btnReset.Text = "Очистить фильтр";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // btnViewOrder
            this.btnViewOrder.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewOrder.Location = new System.Drawing.Point(20, 805);
            this.btnViewOrder.Size = new System.Drawing.Size(260, 40);
            this.btnViewOrder.Text = "Просмотр заказа";
            this.btnViewOrder.UseVisualStyleBackColor = false;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);

            // btnExcel
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnExcel.Location = new System.Drawing.Point(500, 805);
            this.btnExcel.Size = new System.Drawing.Size(280, 40);
            this.btnExcel.Text = "Отчет Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);

            // btnMenu
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(255, 204, 204);
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenu.Location = new System.Drawing.Point(800, 805);
            this.btnMenu.Size = new System.Drawing.Size(350, 40);
            this.btnMenu.Text = "В меню";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);

            // OrdersForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1580, 860);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.grpPersonal);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblSumPaid);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpSort);
            this.Controls.Add(this.btnViewOrder);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnMenu);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "OrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автотовары — Учёт заказов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrdersForm_FormClosing);
            this.Load += new System.EventHandler(this.OrdersForm_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpSort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}