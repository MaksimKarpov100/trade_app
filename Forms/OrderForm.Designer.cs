namespace trade_app.Forms
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.DataGridView dgvOrders;

        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSostav;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSumNoDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPickup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();

            this.lblCount = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();

            this.dgvOrders = new System.Windows.Forms.DataGridView();

            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSostav = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSumNoDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPickup = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblUser);

            // picLogo
            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(130, 10);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // btnLogout
            this.btnLogout.Text = "← Выход";
            this.btnLogout.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(10, 15);
            this.btnLogout.Size = new System.Drawing.Size(110, 35);
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // lblUser
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Width = 400;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);

            // cmbSort
            this.cmbSort.Location = new System.Drawing.Point(20, 85);
            this.cmbSort.Size = new System.Drawing.Size(220, 25);
            this.cmbSort.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] { "Без сортировки", "Стоимость ↑", "Стоимость ↓" });
            this.cmbSort.SelectedIndex = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // cmbFilter
            this.cmbFilter.Location = new System.Drawing.Point(260, 85);
            this.cmbFilter.Size = new System.Drawing.Size(220, 25);
            this.cmbFilter.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Items.AddRange(new object[] { "Все диапазоны", "0-10%", "11-14%", "15% и более" });
            this.cmbFilter.SelectedIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);

            // btnReset
            this.btnReset.Text = "Сбросить фильтр";
            this.btnReset.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnReset.Location = new System.Drawing.Point(500, 83);
            this.btnReset.Size = new System.Drawing.Size(180, 30);
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // lblCount
            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(700, 88);
            this.lblCount.AutoSize = true;

            // dgvOrders
            this.dgvOrders.Location = new System.Drawing.Point(20, 125);
            this.dgvOrders.Size = new System.Drawing.Size(1380, 550);
            this.dgvOrders.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
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
            this.dgvOrders.RowTemplate.Height = 40;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);

            // colOrderID
            this.colOrderID.HeaderText = "№ заказа";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.DataPropertyName = "OrderID";
            this.colOrderID.FillWeight = 50F;

            // colDate
            this.colDate.HeaderText = "Дата заказа";
            this.colDate.Name = "colDate";
            this.colDate.DataPropertyName = "OrderDate";
            this.colDate.FillWeight = 80F;

            // colDelivery
            this.colDelivery.HeaderText = "Дата доставки";
            this.colDelivery.Name = "colDelivery";
            this.colDelivery.DataPropertyName = "OrderDeliveryDate";
            this.colDelivery.FillWeight = 80F;

            // colStatus
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            this.colStatus.DataPropertyName = "StatusName";
            this.colStatus.FillWeight = 70F;

            // colStatusID
            this.colStatusID.HeaderText = "StatusID";
            this.colStatusID.Name = "colStatusID";
            this.colStatusID.DataPropertyName = "OrderStatusID";
            this.colStatusID.Visible = false;

            // colClient
            this.colClient.HeaderText = "ФИО клиента";
            this.colClient.Name = "colClient";
            this.colClient.DataPropertyName = "OrderClientName";
            this.colClient.FillWeight = 130F;

            // colSostav
            this.colSostav.HeaderText = "Состав заказа";
            this.colSostav.Name = "colSostav";
            this.colSostav.DataPropertyName = "Sostav";
            this.colSostav.FillWeight = 300F;

            // colSumNoDiscount
            this.colSumNoDiscount.HeaderText = "Сумма";
            this.colSumNoDiscount.Name = "colSumNoDiscount";
            this.colSumNoDiscount.DataPropertyName = "SumNoDiscount";
            this.colSumNoDiscount.FillWeight = 70F;

            // colDiscountSum
            this.colDiscountSum.HeaderText = "Скидка";
            this.colDiscountSum.Name = "colDiscountSum";
            this.colDiscountSum.DataPropertyName = "DiscountSum";
            this.colDiscountSum.FillWeight = 70F;

            // colCode
            this.colCode.HeaderText = "Код";
            this.colCode.Name = "colCode";
            this.colCode.DataPropertyName = "OrderCode";
            this.colCode.FillWeight = 50F;

            // colPickup
            this.colPickup.HeaderText = "Пункт выдачи";
            this.colPickup.Name = "colPickup";
            this.colPickup.DataPropertyName = "PickupAddress";
            this.colPickup.FillWeight = 180F;

            // colMinStock
            this.colMinStock.HeaderText = "Мин.остаток";
            this.colMinStock.Name = "colMinStock";
            this.colMinStock.DataPropertyName = "MinStock";
            this.colMinStock.Visible = false;

            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colOrderID, this.colDate, this.colDelivery, this.colStatus,
                this.colStatusID, this.colClient, this.colSostav,
                this.colSumNoDiscount, this.colDiscountSum, this.colCode,
                this.colMinStock, this.colPickup});

            // OrdersForm
            this.ClientSize = new System.Drawing.Size(1420, 700);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvOrders);

            this.Text = "Автотовары — Заказы";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrdersForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}