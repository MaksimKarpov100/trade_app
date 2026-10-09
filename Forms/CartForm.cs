using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace trade_app.Forms
{
    public partial class CartForm : Form
    {
        private string userFio;

        public CartForm(string userFio)
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            this.userFio = userFio;
            ShowCart();
        }

        private void ShowCart()
        {
            dgvCart.Rows.Clear();

            for (int i = 0; i < Cart.Items.Count; i++)
            {
                CartItem item = Cart.Items[i];
                dgvCart.Rows.Add(item.Article, item.Name, item.Quantity,
                                 item.Price.ToString("0.00"),
                                 item.Discount + "%",
                                 item.TotalWithDiscount().ToString("0.00"));
            }

            lblSum.Text = "Сумма заказа: " + Cart.SumTotal().ToString("0.00") + " руб.";
            lblDiscount.Text = "Скидка: " + Cart.SumDiscount().ToString("0.00") + " руб.";

            if (dgvCart.Rows.Count > 0 && dgvCart.SelectedRows.Count > 0)
                LoadPhotoForRow(dgvCart.SelectedRows[0].Index);
            else
                picPhoto.Image = Properties.Resources.picture;

            if (Cart.Count() == 0)
            {
                MessageBox.Show("Корзина пуста.");
                Close();
            }
        }

        private void LoadPhotoForRow(int index)
        {
            if (index < 0 || index >= Cart.Items.Count) return;

            CartItem item = Cart.Items[index];
            if (item.Photo == "")
            {
                picPhoto.Image = Properties.Resources.picture;
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Photos\\" + item.Photo;
                if (File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    picPhoto.Image = new Bitmap(img, 130, 130);
                }
                else
                {
                    picPhoto.Image = Properties.Resources.picture;
                }
            }

            numQty.Value = item.Quantity;
        }

        private void dgvCart_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
                LoadPhotoForRow(dgvCart.SelectedRows[0].Index);
        }

        private void btnApplyQty_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар.");
                return;
            }

            int index = dgvCart.SelectedRows[0].Index;
            int qty = (int)numQty.Value;

            if (qty <= 0)
            {
                Cart.Remove(Cart.Items[index].Article);
                if (Cart.Count() == 0) { Close(); return; }
                ShowCart();
                return;
            }

            Cart.Items[index].Quantity = qty;
            ShowCart();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар.");
                return;
            }

            string article = dgvCart.SelectedRows[0].Cells[0].Value.ToString();
            Cart.Remove(article);

            if (Cart.Count() == 0) { Close(); return; }
            ShowCart();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Cart.Count() == 0)
            {
                MessageBox.Show("Корзина пуста.");
                return;
            }

            CheckoutForm f = new CheckoutForm(userFio);
            if (f.ShowDialog() == DialogResult.OK)
            {
                Cart.Clear();
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}