using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Search_Engines_Parser_2
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool AppExit;
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppExit)
            {
                return;
            }
            //Подтверждение
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Завершение потоков
                AppExit = true;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void addKeywordsTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl.AddNewTabPage("Кейворды", new KeywordsControl());
        }

        private void addLinksTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl.AddNewTabPage("Ссылки", new LinksControl());
        }

        private void addBackLinksTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl.AddNewTabPage("Бэклинки", new BackLinksControl());
        }

        private void addTextTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl.AddNewTabPage("Текст", new TextControl());
        }

        private void addSnippetsTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl.AddNewTabPage("Сниппеты", new SnippetsControl());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bool EULAAccepted = false;
            do
            {
                //Чтение файла
                if (!File.Exists(Application.UserAppDataPath + "\\EULA.txt"))
                {
                    EULAAccepted = false;
                    EULAWindow newEULA = new EULAWindow();
                    newEULA.ShowDialog();
                }
                else
                {
                    try
                    {
                        string data = File.ReadAllText(Application.UserAppDataPath + "\\EULA.txt", Encoding.Default);
                        if (data == "TRUE")
                        {
                            EULAAccepted = true;
                        }
                        else
                        {
                            EULAAccepted = false;
                            EULAWindow newEULA = new EULAWindow();
                            newEULA.ShowDialog();
                        }
                    }
                    catch (Exception)
                    {
                        EULAAccepted = false;
                    }
                }

                //Чтение файла
                if (!File.Exists(Application.UserAppDataPath + "\\EULA.txt") && !EULAAccepted)
                {
                    EULAAccepted = false;
                }
                else
                {
                    try
                    {
                        string data = File.ReadAllText(Application.UserAppDataPath + "\\EULA.txt", Encoding.Default);
                        if (data == "TRUE")
                        {
                            EULAAccepted = true;
                        }
                        else
                        {
                            EULAAccepted = false;
                        }
                    }
                    catch (Exception)
                    {
                        EULAAccepted = false;
                    }
                }

            } while (!EULAAccepted);

            Focus();
        }

        private void eULAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EULAWindow newEULA = new EULAWindow();
            newEULA.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow newAbout = new AboutWindow();
            newAbout.ShowDialog();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://umaxsoft.com/projects/usep-2/");
        }

        private void joinFilesФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("FileJoiner.exe"))
            {
                System.Diagnostics.Process.Start("FileJoiner.exe");
            }
        }
    }
}
