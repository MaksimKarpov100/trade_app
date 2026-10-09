using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace trade_app
{
    public class Captcha
    {
        public string Code = "";
        private Random rnd = new Random();

        public void Generate()
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Code = "";
            for (int i = 0; i < 4; i++)
            {
                Code = Code + chars[rnd.Next(chars.Length)];
            }
        }

        public void Draw(PictureBox box)
        {
            int w = box.Width;
            int h = box.Height;

            Bitmap bmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Color.WhiteSmoke);

            for (int i = 0; i < 800; i++)
            {
                int x = rnd.Next(w);
                int y = rnd.Next(h);
                Color c = Color.FromArgb(rnd.Next(120, 200),
                                         rnd.Next(120, 200),
                                         rnd.Next(120, 200));
                using (Brush b = new SolidBrush(c))
                {
                    g.FillEllipse(b, x, y, 1, 1);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Color c = Color.FromArgb(rnd.Next(100, 180),
                                         rnd.Next(100, 180),
                                         rnd.Next(100, 180));
                using (Pen p = new Pen(c, 1))
                {
                    g.DrawLine(p, rnd.Next(w), rnd.Next(h), rnd.Next(w), rnd.Next(h));
                }
            }

            for (int i = 0; i < Code.Length; i++)
            {
                float x = 15 + i * (w - 30) / 4 + rnd.Next(-5, 5);
                float y = 12 + rnd.Next(-6, 12);

                float angle = rnd.Next(-30, 30);

                Color color = Color.FromArgb(rnd.Next(20, 100),
                                             rnd.Next(20, 100),
                                             rnd.Next(20, 100));

                GraphicsState state = g.Save();
                g.TranslateTransform(x, y);
                g.RotateTransform(angle);

                using (Font font = new Font("Comic Sans MS", 22, FontStyle.Bold))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawString(Code[i].ToString(), font, brush, 0, 0);
                }

                g.Restore(state);
            }

            using (Pen p = new Pen(Color.FromArgb(150, 60, 60), 2))
            {
                g.DrawLine(p, 5, h / 2 + rnd.Next(-5, 5), w - 5, h / 2 + rnd.Next(-5, 5));
            }

            using (Pen p = new Pen(Color.FromArgb(150, 80, 80), 1))
            {
                g.DrawLine(p, rnd.Next(0, 20), 5, w - rnd.Next(0, 20), h - 5);
            }

            box.Image = bmp;
        }
    }
}