namespace trade_app.Forms
{
    partial class MainAdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUser, lblCount, lblPage, lblLegend;
        private System.Windows.Forms.Button btnLogout, btnPrev, btnNext, btnImport, btnOrders, btnBackup;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory, cmbManufacturer, cmbSort, cmbFilter;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewImageColumn colPhoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticle, colName, colDescription,
            colCost, colDiscount, colQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colPhoto = new System.Windows.Forms.DataGridViewImageColumn();
            this.colArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblLegend = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
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

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 85);
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(240, 85);
            this.cmbCategory.Size = new System.Drawing.Size(180, 25);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

            // cmbManufacturer
            this.cmbManufacturer.Location = new System.Drawing.Point(440, 85);
            this.cmbManufacturer.Size = new System.Drawing.Size(180, 25);
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.SelectedIndexChanged += new System.EventHandler(this.cmbManufacturer_SelectedIndexChanged);

            // cmbSort
            this.cmbSort.Location = new System.Drawing.Point(640, 85);
            this.cmbSort.Size = new System.Drawing.Size(150, 25);
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] { "Без сортировки", "Цена ↑", "Цена ↓" });
            this.cmbSort.SelectedIndex = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // cmbFilter
            this.cmbFilter.Location = new System.Drawing.Point(810, 85);
            this.cmbFilter.Size = new System.Drawing.Size(170, 25);
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Items.AddRange(new object[] { "Все диапазоны", "0-9,99%", "10-14,99%", "15% и более" });
            this.cmbFilter.SelectedIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);

            // btnOrders
            this.btnOrders.Text = "Заказы";
            this.btnOrders.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrders.Location = new System.Drawing.Point(1000, 82);
            this.btnOrders.Size = new System.Drawing.Size(130, 35);
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

            // btnBackup — НОВОЕ
            this.btnBackup.Text = "Резервное копирование";
            this.btnBackup.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackup.Location = new System.Drawing.Point(1140, 82);
            this.btnBackup.Size = new System.Drawing.Size(210, 35);
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);

            // btnImport
            this.btnImport.Text = "Импорт данных";
            this.btnImport.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnImport.Location = new System.Drawing.Point(1360, 82);
            this.btnImport.Size = new System.Drawing.Size(180, 35);
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            // lblCount
            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(20, 125);
            this.lblCount.AutoSize = true;

            // dgvProducts
            this.dgvProducts.Location = new System.Drawing.Point(20, 155);
            this.dgvProducts.Size = new System.Drawing.Size(1520, 400);
            this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.dgvProducts.RowTemplate.Height = 60;
            this.dgvProducts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDown);
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);

            // Колонки
            this.colPhoto.HeaderText = "Фото"; this.colPhoto.Name = "colPhoto";
            this.colPhoto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colPhoto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPhoto.Width = 60;

            this.colArticle.HeaderText = "Артикул"; this.colArticle.Name = "colArticle";
            this.colArticle.DataPropertyName = "ProductArticleNumber"; this.colArticle.FillWeight = 80F;

            this.colName.HeaderText = "Наименование"; this.colName.Name = "colName";
            this.colName.DataPropertyName = "ProductName"; this.colName.FillWeight = 200F;

            this.colDescription.HeaderText = "Описание"; this.colDescription.Name = "colDescription";
            this.colDescription.DataPropertyName = "ProductDescription"; this.colDescription.FillWeight = 250F;

            this.colCost.HeaderText = "Цена"; this.colCost.Name = "colCost";
            this.colCost.DataPropertyName = "ProductCost"; this.colCost.FillWeight = 80F;

            this.colDiscount.HeaderText = "Скидка %"; this.colDiscount.Name = "colDiscount";
            this.colDiscount.DataPropertyName = "ProductCurrentDiscount"; this.colDiscount.FillWeight = 70F;

            this.colQuantity.HeaderText = "Кол-во"; this.colQuantity.Name = "colQuantity";
            this.colQuantity.DataPropertyName = "ProductQuantityInStock"; this.colQuantity.FillWeight = 70F;

            this.colEdit.HeaderText = ""; this.colEdit.Name = "colEdit";
            this.colEdit.Text = "✎"; this.colEdit.UseColumnTextForButtonValue = true;
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdit.Width = 40;

            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colPhoto, this.colArticle, this.colName, this.colDescription,
                this.colCost, this.colDiscount, this.colQuantity, this.colEdit});

            // lblPage
            this.lblPage.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPage.Location = new System.Drawing.Point(20, 570);
            this.lblPage.AutoSize = true;

            // btnPrev
            this.btnPrev.Text = "◄";
            this.btnPrev.Location = new System.Drawing.Point(200, 565);
            this.btnPrev.Size = new System.Drawing.Size(45, 30);
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // btnNext
            this.btnNext.Text = "►";
            this.btnNext.Location = new System.Drawing.Point(255, 565);
            this.btnNext.Size = new System.Drawing.Size(45, 30);
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // lblLegend
            this.lblLegend.Text = "Зелёный — скидка > 15%; зелёная цена — со скидкой";
            this.lblLegend.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblLegend.ForeColor = System.Drawing.Color.Gray;
            this.lblLegend.Location = new System.Drawing.Point(360, 570);
            this.lblLegend.AutoSize = true;

            // MainAdminForm
            this.ClientSize = new System.Drawing.Size(1580, 620);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblLegend);

            this.Text = "Автотовары — Администратор";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainAdminForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainAdminForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}