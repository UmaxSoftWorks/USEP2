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
    public partial class EULAWindow : Form
    {
        public EULAWindow()
        {
            InitializeComponent();
        }

        private void EULACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EULACheckBox.Checked)
            {
                OKButton.Enabled = true;
            }
            else
            {
                OKButton.Enabled = false;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            //Запись в файл
            try
            {
                File.WriteAllText(Application.UserAppDataPath + "\\EULA.txt", "TRUE", Encoding.Default);
            }
            catch (Exception)
            {
            }
            //Закрытие
            Close();
        }

        private void EULAWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!EULACheckBox.Checked)
            {
                //Запись в файл
                try
                {
                    File.WriteAllText(Application.UserAppDataPath + "\\EULA.txt", "FALSE", Encoding.Default);
                }
                catch (Exception)
                {
                }
            }
        }

        private void EULAWindow_Load(object sender, EventArgs e)
        {
            //Чтение файла
            if (!File.Exists(Application.UserAppDataPath + "\\EULA.txt"))
            {
                EULACheckBox.Checked = false;
            }
            else
            {
                try
                {
                    string data = File.ReadAllText(Application.UserAppDataPath + "\\EULA.txt", Encoding.Default);
                    if (data == "TRUE")
                    {
                        EULACheckBox.Checked = true;
                    }
                    else
                    {
                        EULACheckBox.Checked = false;
                    }
                }
                catch (Exception)
                {
                    EULACheckBox.Checked = false;
                }
            }
        }
    }
}
