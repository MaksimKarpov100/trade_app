using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using trade_app.Services;

namespace trade_app.Forms
{
    public partial class BackupForm : Form
    {
        private readonly string BackupRoot;

        public BackupForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;

            BackupRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
            if (!Directory.Exists(BackupRoot)) Directory.CreateDirectory(BackupRoot);
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            lvBackups.Items.Clear();

            if (!Directory.Exists(BackupRoot))
            {
                lblPath.Text = "Папка: (не создана)";
                lblCount.Text = "Копий: 0";
                return;
            }

            lblPath.Text = "Папка: " + BackupRoot;

            string[] dirs = Directory.GetDirectories(BackupRoot);
            Array.Sort(dirs);
            Array.Reverse(dirs); 

            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                string name = Path.GetFileName(dir);

                DateTime created = GetBackupDate(dir, name);
                long bytes = GetFolderSize(dir);

                ListViewItem item = new ListViewItem(name);
                item.SubItems.Add(created.ToString("dd.MM.yyyy HH:mm:ss"));
                item.SubItems.Add(HumanSize(bytes));
                item.SubItems.Add(dir);
                item.Tag = dir;

                lvBackups.Items.Add(item);
            }

            lblCount.Text = "Копий: " + lvBackups.Items.Count;
        }

        private DateTime GetBackupDate(string dir, string name)
        {
            try
            {
                string info = Path.Combine(dir, "_backup_info.txt");
                if (File.Exists(info))
                {
                    string[] lines = File.ReadAllLines(info);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith("Дата создания:"))
                        {
                            string raw = lines[i].Replace("Дата создания:", "").Trim();
                            DateTime d;
                            if (DateTime.TryParse(raw, out d)) return d;
                        }
                    }
                }
            }
            catch { }

            try
            {
                if (name.Length >= 19)
                {
                    DateTime d;
                    if (DateTime.TryParseExact(
                        name.Substring(0, 19), "yyyy-MM-dd_HH-mm-ss",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out d))
                        return d;
                }
            }
            catch { }

            try { return Directory.GetCreationTime(dir); }
            catch { return DateTime.MinValue; }
        }

        private long GetFolderSize(string dir)
        {
            long size = 0;
            try
            {
                string[] files = Directory.GetFiles(dir);
                for (int i = 0; i < files.Length; i++)
                    size += new FileInfo(files[i]).Length;
            }
            catch { }
            return size;
        }

        private string HumanSize(long bytes)
        {
            if (bytes < 1024) return bytes + " Б";
            if (bytes < 1024 * 1024) return (bytes / 1024.0).ToString("0.0") + " КБ";
            return (bytes / (1024.0 * 1024.0)).ToString("0.0") + " МБ";
        }

        private string GetSelectedFolder()
        {
            if (lvBackups.SelectedItems.Count == 0) return null;
            object tag = lvBackups.SelectedItems[0].Tag;
            return tag == null ? null : tag.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string folder = Path.Combine(
                BackupRoot,
                DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));

            int counter = 1;
            while (Directory.Exists(folder))
            {
                folder = Path.Combine(
                    BackupRoot,
                    DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + counter);
                counter++;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                BackupService.CreateBackup(folder);
                Cursor = Cursors.Default;

                RefreshList();
                MessageBox.Show("Резервная копия создана:\n" + folder,
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Ошибка резервного копирования:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string folder = GetSelectedFolder();
            if (folder == null)
            {
                MessageBox.Show("Выберите резервную копию из списка.",
                    "Не выбрано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Восстановить базу данных из копии:\n\n" + folder + "\n\n" +
                "ВСЕ текущие данные будут заменены данными из копии.\n\nПродолжить?",
                "Подтверждение восстановления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                BackupService.RestoreBackup(folder);
                Cursor = Cursors.Default;

                MessageBox.Show("База данных восстановлена из копии.",
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Ошибка восстановления:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string folder = GetSelectedFolder();
            if (folder == null) folder = BackupRoot;

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Папка не найдена:\n" + folder,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefreshList();
                return;
            }

            try { Process.Start("explorer.exe", "\"" + folder + "\""); }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть папку:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string folder = GetSelectedFolder();
            if (folder == null)
            {
                MessageBox.Show("Выберите резервную копию из списка.",
                    "Не выбрано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Удалить резервную копию без возможности восстановления?\n\n" + folder,
                "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Directory.Delete(folder, true);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvBackups_DoubleClick(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }
    }
}