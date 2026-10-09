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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();

            this.dgvOrders = new System.Windows.Forms.DataGridView();

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

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpSort.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblUser);

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(130, 10);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblTitle.Text = "Учёт заказов";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(190, 18);
            this.lblTitle.AutoSize = true;

            this.btnLogout.Text = "← Выход";
            this.btnLogout.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(10, 15);
            this.btnLogout.Size = new System.Drawing.Size(110, 35);
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Width = 350;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);

            // dgvOrders
            this.dgvOrders.Location = new System.Drawing.Point(20, 80);
            this.dgvOrders.Size = new System.Drawing.Size(1120, 340);
            this.dgvOrders.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.dgvOrders.RowTemplate.Height = 30;

            // lblRecords
            this.lblRecords.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecords.Location = new System.Drawing.Point(20, 430);
            this.lblRecords.AutoSize = true;

            // lblPage
            this.lblPage.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPage.Location = new System.Drawing.Point(220, 430);
            this.lblPage.AutoSize = true;

            // btnPrev
            this.btnPrev.Text = "◄";
            this.btnPrev.Location = new System.Drawing.Point(320, 427);
            this.btnPrev.Size = new System.Drawing.Size(40, 28);
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // btnNext
            this.btnNext.Text = "►";
            this.btnNext.Location = new System.Drawing.Point(370, 427);
            this.btnNext.Size = new System.Drawing.Size(40, 28);
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // lblSumPaid
            this.lblSumPaid.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblSumPaid.Location = new System.Drawing.Point(600, 430);
            this.lblSumPaid.AutoSize = true;

            // grpSearch
            this.grpSearch.Text = "Поиск";
            this.grpSearch.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpSearch.Location = new System.Drawing.Point(20, 470);
            this.grpSearch.Size = new System.Drawing.Size(200, 80);
            this.grpSearch.Controls.Add(this.txtSearch);

            this.txtSearch.Location = new System.Drawing.Point(15, 32);
            this.txtSearch.Size = new System.Drawing.Size(170, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // grpFilter
            this.grpFilter.Text = "Фильтрация";
            this.grpFilter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpFilter.Location = new System.Drawing.Point(230, 470);
            this.grpFilter.Size = new System.Drawing.Size(500, 200);
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

            this.lblDateFrom.Text = "Дата заказа от:";
            this.lblDateFrom.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDateFrom.Location = new System.Drawing.Point(15, 30);
            this.lblDateFrom.AutoSize = true;

            this.dtpFrom.Location = new System.Drawing.Point(140, 27);
            this.dtpFrom.Size = new System.Drawing.Size(140, 25);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);

            this.lblDateTo.Text = "до:";
            this.lblDateTo.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblDateTo.Location = new System.Drawing.Point(15, 65);
            this.lblDateTo.AutoSize = true;

            this.dtpTo.Location = new System.Drawing.Point(140, 62);
            this.dtpTo.Size = new System.Drawing.Size(140, 25);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);

            this.lblStatusTitle.Text = "Статус:";
            this.lblStatusTitle.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblStatusTitle.Location = new System.Drawing.Point(300, 30);
            this.lblStatusTitle.AutoSize = true;

            this.chkAccepted.Text = "Принят";
            this.chkAccepted.Location = new System.Drawing.Point(300, 55);
            this.chkAccepted.AutoSize = true;
            this.chkAccepted.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

            this.chkCompleted.Text = "Выполнен";
            this.chkCompleted.Location = new System.Drawing.Point(300, 80);
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

            this.chkCanceled.Text = "Отменён";
            this.chkCanceled.Location = new System.Drawing.Point(300, 105);
            this.chkCanceled.AutoSize = true;
            this.chkCanceled.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);

            this.lblLegendTitle.Text = "Цвета строк:";
            this.lblLegendTitle.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblLegendTitle.Location = new System.Drawing.Point(15, 130);
            this.lblLegendTitle.AutoSize = true;

            this.lblLegend1.Text = "■ #20b2aa — все товары > 3";
            this.lblLegend1.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.lblLegend1.ForeColor = System.Drawing.Color.FromArgb(32, 178, 170);
            this.lblLegend1.Location = new System.Drawing.Point(15, 155);
            this.lblLegend1.AutoSize = true;

            this.lblLegend2.Text = "■ #ff8c00 — есть товары < 3";
            this.lblLegend2.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.lblLegend2.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.lblLegend2.Location = new System.Drawing.Point(200, 155);
            this.lblLegend2.AutoSize = true;

            // grpSort
            this.grpSort.Text = "Сортировка";
            this.grpSort.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.grpSort.Location = new System.Drawing.Point(750, 470);
            this.grpSort.Size = new System.Drawing.Size(390, 200);
            this.grpSort.Controls.Add(this.cmbSort);
            this.grpSort.Controls.Add(this.btnReset);

            this.cmbSort.Location = new System.Drawing.Point(15, 30);
            this.cmbSort.Size = new System.Drawing.Size(360, 25);
            this.cmbSort.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] {
                "Без сортировки",
                "Сумма заказа ↑",
                "Сумма заказа ↓",
                "Дата заказа ↑",
                "Дата заказа ↓" });
            this.cmbSort.SelectedIndex = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            this.btnReset.Text = "Очистить фильтр";
            this.btnReset.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(15, 70);
            this.btnReset.Size = new System.Drawing.Size(360, 40);
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // btnViewOrder
            this.btnViewOrder.Text = "Просмотр заказа";
            this.btnViewOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewOrder.Location = new System.Drawing.Point(20, 690);
            this.btnViewOrder.Size = new System.Drawing.Size(260, 40);
            this.btnViewOrder.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);

            // btnExcel
            this.btnExcel.Text = "Отчет Excel";
            this.btnExcel.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnExcel.Location = new System.Drawing.Point(500, 690);
            this.btnExcel.Size = new System.Drawing.Size(280, 40);
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);

            // btnMenu
            this.btnMenu.Text = "В меню";
            this.btnMenu.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenu.Location = new System.Drawing.Point(800, 690);
            this.btnMenu.Size = new System.Drawing.Size(340, 40);
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(255, 204, 204);
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);

            // OrdersForm
            this.ClientSize = new System.Drawing.Size(1160, 750);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvOrders);
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

            this.Text = "Автотовары — Учёт заказов";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrdersForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpSort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}