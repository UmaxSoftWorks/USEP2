using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;

namespace Search_Engines_Parser_2
{
    public partial class KeywordsControl : UserControl
    {
        private WorkData WData;
        private bool ProxyChecks;

        public KeywordsControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            WData = new WorkData();
        }

        /// <summary>
        /// Завершение всех потоков и таймеров
        /// при закрытии таба
        /// </summary>
        public void StopAll()
        {
            //Остановка
            MainTimer.Stop();
            try
            {
                WData.WorkThread.Abort();
                WData.WorkThread = null;
            }
            catch (Exception)
            {
            }
            //Очистка данных
            try
            {
                DataGridView.Rows.Clear();
                WData.Data = string.Empty;
                WData.DataNumbers = string.Empty;
                WData = null;
            }
            catch (Exception)
            {
            }
        }

        //Контекстные меню, начало
        private void LoadProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName == "")
            {
                return;
            }
            ProxyTextBox.Text += File.ReadAllText(OpenFileDialog.FileName, Encoding.Default);
        }

        private void SaveProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = "";
            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName == "")
            {
                return;
            }
            File.WriteAllText(SaveFileDialog.FileName, ProxyTextBox.Text, Encoding.Default);
        }

        private void SelectAllProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProxyTextBox.SelectAll();
        }

        private void ClearProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProxyTextBox.Text = "";
        }

        private void LoadUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName == "")
            {
                return;
            }
            UATextBox.Text += File.ReadAllText(OpenFileDialog.FileName, Encoding.Default);
        }

        private void SaveUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = "";
            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName == "")
            {
                return;
            }
            File.WriteAllText(SaveFileDialog.FileName, UATextBox.Text, Encoding.Default);
        }

        private void SelectAllUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UATextBox.SelectAll();
        }

        private void ClearUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UATextBox.Text = "";
        }
        //Контекстные меню, конец

        private void ProxyUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ProxyUseCheckBox.Checked)
            {
                ProxyTextBox.Enabled = true;
                ProxySwitchUpDown.Enabled = true;
                ProxyCheckStartStopButton.Enabled = true;
            }
            else
            {
                ProxyTextBox.Enabled = false;
                ProxySwitchUpDown.Enabled = false;
                ProxyCheckStartStopButton.Enabled = false;
            }
        }

        private void AskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AskTextBox.Text = "";
            if (AskTypeComboBox.SelectedIndex == 0)
            {
                AskTextBox.Enabled = true;
                SelectAskFileFolderButton.Enabled = false;
            }
            else if (AskTypeComboBox.SelectedIndex == 1)
            {
                AskTextBox.Enabled = false;
                SelectAskFileFolderButton.Enabled = true;
            }
        }

        private void SelectAskFileFolderButton_Click(object sender, EventArgs e)
        {
            AskTextBox.Text = "";
            OpenFileDialog.FileName = "";
            while (OpenFileDialog.FileName == "")
            {
                OpenFileDialog.ShowDialog();
            }
            FolderBrowserDialog.SelectedPath = "";
            while (FolderBrowserDialog.SelectedPath == "")
            {
                FolderBrowserDialog.ShowDialog();
            }
            AskTextBox.Text = OpenFileDialog.FileName + "|#|#|" + FolderBrowserDialog.SelectedPath;
            if (!AskTextBox.Text.EndsWith("\\"))
            {
                AskTextBox.Text += "\\";
            }
        }

        private void ProxyCheckStartStopButton_Click(object sender, EventArgs e)
        {
            if (!ProxyChecks)
            {
                ProxyChecks = true;
                //Скрытие кнопок
                StartButton.Enabled = false;
                StopButton.Enabled = false;
                //Заполнение данных
                WData = new WorkData();
                string[] proxylist = ProxyTextBox.Text.Replace("\r\n", "ç").Split('ç');
                WData.ProxyList = new string[proxylist.Length];
                WData.ProxyCredentials = new string[proxylist.Length, 2];

                for (int i = 0; i < proxylist.Length; i++)
                {
                    string[] proxy = proxylist[i].Split(':');
                    if (proxy.Length == 2)
                    {
                        WData.ProxyList[i] = proxy[0] + ":" + proxy[1];
                        WData.ProxyCredentials[i, 0] = string.Empty;
                        WData.ProxyCredentials[i, 1] = string.Empty;
                    }
                    else if (proxy.Length == 4)
                    {
                        WData.ProxyList[i] = proxy[0] + ":" + proxy[1];
                        WData.ProxyCredentials[i, 0] = proxy[2];
                        WData.ProxyCredentials[i, 1] = proxy[3];
                    }
                    else
                    {
                        WData.ProxyList[i] = string.Empty;
                        WData.ProxyCredentials[i, 0] = string.Empty;
                        WData.ProxyCredentials[i, 1] = string.Empty;
                    }
                }
                //Проверка прокси
                WData.WorkThread = new Thread(ProxyChecking);
                WData.WorkThread.Start();
                MainTimer.Start();
            }
            else
            {
                //Остановка проверки
                MainTimer.Stop();
                try
                {
                    WData.WorkThread.Abort();
                }
                catch (Exception)
                {

                }
                //Отображение результата
                UpdateProxyList();
            }
        }

        private void ProxyChecking()
        {
            WData.CurrentStep = 0;
            WData.TotalSteps = WData.ProxyList.Length;

            for (int i = 0; i < WData.ProxyList.Length; i++)
            {
                if (WData.ProxyList[i] != "")
                {
                    try
                    {
                        WebClient newWebClient = new WebClient();
                        newWebClient.Proxy = new WebProxy("http://" + WData.ProxyList[i] + "/");
                        if (WData.ProxyCredentials[i, 0] != string.Empty && WData.ProxyCredentials[i, 1] != string.Empty)
                        {
                            newWebClient.Proxy.Credentials = new NetworkCredential(WData.ProxyCredentials[i, 0], WData.ProxyCredentials[i, 1]);
                        }
                        string Content = newWebClient.DownloadString("http://ya.ru/");
                    }
                    catch (Exception)
                    {
                        WData.ProxyList[i] = "";
                    }
                }
                WData.CurrentStep++;
            }

            WData.AllDone = true;
        }

        private void UpdateProxyList()
        {
            ProxyChecks = false;
            ProxyTextBox.Text = "";

            for (int i = 0; i < WData.ProxyList.Length; i++)
            {
                if (WData.ProxyList[i] != "")
                {
                    if (WData.ProxyCredentials[i, 0] != string.Empty && WData.ProxyCredentials[i, 1] != string.Empty)
                    {
                        ProxyTextBox.Text += WData.ProxyList[i] + ":" + WData.ProxyCredentials[i, 0] + ":" + WData.ProxyCredentials[i, 1] + "\r\n";
                    }
                    else
                    {
                        ProxyTextBox.Text += WData.ProxyList[i] + "\r\n";
                    }
                }
            }

            if (ProxyTextBox.Text.EndsWith("\r\n"))
            {
                try
                {
                    ProxyTextBox.Text = ProxyTextBox.Text.Substring(0, ProxyTextBox.Text.Length - 2);
                }
                catch (Exception)
                {

                }
            }
            //Отображение кнопок
            StartButton.Enabled = true;
            StopButton.Enabled = true;

        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                StatusToolStripProgressBar.Maximum = WData.TotalSteps;
                StatusToolStripProgressBar.Value = WData.CurrentStep;
                StatusToolStripLabel.Text = WData.CurrentStep.ToString() + "/" + WData.TotalSteps.ToString();
            }
            catch (Exception)
            {

            }
            if (WData.AllDone)
            {
                MainTimer.Stop();

                if (!ProxyChecks)
                {
                    //Вывод даных если это одиночный запрос
                    if (WData.AskType == 0)
                    {
                        FillDataTable();
                    }
                    ProxyCheckStartStopButton.Enabled = true;
                    StartButton.Enabled = true;
                    StopButton.Enabled = false;
                }
                else
                {
                    //Вывод результата
                    UpdateProxyList();
                }
            }
        }

        private void FillDataTable()
        {
            //Разбивка строки с кеями на кеи
            string[] Keys = WData.Data.Replace("\r\n", "ç").Split('ç');
            //Разбивка строки с цифрами на цифры
            string[] KeysNums = WData.DataNumbers.Replace("\r\n", "ç").Split('ç');
            //Очистка таблицы
            DataGridView.Rows.Clear();
            //Заполнение таблицы
            for (int i = 0; i < Keys.Length; i++)
            {
                try
                {
                    if (Keys[i] != "")
                    {
                        DataGridView.Rows.Add();
                        DataGridView.Rows[DataGridView.Rows.Count - 1].Cells[0].Value = Keys[i];
                    }
                }
                catch (Exception)
                {

                }

                try
                {
                    if (KeysNums[i] != "")
                    {
                        DataGridView.Rows[DataGridView.Rows.Count - 1].Cells[1].Value = KeysNums[i];
                    }
                }
                catch (Exception)
                {
                    DataGridView.Rows[DataGridView.Rows.Count - 1].Cells[1].Value = " ";
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (AskTextBox.Text == string.Empty)
            {
                return;
            }
            //Очистка таблицы
            DataGridView.Rows.Clear();

            WData = new WorkData();
            //Сбор и проверка данных
            if (!SECheckBoxComboBox.CheckBoxItems[1].Checked && !SECheckBoxComboBox.CheckBoxItems[2].Checked && !SECheckBoxComboBox.CheckBoxItems[3].Checked && !SECheckBoxComboBox.CheckBoxItems[4].Checked)
            {
                return;
            }
            if (SECheckBoxComboBox.CheckBoxItems[1].Checked)
            {
                WData.SEs += "0";
            }

            if (AskTypeComboBox.SelectedIndex == -1)
            {
                return;
            }
            WData.AskType = AskTypeComboBox.SelectedIndex;

            if (AskEncodingComboBox.SelectedIndex == -1)
            {
                return;
            }
            WData.AskEncoding = AskEncodingComboBox.SelectedIndex;

            if (AskTextBox.Text == "")
            {
                return;
            }
            WData.Ask = AskTextBox.Text;

            if (AskTypeComboBox.SelectedIndex == 0)
            {
                WData.Keywords = new string[] { WData.Ask };
            }
            else
            {
                //Загрузка кеев из файла файла
                try
                {
                    if (WData.AskEncoding == 0)
                    {
                        WData.Keywords = File.ReadAllLines(AskTextBox.Text.Substring(0, AskTextBox.Text.IndexOf("|#|#|")), Encoding.Default);
                    }
                    else
                    {
                        WData.Keywords = File.ReadAllLines(AskTextBox.Text.Substring(0, AskTextBox.Text.IndexOf("|#|#|")), Encoding.UTF8);

                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            //Проверка настроек из табов
            WData.PageNumber = (int)ParsingPagesUpDown.Value;
            WData.Progress = ProgressCheckBox.Checked;
            WData.Trash = TrashCheckBox.Checked;
            WData.Pause = (int)PauseUpDown.Value;

            if (SaveTypeComboBox.SelectedIndex == -1)
            {
                return;
            }
            WData.SaveType = SaveTypeComboBox.SelectedIndex;

            if (SaveEncodingComboBox.SelectedIndex == -1)
            {
                return;
            }
            WData.SaveEncoding = SaveEncodingComboBox.SelectedIndex;

            if (SaveSplitterTextBox.Text == "")
            {
                return;
            }
            WData.SaveSplitter = SaveSplitterTextBox.Text;

            WData.Proxy = ProxyUseCheckBox.Checked;
            WData.ProxySwitch = (int)ProxySwitchUpDown.Value;

            string[] proxylist = ProxyTextBox.Text.Replace("\r\n", "ç").Split('ç');
            WData.ProxyList = new string[proxylist.Length];
            WData.ProxyCredentials = new string[proxylist.Length, 2];

            for (int i = 0; i < proxylist.Length; i++)
            {
                string[] proxy = proxylist[i].Split(':');
                if (proxy.Length == 2)
                {
                    WData.ProxyList[i] = proxy[0] + ":" + proxy[1];
                    WData.ProxyCredentials[i, 0] = string.Empty;
                    WData.ProxyCredentials[i, 1] = string.Empty;
                }
                else if (proxy.Length == 4)
                {
                    WData.ProxyList[i] = proxy[0] + ":" + proxy[1];
                    WData.ProxyCredentials[i, 0] = proxy[2];
                    WData.ProxyCredentials[i, 1] = proxy[3];
                }
                else
                {
                    WData.ProxyList[i] = string.Empty;
                    WData.ProxyCredentials[i, 0] = string.Empty;
                    WData.ProxyCredentials[i, 1] = string.Empty;
                }
            }


            WData.UASwitch = (int)UASwitchUpDown.Value;
            WData.UARandom = UAUseRandomCheckBox.Checked;
            WData.UAList = UATextBox.Text.Replace("\r\n", "ç").Split('ç');

            //Скрытие кнопок
            ProxyCheckStartStopButton.Enabled = false;
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            //Запуск
            WData.WorkThread = new Thread(Work);
            WData.WorkThread.Start();
            MainTimer.Start();
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveEncodingComboBox.SelectedIndex == -1)
            {
                return;
            }
            if (SaveTypeComboBox.SelectedIndex == -1)
            {
                return;
            }

            SaveFileDialog.FileName = "";
            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName == "")
            {
                return;
            }

            string data = "";
            for (int i = 0; i < DataGridView.Rows.Count; i++)
            {
                try
                {
                    if (SaveTypeComboBox.SelectedIndex == 0)
                    {
                        data += DataGridView.Rows[i].Cells[0].Value.ToString() + WData.SaveSplitter.Replace("[TAB]","\t").Replace("[ENTER]","\r\n") + DataGridView.Rows[i].Cells[1].Value.ToString() + "\r\n";
                    }
                    else
                    {
                        data += DataGridView.Rows[i].Cells[0].Value.ToString() + "\r\n";
                    }
                }
                catch (Exception)
                {
                }
            }

            if (SaveEncodingComboBox.SelectedIndex == 0)
            {
                File.WriteAllText(SaveFileDialog.FileName, data, Encoding.Default);
            }
            else
            {
                File.WriteAllText(SaveFileDialog.FileName, data, Encoding.UTF8);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            //Остановка
            try
            {
                WData.WorkThread.Abort();
            }
            catch (Exception)
            {

            }
            WData.AllDone = true;
        }

        private void Work()
        {
            //Подготовка
            WData.CurrentStep = 0;
            WData.CurrentProxy = 0;
            WData.CurrentUA = 0;

            //Счетчики для смены прокси/УА
            int ProxyTick = 0;
            int UATick = 0;

            //Расчет кол-ва шагов
            WData.TotalSteps = 0;
            if (WData.SEs.Contains("0"))
            {
                WData.TotalSteps += WData.Keywords.Length * WData.PageNumber;
            }
            if (WData.SEs.Contains("1"))
            {
                WData.TotalSteps += WData.Keywords.Length * WData.PageNumber;
            }

            //Работа

            for (int i = 0; i < WData.Keywords.Length; i++)
            {
                if (WData.SEs.Contains("0"))//Десент
                {
                    for (int j = 0; j < WData.PageNumber; j++)
                    {
                        string keywords = string.Empty;
                        string keywordsNums = string.Empty;

                        //Скачивание и парсинг
                        DownloadAndParseDecent(WData.Keywords[i], j, ref ProxyTick, ref UATick, ref keywords, ref keywordsNums);

                        //Прогрессивный парсинг
                        if (WData.Progress && keywords != string.Empty)
                        {
                            string[] keys = keywords.Replace("\r\n", "ç").Split('ç');

                            //Сохранение
                            if (WData.AskType == 0)
                            {
                                AddCurrentDataToMainData(ref keywords, ref keywordsNums);
                            }
                            else
                            {
                                SaveDataToFile(WData.Keywords[i], ref keywords, ref keywordsNums);
                            }

                            //Очистка
                            keywords = string.Empty;
                            keywordsNums = string.Empty;

                            for (int k = 0; k < keys.Length; k++)
                            {
                                DownloadAndParseDecent(keys[k], 0, ref ProxyTick, ref UATick, ref keywords, ref keywordsNums);

                                //Сохранение
                                if (WData.AskType == 0)
                                {
                                    AddCurrentDataToMainData(ref keywords, ref keywordsNums);
                                }
                                else
                                {
                                    SaveDataToFile(WData.Keywords[i], ref keywords, ref keywordsNums);
                                }

                                Thread.Sleep(WData.Pause * 1000);
                            }
                        }
                        else
                        {
                            //Сохранение
                            if (WData.AskType == 0)
                            {
                                AddCurrentDataToMainData(ref keywords, ref keywordsNums);
                            }
                            else
                            {
                                SaveDataToFile(WData.Keywords[i], ref keywords, ref keywordsNums);
                            }
                            Thread.Sleep(WData.Pause * 1000);
                        }
                        WData.CurrentStep++;
                    }
                }
            }

            WData.AllDone = true;
        }

        /// <summary>
        /// Запись данных в файл
        /// </summary>
        /// <param name="Keyword"></param>
        /// <param name="Keywords"></param>
        /// <param name="KeywordsNums"></param>
        private void SaveDataToFile(string Keyword, ref string Keywords, ref string KeywordsNums)
        {
            try
            {
                //Подготовка данных
                string[] keys = Keywords.Replace("\r\n", "ç").Split('ç');
                string[] keysNums = KeywordsNums.Replace("\r\n", "ç").Split('ç');
                string data = string.Empty;
                for (int i = 0; i < keys.Length; i++)
                {
                    try
                    {
                        if (WData.SaveType == 0)
                        {
                            if (keys[i] != "" || keysNums[i] != "")
                            {
                                data += keys[i] + WData.SaveSplitter.Replace("[TAB]", "\t").Replace("[ENTER]", "\r\n") + keysNums[i] + "\r\n";
                            }
                        }
                        else
                        {
                            if (keys[i] != "")
                            {
                                data += keys[i] + "\r\n";
                            }
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                //Запись
                if (WData.SaveEncoding == 0)
                {
                    File.AppendAllText(WData.Ask.Substring(WData.Ask.IndexOf("|#|#|") + 5) + Keyword.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("\t", "") + ".txt", data, Encoding.Default);
                }
                else
                {
                    File.AppendAllText(WData.Ask.Substring(WData.Ask.IndexOf("|#|#|") + 5) + Keyword.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("\t", "") + ".txt", data, Encoding.UTF8);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Добавление входных данных в основные данные и очистка входных
        /// </summary>
        /// <param name="Keywords">Кейворды</param>
        /// <param name="KeywordsNums">Цифры к кейвордам</param>
        private void AddCurrentDataToMainData(ref string Keywords, ref string KeywordsNums)
        {
            //Добавление кеев и номеров в поля
            WData.Data += Keywords;
            WData.DataNumbers += KeywordsNums;

            Keywords = string.Empty;
            KeywordsNums = string.Empty;
        }

        private string DownloadPage(string Url, ref int ProxyTick, ref int UATick)
        {
            //Переменные
            Random Rand = new Random(DateTime.Now.Millisecond);
            //Подготовка
            if (WData.Proxy)
            {
                if (ProxyTick > WData.ProxySwitch)
                {
                    if ((WData.CurrentProxy + 1) < WData.ProxyList.Length)
                    {
                        WData.CurrentProxy++;
                    }
                    else
                    {
                        WData.CurrentProxy = 0;
                    }
                }
            }
            else
            {
                ProxyTick = 0;
            }
            if (WData.UAList.Length == 1 && WData.UAList[0] == "")
            {
                UATick = 0;
            }
            else
            {
                if (UATick > WData.UASwitch)
                {
                    if (WData.UARandom)
                    {
                        try
                        {
                            WData.CurrentUA = Rand.Next(0, WData.UAList.Length - 1);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        if ((WData.CurrentUA + 1) < WData.UAList.Length)
                        {
                            try
                            {
                                WData.CurrentUA++;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                WData.CurrentUA = 0;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    UATick = 0;
                }
            }

            //Если не яндекс
            try
            {
                WebClient newWebClient = new WebClient();
                if (WData.Proxy)
                {
                    newWebClient.Proxy = new WebProxy("http://" + WData.ProxyList[WData.CurrentProxy] + "/");
                    if (WData.ProxyCredentials[WData.CurrentProxy, 0] != string.Empty && WData.ProxyCredentials[WData.CurrentProxy, 1] != string.Empty)
                    {
                        newWebClient.Proxy.Credentials = new NetworkCredential(WData.ProxyCredentials[WData.CurrentProxy, 0], WData.ProxyCredentials[WData.CurrentProxy, 1]);
                    }
                }
                if (WData.UAList.Length != 1 && WData.UAList[0] != "")
                {
                    newWebClient.Headers.Add("user-agent", WData.UAList[WData.CurrentUA]);
                }
                return newWebClient.DownloadString(Url);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private string StringToUTF8Codes(string Text)
        {
            string outText = string.Empty;
            byte[] encoded;
            //перекодинг
            encoded = Encoding.UTF8.GetBytes(Text);

            for (int i = 0; i < encoded.Length; i++)
            {
                outText += "%" + encoded[i].ToString("X");
            }
            return outText;
        }

        private void DownloadAndParseDecent(string Keyword, int PageNumber, ref int ProxyTick, ref int UATick, ref string Keywords, ref string KeywordsNums)
        {
            string page = string.Empty;
            //Скачивание страницы
            try
            {
                if (WData.AskEncoding == 0)
                {
                    page = DownloadPage("http://www.decenttools.com/aol/keyword/" + Keyword.Replace(" ", "%20") + "?pageID=" + (PageNumber + 1).ToString(), ref ProxyTick, ref UATick);
                }
                else
                {
                    page = DownloadPage("http://www.decenttools.com/aol/keyword/" + StringToUTF8Codes(Keyword.Replace(" ", "%20")) + "?pageID=" + (PageNumber + 1).ToString(), ref ProxyTick, ref UATick);
                }
            }
            catch (Exception)
            {
            }
            //Парсинг
            ParseDecent(page, ref Keywords, ref KeywordsNums);
        }

        private void ParseDecent(string Page, ref string Keywords, ref string KeywordsNums)
        {
            try
            {
                if (Page.Contains("<td class=\"tal\"><a href=\"http://www.decenttools.com/aol/keyword/"))
                {
                    Page = Page.Substring(Page.IndexOf("<td class=\"tal\"><a href=\"http://www.decenttools.com/aol/keyword/"));
                    //Парсинг ключей
                    do
                    {
                        if (!Page.Contains("<td class=\"tal\"><a href=\"http://www.decenttools.com/aol/keyword/"))
                        {
                            break;
                        }
                        Page = Page.Substring(Page.IndexOf("<td class=\"tal\"><a href=\"http://www.decenttools.com/aol/keyword/") + 64);

                        if (!Page.Contains("\">"))
                        {
                            break;
                        }
                        //Парсинг кеев
                        Keywords += Page.Substring(0, Page.IndexOf("\">")) + "\r\n";
                        Page = Page.Substring(Page.IndexOf("</a>") + 4);
                        //Парсинг числа
                        try
                        {
                            KeywordsNums += Page.Substring(Page.IndexOf("<td>") + 4, Page.IndexOf("</td>", Page.IndexOf("<td>")) - Page.IndexOf("<td>") - 4) + "\r\n";
                        }
                        catch (Exception)
                        {
                            KeywordsNums += " \r\n";
                        }
                    } while (Page.Contains("\">"));
                }
            }
            catch (Exception)
            {
            }
        }

        //Загрузка списка прокси и УА
        private void KeywordsControl_Load(object sender, EventArgs e)
        {
            AskTypeComboBox.SelectedIndex = 0;
            AskEncodingComboBox.SelectedIndex = 0;

            SaveTypeComboBox.SelectedIndex = 0;
            SaveEncodingComboBox.SelectedIndex = 0;
            //Прокси
            if (File.Exists("Proxy.txt"))
            {
                try
                {
                    ProxyTextBox.Text = File.ReadAllText("Proxy.txt", Encoding.Default);
                }
                catch (Exception)
                {
                }
            }
            //УА
            if (File.Exists("UA.txt"))
            {
                try
                {
                    UATextBox.Text = File.ReadAllText("UA.txt", Encoding.Default);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
