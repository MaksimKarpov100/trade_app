using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace trade_app.Services
{
    public static class BackupService
    {
        private static readonly string[] Tables = new string[]
        {
            "Role",
            "OrderStatus",
            "Unit",
            "Category",
            "Manufacturer",
            "Supplier",
            "ProductStatus",
            "User",
            "PickupPoint",
            "Product",
            "Order",
            "OrderProduct"
        };

        public static string CreateAutoBackup()
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string root = Path.Combine(appDir, "Backups");
            if (!Directory.Exists(root)) Directory.CreateDirectory(root);

            string baseName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string folder = Path.Combine(root, baseName);

            int counter = 1;
            while (Directory.Exists(folder))
            {
                folder = Path.Combine(root, baseName + "_" + counter);
                counter++;
            }

            CreateBackup(folder);
            return folder;
        }

        public static void CreateBackup(string targetFolder)
        {
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            try
            {
                foreach (string table in Tables)
                {
                    try { ExportTable(conn, table, targetFolder); }
                    catch {}
                }

                File.WriteAllText(
                    Path.Combine(targetFolder, "_backup_info.txt"),
                    "Дата создания: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    Environment.NewLine +
                    "Приложение: trade_app" + Environment.NewLine +
                    "БД: " + Properties.Settings.Default.Database,
                    new UTF8Encoding(true));
            }
            finally { conn.Close(); }
        }

        private static void ExportTable(MySqlConnection conn, string table, string folder)
        {
            string path = Path.Combine(folder, table + ".csv");

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `" + table + "`", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true));
            try
            {
                string[] headers = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++) headers[i] = reader.GetName(i);
                sw.WriteLine(string.Join(",", headers));

                while (reader.Read())
                {
                    string[] values = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.IsDBNull(i)) values[i] = "";
                        else values[i] = Escape(reader.GetValue(i).ToString());
                    }
                    sw.WriteLine(string.Join(",", values));
                }
            }
            finally { sw.Close(); reader.Close(); }
        }

        private static string Escape(string value)
        {
            bool needQuotes = value.Contains(",") || value.Contains("\"") ||
                              value.Contains("\n") || value.Contains("\r");
            if (value.Contains("\"")) value = value.Replace("\"", "\"\"");
            if (needQuotes) value = "\"" + value + "\"";
            return value;
        }

        public static void RestoreBackup(string backupFolder)
        {
            if (!Directory.Exists(backupFolder))
                throw new DirectoryNotFoundException(
                    "Папка с резервной копией не найдена: " + backupFolder);

            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            try
            {
                new MySqlCommand("SET FOREIGN_KEY_CHECKS=0", conn).ExecuteNonQuery();

                for (int i = Tables.Length - 1; i >= 0; i--)
                {
                    string path = Path.Combine(backupFolder, Tables[i] + ".csv");
                    if (!File.Exists(path)) continue;
                    try { new MySqlCommand("DELETE FROM `" + Tables[i] + "`", conn).ExecuteNonQuery(); }
                    catch { }
                }

                foreach (string table in Tables)
                {
                    string path = Path.Combine(backupFolder, table + ".csv");
                    if (!File.Exists(path)) continue;
                    try { ImportTable(conn, table, path); }
                    catch { }
                }

                new MySqlCommand("SET FOREIGN_KEY_CHECKS=1", conn).ExecuteNonQuery();
            }
            finally { conn.Close(); }
        }

        private static void ImportTable(MySqlConnection conn, string table, string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length < 2) return;

            string[] headers = SplitCsv(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Length == 0) continue;
                string[] values = SplitCsv(lines[i]);

                StringBuilder cols = new StringBuilder();
                StringBuilder pars = new StringBuilder();
                for (int j = 0; j < headers.Length; j++)
                {
                    if (j > 0) { cols.Append(","); pars.Append(","); }
                    cols.Append("`").Append(headers[j]).Append("`");
                    pars.Append("@p").Append(j);
                }

                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO `" + table + "` (" + cols + ") VALUES (" + pars + ")", conn);

                for (int j = 0; j < headers.Length; j++)
                {
                    string val = (j < values.Length) ? values[j] : "";
                    if (val == "") cmd.Parameters.AddWithValue("@p" + j, DBNull.Value);
                    else cmd.Parameters.AddWithValue("@p" + j, val);
                }
                cmd.ExecuteNonQuery();
            }
        }

        private static string[] SplitCsv(string line)
        {
            List<string> result = new List<string>();
            bool inQuotes = false;
            string cur = "";

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];
                if (ch == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        cur = cur + '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (ch == ',' && inQuotes == false)
                {
                    result.Add(cur);
                    cur = "";
                }
                else
                {
                    cur = cur + ch;
                }
            }
            result.Add(cur);
            return result.ToArray();
        }
    }
}