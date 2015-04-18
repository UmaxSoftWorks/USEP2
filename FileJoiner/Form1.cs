using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;

namespace FileJoiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = string.Empty;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath == string.Empty)
            {
                return;
            }
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = string.Empty;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == string.Empty)
            {
                return;
            }
            textBox2.Text = saveFileDialog1.FileName;
        }

        Thread WorkThread;
        string FolderPath;
        string FilePath;
        int Encoding;
        bool Done;
        int Total;
        int Current;


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                return;
            }
            if (WorkThread != null)
            {
                if (WorkThread.IsAlive)
                {
                    try
                    {
                        WorkThread.Abort();
                    }
                    catch (Exception) { }
                }
            }
            //Preparing data
            Done = false;
            Encoding = comboBox1.SelectedIndex;
            FolderPath = textBox1.Text;
            FilePath = textBox2.Text;
            Total = 0;
            Current = 0;
            //Starting
            WorkThread = new Thread(Work);
            timer1.Start();
            WorkThread.Start();
        }

        private void Work()
        {
            try
            {
                //Reading fileCount
                string[] files = Directory.GetFiles(FolderPath, "*.txt", SearchOption.AllDirectories);
                Total = files.Length;

                StringBuilder sb = new StringBuilder(10000);
                for (int i = 0; i < Total; i++)
                {
                    try
                    {
                        if (Encoding == 0)
                        {
                            sb.AppendLine(File.ReadAllText(files[i], System.Text.Encoding.Default));
                        }
                        else
                        {
                            sb.AppendLine(File.ReadAllText(files[i], System.Text.Encoding.UTF8));
                        }
                    }
                    catch (Exception) { }
                    Current++;
                }
                //Saving
                try
                {
                    if (Encoding == 0)
                    {
                        File.WriteAllText(FilePath, sb.ToString(), System.Text.Encoding.Default);
                    }
                    else
                    {
                        File.WriteAllText(FilePath, sb.ToString(), System.Text.Encoding.UTF8);
                    }
                }
                catch (Exception) { }
            }
            catch (Exception) { }
            Done = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (WorkThread != null)
            {
                if (WorkThread.IsAlive)
                {
                    try
                    {
                        WorkThread.Abort();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (WorkThread != null)
            {
                if (WorkThread.IsAlive)
                {
                    try
                    {
                        WorkThread.Abort();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Done)
            {
                timer1.Stop();
            }
            try
            {
                progressBar1.Maximum = Total;
                progressBar1.Value = Current;
            }
            catch (Exception)
            {
                progressBar1.Maximum = 0;
                progressBar1.Value = 0;
            }
        }
    }
}
