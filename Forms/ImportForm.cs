using System;
using System.IO;
using System.Windows.Forms;
using trade_app.Services;

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
            MySql.Data.MySqlClient.MySqlConnection conn =
                new MySql.Data.MySqlClient.MySqlConnection(Program.ConnStr(true));
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd =
                new MySql.Data.MySqlClient.MySqlCommand(
                    "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_SCHEMA='" + Properties.Settings.Default.Database + "' " +
                    "AND TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME", conn);
            MySql.Data.MySqlClient.MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) cmbTable.Items.Add(r.GetString(0));
            r.Close();
            conn.Close();
            if (cmbTable.Items.Count > 0) cmbTable.SelectedIndex = 0;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "CSV|*.csv";
            if (d.ShowDialog() == DialogResult.OK) txtPath.Text = d.FileName;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cmbTable.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу.");
                return;
            }
            if (txtPath.Text == "" || File.Exists(txtPath.Text) == false)
            {
                MessageBox.Show("Выберите CSV-файл.");
                return;
            }

            string table = cmbTable.SelectedItem.ToString();
            string folder = Path.GetDirectoryName(txtPath.Text);

            DialogResult confirm = MessageBox.Show(
                "Импортировать все CSV-файлы из папки:\n\n" + folder + "\n\n" +
                "Таблицы будут ОЧИЩЕНЫ и заполнены данными из CSV.\n\nПродолжить?",
                "Подтверждение импорта",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                CsvImporter.ImportResult result = CsvImporter.ImportAll(folder);
                Cursor = Cursors.Default;

                string msg = "Импорт завершён.\n\n" +
                             "Таблиц обработано: " + result.TablesDone + "\n" +
                             "Строк добавлено: " + result.RowsTotal;

                if (result.Errors.Count > 0)
                {
                    msg += "\n\nОшибки (" + result.Errors.Count + "):\n" +
                           string.Join("\n", result.Errors.GetRange(0,
                               Math.Min(5, result.Errors.Count)));
                }

                MessageBox.Show(msg, "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Ошибка массового импорта:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Выберите папку со всеми CSV-файлами";
            dlg.ShowNewFolderButton = false;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            DialogResult confirm = MessageBox.Show(
                "Импортировать ВСЕ CSV из папки:\n\n" + dlg.SelectedPath + "\n\n" +
                "ВНИМАНИЕ: все таблицы будут очищены и залиты заново.\n\nПродолжить?",
                "Подтверждение массового импорта",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                CsvImporter.ImportResult result = CsvImporter.ImportAll(dlg.SelectedPath);
                Cursor = Cursors.Default;

                string msg = "Импорт завершён.\n\n" +
                             "Таблиц обработано: " + result.TablesDone + "\n" +
                             "Строк добавлено: " + result.RowsTotal;

                if (result.Errors.Count > 0)
                {
                    msg += "\n\nОшибки (" + result.Errors.Count + "):\n" +
                           string.Join("\n", result.Errors.GetRange(0,
                               Math.Min(5, result.Errors.Count)));
                }

                MessageBox.Show(msg, "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Ошибка массового импорта:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}