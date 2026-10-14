using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace trade_app.Services
{
    public static class CsvImporter
    {
        // User и Role — исключены: их нельзя терять при импорте CSV
        public static readonly string[] TableOrder = new string[]
        {
            "OrderStatus",
            "Unit",
            "Category",
            "Manufacturer",
            "Supplier",
            "ProductStatus",
            "PickupPoint",
            "Product",
            "Order",
            "OrderProduct"
        };

        public class ImportResult
        {
            public int TablesDone;
            public int RowsTotal;
            public List<string> Errors = new List<string>();
        }

        public static ImportResult ImportAll(string folder)
        {
            ImportResult result = new ImportResult();

            if (!Directory.Exists(folder))
                throw new DirectoryNotFoundException("Папка не найдена: " + folder);

            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            try
            {
                new MySqlCommand("SET FOREIGN_KEY_CHECKS=0", conn).ExecuteNonQuery();

                // Очистка — в обратном порядке
                for (int i = TableOrder.Length - 1; i >= 0; i--)
                {
                    string csv = Path.Combine(folder, TableOrder[i] + ".csv");
                    if (!File.Exists(csv)) continue;

                    try
                    {
                        new MySqlCommand("DELETE FROM `" + TableOrder[i] + "`", conn)
                            .ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        result.Errors.Add("DELETE " + TableOrder[i] + ": " + ex.Message);
                    }
                }

                // Импорт — в прямом порядке
                for (int i = 0; i < TableOrder.Length; i++)
                {
                    string table = TableOrder[i];
                    string csv = Path.Combine(folder, table + ".csv");
                    if (!File.Exists(csv)) continue;

                    try
                    {
                        int rows = ImportTable(conn, table, csv);
                        result.TablesDone++;
                        result.RowsTotal += rows;
                    }
                    catch (Exception ex)
                    {
                        result.Errors.Add(table + ": " + ex.Message);
                    }
                }

                // ==== ВОССТАНАВЛИВАЕМ СИСТЕМНЫЕ РОЛИ И ПОЛЬЗОВАТЕЛЕЙ ====
                RestoreSystemRoles(conn);
                RestoreSystemUsers(conn);
                // =======================================================

                new MySqlCommand("SET FOREIGN_KEY_CHECKS=1", conn).ExecuteNonQuery();
            }
            finally { conn.Close(); }

            return result;
        }

        // ============================================================
        //  РОЛИ: гарантируем, что 1=Клиент, 2=Менеджер, 3=Администратор
        // ============================================================
        private static void RestoreSystemRoles(MySqlConnection conn)
        {
            // убираем возможные конфликты по имени, оставшиеся от CSV
            new MySqlCommand(
                "DELETE FROM Role WHERE RoleName IN " +
                "('Клиент','Менеджер','Администратор')", conn).ExecuteNonQuery();

            new MySqlCommand(
                "INSERT INTO Role (RoleID, RoleName) VALUES " +
                "(1, 'Клиент'), " +
                "(2, 'Менеджер'), " +
                "(3, 'Администратор')", conn).ExecuteNonQuery();
        }

        // ============================================================
        //  ПОЛЬЗОВАТЕЛИ: admin/admin, manager/manager, user/user
        // ============================================================
        private static void RestoreSystemUsers(MySqlConnection conn)
        {
            // Удаляем три системные учётки, если они уже есть
            new MySqlCommand(
                "DELETE FROM User WHERE UserLogin IN ('admin','manager','user')", conn)
                .ExecuteNonQuery();

            // Вставляем заново с паролем = логину
            string sql =
                "INSERT INTO User " +
                "(UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserRole) VALUES " +
                "('Админ',  'Админ', 'Админович', 'admin',   'admin',   3), " +
                "('Петров', 'Пётр',  'Петрович',  'manager', 'manager', 2), " +
                "('Иванов', 'Иван',  'Иванович',  'user',    'user',    1)";
            new MySqlCommand(sql, conn).ExecuteNonQuery();
        }

        // ============================================================
        //  Ниже — без изменений
        // ============================================================
        private static int ImportTable(MySqlConnection conn, string table, string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length < 2) return 0;

            string headerLine = lines[0].TrimStart('\uFEFF');
            string[] headers = SplitCsv(headerLine);

            int count = 0;

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

                string sql = "INSERT INTO `" + table + "` (" + cols + ") VALUES (" + pars + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                for (int j = 0; j < headers.Length; j++)
                {
                    string val = (j < values.Length) ? values[j] : "";
                    if (val == "")
                        cmd.Parameters.AddWithValue("@p" + j, DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@p" + j, val);
                }

                cmd.ExecuteNonQuery();
                count++;
            }

            return count;
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
                        cur += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (ch == ',' && !inQuotes)
                {
                    result.Add(cur);
                    cur = "";
                }
                else
                {
                    cur += ch;
                }
            }
            result.Add(cur);
            return result.ToArray();
        }
    }
}