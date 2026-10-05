namespace trade_app.Forms
{
    partial class MainClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUser, lblCount, lblPage, lblLegend;
        private System.Windows.Forms.Button btnLogout, btnPrev, btnNext, btnViewCart;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbSort, cmbFilter;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewImageColumn colPhoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticle, colName, colDescription,
            colCost, colDiscount, colQuantity;

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
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnViewCart = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colPhoto = new System.Windows.Forms.DataGridViewImageColumn();
            this.colArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblLegend = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.lblUser);

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(130, 10);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnLogout.Text = "← Выход";
            this.btnLogout.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(10, 15);
            this.btnLogout.Size = new System.Drawing.Size(110, 35);
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Width = 400;
            this.lblUser.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);

            this.txtSearch.Location = new System.Drawing.Point(20, 85);
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.cmbSort.Location = new System.Drawing.Point(290, 85);
            this.cmbSort.Size = new System.Drawing.Size(150, 25);
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] { "Без сортировки", "Цена ↑", "Цена ↓" });
            this.cmbSort.SelectedIndex = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            this.cmbFilter.Location = new System.Drawing.Point(460, 85);
            this.cmbFilter.Size = new System.Drawing.Size(180, 25);
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Items.AddRange(new object[] { "Все диапазоны", "0-9,99%", "10-14,99%", "15% и более" });
            this.cmbFilter.SelectedIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);

            this.btnViewCart.Text = "Просмотр заказа";
            this.btnViewCart.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewCart.Location = new System.Drawing.Point(680, 82);
            this.btnViewCart.Size = new System.Drawing.Size(250, 35);
            this.btnViewCart.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnViewCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCart.Visible = false;
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);

            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(20, 125);
            this.lblCount.AutoSize = true;

            this.dgvProducts.Location = new System.Drawing.Point(20, 155);
            this.dgvProducts.Size = new System.Drawing.Size(1120, 400);
            this.dgvProducts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.dgvProducts.RowTemplate.Height = 60;
            this.dgvProducts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDown);

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

            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colPhoto, this.colArticle, this.colName, this.colDescription,
                this.colCost, this.colDiscount, this.colQuantity});

            this.lblPage.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.lblPage.Location = new System.Drawing.Point(20, 570);
            this.lblPage.AutoSize = true;

            this.btnPrev.Text = "← Назад";
            this.btnPrev.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnPrev.Location = new System.Drawing.Point(200, 565);
            this.btnPrev.Size = new System.Drawing.Size(100, 32);
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            this.btnNext.Text = "Вперёд →";
            this.btnNext.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnNext.Location = new System.Drawing.Point(310, 565);
            this.btnNext.Size = new System.Drawing.Size(100, 32);
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            this.lblLegend.Text = "ПКМ по товару — «Добавить к заказу»";
            this.lblLegend.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lblLegend.ForeColor = System.Drawing.Color.Gray;
            this.lblLegend.Location = new System.Drawing.Point(430, 572);
            this.lblLegend.AutoSize = true;

            this.ClientSize = new System.Drawing.Size(1160, 615);
            this.Controls.Add(this.pnlTop); this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbSort); this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnViewCart); this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvProducts); this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnPrev); this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblLegend);
            this.Text = "Автотовары — Клиент";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainClientForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClientForm_FormClosing);

            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}