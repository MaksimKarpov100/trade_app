namespace trade_app.Forms
{
    partial class MainManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUser, lblInfo;
        private System.Windows.Forms.Button btnLogout, btnOrders;

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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlTop.SuspendLayout();
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

            this.lblInfo.Text = "Панель менеджера";
            this.lblInfo.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(30, 100);
            this.lblInfo.AutoSize = true;

            this.btnOrders.Text = "Управление заказами";
            this.btnOrders.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnOrders.Location = new System.Drawing.Point(30, 160);
            this.btnOrders.Size = new System.Drawing.Size(320, 60);
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(102, 255, 102);
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pnlTop);

            this.Text = "Автотовары — Менеджер";
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainManagerForm_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}