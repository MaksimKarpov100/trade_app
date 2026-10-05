namespace trade_app.Forms
{
    partial class ImportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle, lblTable, lblCsv;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnChoose, btnImport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lblCsv = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            this.picLogo.Image = global::trade_app.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(15, 12);
            this.picLogo.Size = new System.Drawing.Size(45, 45);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblTitle.Text = "Импорт данных";
            this.lblTitle.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 20);
            this.lblTitle.AutoSize = true;

            this.lblTable.Text = "Таблица:";
            this.lblTable.Location = new System.Drawing.Point(20, 85);
            this.lblTable.AutoSize = true;
            this.cmbTable.Location = new System.Drawing.Point(120, 82);
            this.cmbTable.Size = new System.Drawing.Size(250, 25);
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblCsv.Text = "CSV-файл:";
            this.lblCsv.Location = new System.Drawing.Point(20, 120);
            this.lblCsv.AutoSize = true;
            this.txtPath.Location = new System.Drawing.Point(120, 117);
            this.txtPath.Size = new System.Drawing.Size(350, 25);
            this.txtPath.ReadOnly = true;

            this.btnChoose.Text = "Обзор…";
            this.btnChoose.Location = new System.Drawing.Point(480, 115);
            this.btnChoose.Size = new System.Drawing.Size(90, 30);
            this.btnChoose.BackColor = System.Drawing.Color.FromArgb(204, 255, 204);
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);

            this.btnImport.Text = "Импортировать";
            this.btnImport.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnImport.Location = new System.Drawing.Point(120, 160);
            this.btnImport.Size = new System.Drawing.Size(200, 45);
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            this.ClientSize = new System.Drawing.Size(600, 230);
            this.Controls.Add(this.picLogo); this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTable); this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.lblCsv); this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnChoose); this.Controls.Add(this.btnImport);
            this.Text = "Импорт данных";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.ImportForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}