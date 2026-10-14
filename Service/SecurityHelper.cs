using System;
using System.Text;

namespace trade_app.Services
{
    public static class SecurityHelper
    {
        public static string MaskFio(string fio)
        {
            if (string.IsNullOrWhiteSpace(fio)) return "";
            string[] parts = fio.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
                if (parts[i].Length > 1)
                    parts[i] = parts[i][0] + new string('*', parts[i].Length - 1);
            return string.Join(" ", parts);
        }

        public static string MaskPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";
            if (phone.Length <= 4) return new string('*', phone.Length);

            StringBuilder sb = new StringBuilder(phone);
            for (int i = 2; i < phone.Length - 2; i++)
                if (char.IsDigit(phone[i])) sb[i] = '*';
            return sb.ToString();
        }

        public static string MaskBirthDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date)) return "";
            DateTime d;
            if (DateTime.TryParse(date, out d))
                return "**.**." + d.Year;
            return new string('*', date.Length);
        }

        public static string MaskAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return "";

            string[] parts = address.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                string p = parts[i].Trim(',');
                if (p.Length > 3 && !char.IsDigit(p[0]))
                    parts[i] = p[0] + new string('*', p.Length - 1) +
                               (parts[i].EndsWith(",") ? "," : "");
            }
            return string.Join(" ", parts);
        }
    }
}