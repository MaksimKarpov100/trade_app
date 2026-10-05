using System;
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
                Code = Code + chars[rnd.Next(chars.Length)];
        }

        public void Show(Label label)
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            string display = "";

            for (int i = 0; i < Code.Length; i++)
            {
                display = display + Code[i];
                int noise = rnd.Next(1, 3);
                for (int n = 0; n < noise; n++)
                    display = display + chars[rnd.Next(chars.Length)];
            }

            display = chars[rnd.Next(chars.Length)] + display +
                      chars[rnd.Next(chars.Length)];

            label.Text = display;
        }
    }
}