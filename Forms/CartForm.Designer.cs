namespace trade_app.Forms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo, picPhoto;
        private System.Windows.Forms.Label lblTitle, lblSum, lblDiscount;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemove, btnCheckout, btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblTitle.Text = "Просмотр заказа";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 20);
            this.lblTitle.AutoSize = true;

            this.dgvCart.Location = new System.Drawing.Point(20, 75);
            this.dgvCart.Size = new System.Drawing.Size(740, 300);
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.MultiSelect = false;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.SelectionChanged += new System.EventHandler(this.dgvCart_SelectionChanged);
            this.dgvCart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellEndEdit);

            this.dgvCart.Columns.Add("colArticle", "Артикул");
            this.dgvCart.Columns.Add("colName", "Наименование");
            this.dgvCart.Columns.Add("colQty", "Кол-во");
            this.dgvCart.Columns.Add("colPrice", "Цена");
            this.dgvCart.Columns.Add("colDisc", "Скидка");
            this.dgvCart.Columns.Add("colTotal", "Итого");

            this.picPhoto.Location = new System.Drawing.Point(780, 75);
            this.picPhoto.Size = new System.Drawing.Size(140, 140);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.BackColor = System.Drawing.Color.WhiteSmoke;

            this.lblSum.Text = "Сумма заказа: 0 руб.";
            this.lblSum.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblSum.Location = new System.Drawing.Point(20, 385);
            this.lblSum.AutoSize = true;

            this.lblDiscount.Text = "Скидка: 0 руб.";
            this.lblDiscount.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(300, 385);
            this.lblDiscount.AutoSize = true;

            this.btnRemove.Text = "Удалить из заказа";
            this.btnRemove.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnRemove.Location = new System.Drawing.Point(20, 425);
            this.btnRemove.Size = new System.Drawing.Size(200, 40);
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(255, 204, 204);
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            this.btnCheckout.Text = "Оформить заказ";
            this.btnCheckout.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Location = new System.Drawing.Point(240, 425);
            this.btnCheckout.Size = new System.Drawing.Size(240, 40);
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            this.btnClose.Text = "Закрыть";
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.btnClose.Location = new System.Drawing.Point(500, 425);
            this.btnClose.Size = new System.Drawing.Size(160, 40);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new System.Drawing.Size(950, 490);
            this.Controls.Add(this.picLogo); this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCart); this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.lblSum); this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.btnRemove); this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnClose);
            this.Text = "Просмотр заказа";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
        }
    }
}