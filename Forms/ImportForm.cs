using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trade_app.Forms
{
    public partial class ImportForm : Form
    {
        public ImportForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            cmbTable.Items.Clear();
            MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES " +
                "WHERE TABLE_SCHEMA='" + Properties.Settings.Default.Database + "' " +
                "AND TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME", conn);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) cmbTable.Items.Add(r.GetString(0));
            r.Close(); conn.Close();
            if (cmbTable.Items.Count > 0) cmbTable.SelectedIndex = 0;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "CSV|*.csv";
            if (d.ShowDialog() == DialogResult.OK) txtPath.Text = d.FileName;
        }

        private string[] SplitCsv(string line)
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
                    { cur = cur + '"'; i++; }
                    else inQuotes = !inQuotes;
                }
                else if (ch == ',' && inQuotes == false)
                { result.Add(cur); cur = ""; }
                else cur = cur + ch;
            }
            result.Add(cur);
            return result.ToArray();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem == null) { MessageBox.Show("Выберите таблицу."); return; }
            if (txtPath.Text == "" || File.Exists(txtPath.Text) == false)
            { MessageBox.Show("Выберите CSV-файл."); return; }

            string table = cmbTable.SelectedItem.ToString();
            string[] lines = File.ReadAllLines(txtPath.Text);
            if (lines.Length < 2) { MessageBox.Show("Файл пуст."); return; }

            string[] columns = SplitCsv(lines[0]);
            int count = 0;

            try
            {
                MySqlConnection conn = new MySqlConnection(Program.ConnStr(true));
                conn.Open();

                for (int i = 1; i < lines.Length; i++)
                {
                    if (lines[i].Trim() == "") continue;
                    string[] values = SplitCsv(lines[i]);

                    if (values.Length != columns.Length)
                    {
                        MessageBox.Show("Строка " + (i + 1) + ": найдено " + values.Length +
                            " полей, ожидалось " + columns.Length + ".\n\n" + lines[i]);
                        conn.Close(); return;
                    }

                    string cols = string.Join(",", columns);
                    string vals = "";
                    for (int c = 0; c < columns.Length; c++)
                    {
                        if (c > 0) vals = vals + ",";
                        vals = vals + "@p" + c;
                    }

                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO `" + table + "` (" + cols + ") VALUES (" + vals + ")", conn);

                    for (int c = 0; c < columns.Length; c++)
                    {
                        if (values[c] == "")
                            cmd.Parameters.AddWithValue("@p" + c, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@p" + c, values[c]);
                    }
                    cmd.ExecuteNonQuery();
                    count++;
                }
                conn.Close();
                MessageBox.Show("Импортировано: " + count + " записей.");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка импорта:\n" + ex.Message); }
        }
    }
}