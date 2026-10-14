namespace trade_app.Forms
{
    partial class BackupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvBackups;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvBackups = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // Форма
            this.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F);

            // picLogo
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picLogo.Location = new System.Drawing.Point(12, 9);
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.Image = global::trade_app.Properties.Resources.logo;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(80, 22);
            this.lblTitle.Text = "Резервное копирование данных";

            // lvBackups
            this.lvBackups.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right));
            this.lvBackups.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.lvBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvBackups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colName, this.colDate, this.colSize});
            this.lvBackups.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.lvBackups.FullRowSelect = true;
            this.lvBackups.GridLines = true;
            this.lvBackups.HideSelection = false;
            this.lvBackups.Location = new System.Drawing.Point(12, 80);
            this.lvBackups.MultiSelect = false;
            this.lvBackups.Name = "lvBackups";
            this.lvBackups.Size = new System.Drawing.Size(760, 320);
            this.lvBackups.UseCompatibleStateImageBehavior = false;
            this.lvBackups.View = System.Windows.Forms.View.Details;
            this.lvBackups.DoubleClick += new System.EventHandler(this.lvBackups_DoubleClick);

            this.colName.Text = "Имя копии"; this.colName.Width = 280;
            this.colDate.Text = "Дата создания"; this.colDate.Width = 200;
            this.colSize.Text = "Размер"; this.colSize.Width = 260;

            // lblPath
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right));
            this.lblPath.AutoEllipsis = true;
            this.lblPath.Font = new System.Drawing.Font("Comic Sans MS", 8F);
            this.lblPath.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPath.Location = new System.Drawing.Point(12, 405);
            this.lblPath.Size = new System.Drawing.Size(600, 18);
            this.lblPath.Text = "Папка:";

            // lblCount
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(690, 407);
            this.lblCount.Text = "Копий: 0";

            // btnCreate (акцент)
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreate.Location = new System.Drawing.Point(12, 430);
            this.btnCreate.Size = new System.Drawing.Size(150, 34);
            this.btnCreate.Text = "Создать копию";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // btnRestore
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnRestore.Location = new System.Drawing.Point(170, 430);
            this.btnRestore.Size = new System.Drawing.Size(150, 34);
            this.btnRestore.Text = "Восстановить";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            // btnOpen
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnOpen.Location = new System.Drawing.Point(328, 430);
            this.btnOpen.Size = new System.Drawing.Size(150, 34);
            this.btnOpen.Text = "Открыть папку";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);

            // btnDelete
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnDelete.Location = new System.Drawing.Point(486, 430);
            this.btnDelete.Size = new System.Drawing.Size(130, 34);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnRefresh
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(622, 430);
            this.btnRefresh.Size = new System.Drawing.Size(70, 34);
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)
                (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btnClose.Location = new System.Drawing.Point(700, 430);
            this.btnClose.Size = new System.Drawing.Size(72, 34);
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // BackupForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 480);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lvBackups);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "BackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Резервное копирование";
            this.Load += new System.EventHandler(this.BackupForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}