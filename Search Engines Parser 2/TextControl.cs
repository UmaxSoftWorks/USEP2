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
using System.Text.RegularExpressions;

namespace Search_Engines_Parser_2
{
    public partial class TextControl : UserControl
    {
        private WorkData WData;
        private bool ProxyChecks;

        public TextControl()
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
                TextTextBox.Text = string.Empty;
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
        private void ZonesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZonesCheckBox.Checked)
            {
                ZonesTextBox.Enabled = true;
            }
            else
            {
                ZonesTextBox.Enabled = false;
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
                        TextTextBox.Text = WData.Data;
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

        private void AskTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveEncodingComboBox.SelectedIndex == -1)
            {
                return;
            }

            SaveFileDialog.FileName = "";
            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName == "")
            {
                return;
            }

            if (SaveEncodingComboBox.SelectedIndex == 0)
            {
                File.WriteAllText(SaveFileDialog.FileName, TextTextBox.Text, Encoding.Default);
            }
            else
            {
                File.WriteAllText(SaveFileDialog.FileName, TextTextBox.Text, Encoding.UTF8);
            }
        }

        private void ParsingPagesUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Установка макс. значения для парсинга
            if (SECheckBoxComboBox.CheckBoxItems[3].Checked || SECheckBoxComboBox.CheckBoxItems[4].Checked)
            {
                ParsingPagesUpDown.Maximum = 20;
            }
            else
            {
                ParsingPagesUpDown.Maximum = 10;
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



        private void StartButton_Click(object sender, EventArgs e)
        {
            if (AskTextBox.Text == string.Empty)
            {
                return;
            }
            //Очистка таблицы
            TextTextBox.Text = "";

            WData = new WorkData();
            //Сбор и проверка данных
            if (!SECheckBoxComboBox.CheckBoxItems[1].Checked && !SECheckBoxComboBox.CheckBoxItems[2].Checked)
            {
                return;
            }
            if (SECheckBoxComboBox.CheckBoxItems[1].Checked)
            {
                WData.SEs += "0";
            }
            if (SECheckBoxComboBox.CheckBoxItems[2].Checked)
            {
                WData.SEs += "1";
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
            WData.Pause = (int)PauseUpDown.Value;

            WData.Zones = ZonesCheckBox.Checked;

            if (ZonesCheckBox.Checked && ZonesTextBox.Text == "")
            {
                return;
            }
            WData.ZonesList = ZonesTextBox.Text.Split(' ');

            if (SaveEncodingComboBox.SelectedIndex == -1)
            {
                return;
            }
            WData.SaveEncoding = SaveEncodingComboBox.SelectedIndex;

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
            //Filter
            WData.Filter = filterCheckBox.Checked;
            WData.FilterLength = (int)filterNumericUpDown.Value;
            WData.FilterType = filterComboBox.SelectedIndex;

            //Скрытие кнопок
            ProxyCheckStartStopButton.Enabled = false;
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            //Запуск
            WData.WorkThread = new Thread(Work);
            WData.WorkThread.Start();
            MainTimer.Start();
        }

        private void Work()
        {
            //Подготовка
            WData.CurrentStep = 0;
            WData.CurrentProxy = 0;
            WData.CurrentUA = 0;

            if (!WData.Zones)
            {
                WData.ZonesList = new string[] { "default" };
            }

            //Счетчики для смены прокси/УА
            int ProxyTick = 0;
            int UATick = 0;

            //Расчет кол-ва шагов
            WData.TotalSteps = 0;
            if (WData.SEs.Contains("0"))
            {
                if (WData.PageNumber < 10)
                {
                    if (WData.Zones)
                    {
                        WData.TotalSteps += WData.Keywords.Length * WData.PageNumber * WData.ZonesList.Length;
                    }
                    else
                    {
                        WData.TotalSteps += WData.Keywords.Length * WData.PageNumber;
                    }
                }
                else
                {
                    if (WData.Zones)
                    {
                        WData.TotalSteps += WData.Keywords.Length * 10 * WData.ZonesList.Length;
                    }
                    else
                    {
                        WData.TotalSteps += WData.Keywords.Length * 10;
                    }
                }
            }
            if (WData.SEs.Contains("1"))
            {
                if (WData.PageNumber < 10)
                {
                    if (WData.Zones)
                    {
                        WData.TotalSteps += WData.Keywords.Length * WData.PageNumber * WData.ZonesList.Length;
                    }
                    else
                    {
                        WData.TotalSteps += WData.Keywords.Length * WData.PageNumber;
                    }
                }
                else
                {
                    if (WData.Zones)
                    {
                        WData.TotalSteps += WData.Keywords.Length * 10 * WData.ZonesList.Length;
                    }
                    else
                    {
                        WData.TotalSteps += WData.Keywords.Length * 10;
                    }
                }
            }
            if (WData.SEs.Contains("2"))
            {
                if (WData.Zones)
                {
                    WData.TotalSteps += WData.Keywords.Length * WData.PageNumber * WData.ZonesList.Length;
                }
                else
                {
                    WData.TotalSteps += WData.Keywords.Length * WData.PageNumber;
                }
            }

            //Работа

            for (int i = 0; i < WData.Keywords.Length; i++)
            {
                if (WData.SEs.Contains("0"))//Гугл
                {
                    for (int k = 0; k < WData.ZonesList.Length; k++)
                    {
                        if (WData.ZonesList[k] == "")
                        {
                            WData.CurrentStep += WData.PageNumber;
                            continue;
                        }
                        bool canContinue = true;
                        for (int j = 0; j < WData.PageNumber; j++)
                        {
                            if (j >= 10)
                            {
                                break;
                            }
                            if (canContinue)
                            {
                                string data = string.Empty;

                                //Скачивание и парсинг
                                DownloadAndParseGoogle(WData.Keywords[i], j, WData.ZonesList[k], ref ProxyTick, ref UATick, ref data, ref canContinue);

                                //Скачивание страниц
                                string[] sites = data.Replace("\r\n", "ç").Split('ç');
                                for (int p = 0; p < sites.Length; p++)
                                {
                                    data = DownloadSitePage(sites[p]);
                                    //Сохранение
                                    if (WData.AskType == 0)
                                    {
                                        AddCurrentDataToMainData(ref data);
                                    }
                                    else
                                    {
                                        SaveDataToFile(WData.Keywords[i], ref data);
                                    }
                                }

                                Thread.Sleep(WData.Pause * 1000);
                            }
                            WData.CurrentStep++;
                        }
                    }
                }
                if (WData.SEs.Contains("1"))//Яху
                {
                    for (int k = 0; k < WData.ZonesList.Length; k++)
                    {
                        if (WData.ZonesList[k] == "")
                        {
                            WData.CurrentStep += WData.PageNumber;
                            continue;
                        }
                        bool canContinue = true;
                        for (int j = 0; j < WData.PageNumber; j++)
                        {
                            if (j >= 10)
                            {
                                break;
                            }
                            if (canContinue)
                            {
                                string data = string.Empty;

                                //Скачивание и парсинг
                                DownloadAndParseYahoo(WData.Keywords[i], j, WData.ZonesList[k], ref ProxyTick, ref UATick, ref data, ref canContinue);

                                //Скачивание страниц
                                string[] sites = data.Replace("\r\n", "ç").Split('ç');
                                for (int p = 0; p < sites.Length; p++)
                                {
                                    data = DownloadSitePage(sites[p]);
                                    //Сохранение
                                    if (WData.AskType == 0)
                                    {
                                        AddCurrentDataToMainData(ref data);
                                    }
                                    else
                                    {
                                        SaveDataToFile(WData.Keywords[i], ref data);
                                    }
                                }

                                Thread.Sleep(WData.Pause * 1000);
                            }
                            WData.CurrentStep++;
                        }
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
        private void SaveDataToFile(string Keyword, ref string Data)
        {
            try
            {
                //Запись
                if (WData.SaveEncoding == 0)
                {
                    File.AppendAllText(WData.Ask.Substring(WData.Ask.IndexOf("|#|#|") + 5) + Keyword.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("\t", "") + ".txt", Data, Encoding.Default);
                }
                else
                {
                    File.AppendAllText(WData.Ask.Substring(WData.Ask.IndexOf("|#|#|") + 5) + Keyword.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("\t", "") + ".txt", Data, Encoding.UTF8);
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
        private void AddCurrentDataToMainData(ref string Data)
        {
            //Добавление кеев и номеров в поля
            WData.Data += Data;

            Data = string.Empty;
        }

        string YandexCookies;
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

            //Скачивание страницы
            try
            {
                if (Url.Contains("yandex"))
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);

                    if (WData.Proxy)
                    {
                        req.Proxy = new WebProxy("http://" + WData.ProxyList[WData.CurrentProxy] + "/");
                        if (WData.ProxyCredentials[WData.CurrentProxy, 0] != string.Empty && WData.ProxyCredentials[WData.CurrentProxy, 1] != string.Empty)
                        {
                            req.Proxy.Credentials = new NetworkCredential(WData.ProxyCredentials[WData.CurrentProxy, 0], WData.ProxyCredentials[WData.CurrentProxy, 1]);
                        }
                    }
                    req.AllowAutoRedirect = false;
                    if (WData.UAList.Length != 1 && WData.UAList[0] != "")
                    {
                        req.UserAgent = WData.UAList[WData.CurrentUA];
                    }
                    req.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/jpeg, image/gif, image/x-xbitmap";
                    req.Headers.Add("Accept-Language", "ru");

                    if (!string.IsNullOrEmpty(YandexCookies))
                    {
                        req.Headers.Add(HttpRequestHeader.Cookie, YandexCookies);
                    }
                    HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                    StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.Default);

                    string newLocation = response.Headers["Location"];

                    if (string.IsNullOrEmpty(YandexCookies))
                    {
                        YandexCookies = response.Headers["Set-Cookie"];
                    }
                    string page = responseStream.ReadToEnd();
                    response.Close();
                    responseStream.Close();

                    if (!string.IsNullOrEmpty(newLocation))
                    {
                        req = (HttpWebRequest)WebRequest.Create(newLocation);

                        if (WData.Proxy)
                        {
                            req.Proxy = new WebProxy("http://" + WData.ProxyList[WData.CurrentProxy] + "/");
                            if (WData.ProxyCredentials[WData.CurrentProxy, 0] != string.Empty && WData.ProxyCredentials[WData.CurrentProxy, 1] != string.Empty)
                            {
                                req.Proxy.Credentials = new NetworkCredential(WData.ProxyCredentials[WData.CurrentProxy, 0], WData.ProxyCredentials[WData.CurrentProxy, 1]);
                            }
                        }
                        req.AllowAutoRedirect = true;
                        if (WData.UAList.Length != 1 && WData.UAList[0] != "")
                        {
                            req.UserAgent = WData.UAList[WData.CurrentUA];
                        }
                        req.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/jpeg, image/gif, image/x-xbitmap";
                        req.Headers.Add("Accept-Language", "ru");

                        if (!string.IsNullOrEmpty(YandexCookies))
                        {
                            req.Headers.Add(HttpRequestHeader.Cookie, YandexCookies);
                        }
                        response = (HttpWebResponse)req.GetResponse();
                        responseStream = new StreamReader(response.GetResponseStream(), Encoding.Default);

                        if (string.IsNullOrEmpty(YandexCookies))
                        {
                            YandexCookies = response.Headers["Set-Cookie"];
                        }
                        page = responseStream.ReadToEnd();
                        response.Close();
                        responseStream.Close();
                    }

                    return page;
                }
                else
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
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private Encoding GetWebPageContentEncoding(string content)
        {
            //перекодировка
            //if (UFT8String(ref content))
            //{
            //byte[] encoded = newWebClient.Encoding.GetBytes(content);
            //content = Encoding.UTF8.GetString(Encoding.GetEncoding(newWebClient.Encoding.EncodingName).GetBytes(content));

            Encoding encoding = null;
            Regex regex = new Regex("<meta http-equiv=\"content-type\" content=\"text/html; charset=([a-zA-z0-9\\-]+)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (regex.IsMatch(content))
            {
                try
                {
                    string encodingstring = regex.Match(content).Groups[1].Value;
                    encoding = Encoding.GetEncoding(encodingstring);
                }
                catch (Exception) { }
            }

            return encoding;

        }

        private char[] blackList = new char[] { 'è', 'Ï', 'ð', 'è', 'ê', 'þ', 'ÿ', 'Ï', 'à', 'ç', 'û', 'â', 'à', 'ò', 'è', 'ä', 'å', 'ì', 'î', 'Ê', 'Ћ', '†', 'Њ', 'Џ', 'ђ','љ' };

        private string ClearString(string content)
        {
            if (content.Any(c => blackList.Contains(c)))
            {
                return string.Empty;
            }

            return content;
        }

        private Encoding GetCharacterSet(string s)
        {
            s = s.ToUpper();
            int start = s.LastIndexOf("CHARSET");
            if (start == -1)
                throw new Exception("Can't parse encoding");

            start = s.IndexOf("=", start);
            if (start == -1)
                throw new Exception("Can't parse encoding");

            start++;
            s = s.Substring(start).Trim();
            int end = s.Length;

            int i = s.IndexOf(";");
            if (i != -1)
                end = i;
            i = s.IndexOf("\"");
            if (i != -1 && i < end)
                end = i;
            i = s.IndexOf("'");
            if (i != -1 && i < end)
                end = i;
            i = s.IndexOf("/");
            if (i != -1 && i < end)
                end = i;

            return Encoding.GetEncoding(s.Substring(0, end).Trim());
        }

        private string DownloadSitePage(string Url)
        {
            try
            {
                if (!Url.StartsWith("http"))
                {
                    Url = "http://" + Url;
                }
                //WebClient newWebClient = new WebClient();
                //newWebClient.Encoding = Encoding.UTF8;

                string content = string.Empty;
                Encoding enc = null;

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Url);

                //if (WData.UAList.Length != 1 && WData.UAList[0] != "")
                //{
                    //newWebClient.Headers.Add("user-agent", WData.UAList[0]);
                //}

                //string content = newWebClient.DownloadString(Url);

                using(HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                {
                    enc = (!string.IsNullOrEmpty(myHttpWebResponse.ContentEncoding)
                               ? Encoding.GetEncoding(myHttpWebResponse.ContentEncoding)
                               : (!string.IsNullOrEmpty(myHttpWebResponse.CharacterSet) ? Encoding.GetEncoding(myHttpWebResponse.CharacterSet) : (Encoding) null));

                    using (StreamReader loResponseStream = new
                        StreamReader(myHttpWebResponse.GetResponseStream(), enc ?? GetCharacterSet(myHttpWebResponse.ContentType)))
                    {
                        content = loResponseStream.ReadToEnd();
                    }
                }

                // Cleaning
                try
                {
                    content = ClearString(content);

                    //Удаление стилей и скриптов)
                    while (content.Contains("<style") && content.Contains("</style>"))
                    {
                        content = content.Remove(content.IndexOf("<style"), content.IndexOf("</style>", content.IndexOf("<style")) + 8 - content.IndexOf("<style"));
                    }
                    while (content.Contains("<script") && content.Contains("</script>"))
                    {
                        content = content.Remove(content.IndexOf("<script"), content.IndexOf("</script>", content.IndexOf("<script")) + 9 - content.IndexOf("<script"));
                    }

                    while (content.Contains("<STYLE") && content.Contains("</STYLE>"))
                    {
                        content = content.Remove(content.IndexOf("<STYLE"), content.IndexOf("</STYLE>", content.IndexOf("<STYLE")) + 8 - content.IndexOf("<STYLE"));
                    }
                    while (content.Contains("<SCRIPT") && content.Contains("</SCRIPT>"))
                    {
                        content = content.Remove(content.IndexOf("<SCRIPT"), content.IndexOf("</SCRIPT>", content.IndexOf("<SCRIPT")) + 9 - content.IndexOf("<SCRIPT"));
                    }

                    Regex myReg = new Regex("<[\\/\\!]*?[^<>]*?>", RegexOptions.IgnoreCase);
                    content = myReg.Replace(content, "");
                    //уборка лишних пробелов
                    myReg = new Regex("\\x20+");
                    content = myReg.Replace(content, " ");
                    //уборка функций
                    while (content.Contains("function"))
                    {
                        try
                        {
                            content = content.Remove(content.IndexOf("function"), content.IndexOf("}", content.IndexOf("function")) + 1 - content.IndexOf("function"));
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    //уборка табов и переходов на новую строку
                    while (content.Contains("\t\t"))
                    {
                        content = content.Replace("\t\t", "\t");
                    }
                    while (content.Contains("\t\r\n"))
                    {
                        content = content.Replace("\t\r\n", "\r\n");
                    }
                    while (content.Contains("\r\n\t"))
                    {
                        content = content.Replace("\r\n\t", "\r\n");
                    }
                    while (content.Contains("\r\n\r\n"))
                    {
                        content = content.Replace("\r\n\r\n", "\r\n");
                    }

                    //уборка комментариев
                    while (content.Contains("<!--"))
                    {
                        try
                        {
                            content = content.Remove(content.IndexOf("<!--"), content.IndexOf("-->", content.IndexOf("<!--")) + 3 - content.IndexOf("<!--"));
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }

                    while (content.Contains("@import url"))
                    {
                        try
                        {
                            content = content.Remove(content.IndexOf("@import url"), content.IndexOf(";", content.IndexOf("@import url")) + 1 - content.IndexOf("@import url"));
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }

                    while (content.Contains("&nbsp;"))
                    {
                        content = content.Replace("&nbsp;", " ");
                    }
                    while (content.Contains(" \r\n"))
                    {
                        content = content.Replace(" \r\n", "\r\n");
                    }

                    //уборка табов и переходов на новую строку
                    while (content.Contains("\t\r\n"))
                    {
                        content = content.Replace("\t\r\n", "\r\n");
                    }
                    while (content.Contains("\t\t"))
                    {
                        content = content.Replace("\t\t", "\t");
                    }
                    while (content.Contains("\r\n\r\n"))
                    {
                        content = content.Replace("\r\n\r\n", "\r\n");
                    }
                    while (content.Contains("//"))
                    {
                        content = content.Replace("//", "");
                    }

                    //уборка лишних пробелов
                    myReg = new Regex("\\x20+");
                    content = myReg.Replace(content, " ");

                    //filtering
                    content = FilterString(content);
                }
                catch (Exception)
                {
                    content = string.Empty;
                }

                return content;

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private string FilterString(string Content)
        {
            if (WData.Filter)
            {
                if (WData.FilterType == 0)
                {
                    if (Content.Length >= WData.FilterLength)
                    {
                        return Content;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    if (Content.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Length >= WData.FilterLength)
                    {
                        return Content;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                return Content;
            }
        }

        private bool UFT8String(ref string Content)
        {
            if (Content.Contains("UTF-8") || Content.Contains("utf-8"))
            {
                int cpos = 0;
                int hpos = 0;

                if (Content.Contains("UTF-8"))
                {
                    cpos = Content.IndexOf("UTF-8");
                }
                if (Content.Contains("utf-8"))
                {
                    cpos = Content.IndexOf("utf-8");
                }

                if (Content.Contains("</HEAD>"))
                {
                    hpos = Content.IndexOf("</HEAD>");
                }
                if (Content.Contains("</head>"))
                {
                    hpos = Content.IndexOf("</head>");
                }

                if (hpos > cpos)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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

        private string StringToANSICodes(string Text)
        {
            string outText = string.Empty;
            byte[] encoded;
            //перекодинг
            encoded = Encoding.Default.GetBytes(Text);

            for (int i = 0; i < encoded.Length; i++)
            {
                outText += "%" + encoded[i].ToString("X");
            }
            return outText;
        }

        private void DownloadAndParseYahoo(string Keyword, int PageNumber, string Zone, ref int ProxyTick, ref int UATick, ref string Data, ref bool CanContinue)
        {
            string page = string.Empty;
            //Скачивание страницы
            if (WData.Zones)
            {
                try
                {
                    if (WData.AskEncoding == 0)
                    {
                        page = DownloadPage("http://search.yahoo.com/search?p=" + Keyword.Replace(" ", "+") + "+domain%3A" + Zone + "&n=100&pstart=1&b=" + (PageNumber * 100 + 1).ToString(), ref ProxyTick, ref UATick);
                    }
                    else
                    {
                        page = DownloadPage("http://search.yahoo.com/search?ei=UTF-8&p=" + StringToUTF8Codes(Keyword.Replace(" ", "+")) + "+domain%3A" + Zone + "&n=100&pstart=1&b=" + (PageNumber * 100 + 1).ToString(), ref ProxyTick, ref UATick);
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                if (WData.AskEncoding == 0)
                {
                    page = DownloadPage("http://search.yahoo.com/search?p=" + Keyword.Replace(" ", "+") + "&n=100&pstart=1&b=" + (PageNumber * 100 + 1).ToString(), ref ProxyTick, ref UATick);
                }
                else
                {
                    page = DownloadPage("http://search.yahoo.com/search?ei=UTF-8&p=" + StringToUTF8Codes(Keyword.Replace(" ", "+")) + "&n=100&pstart=1&b=" + (PageNumber * 100 + 1).ToString(), ref ProxyTick, ref UATick);
                }
            }
            //Парсинг
            ParseYahoo(page, PageNumber, ref Data, ref CanContinue);
        }

        private void ParseYahoo(string Page, int PageNumber, ref string Data, ref bool CanContinue)
        {
            try
            {
                string tempString = string.Empty;
                if (Page.Contains("class=\"yschttl spt\" href=\""))
                {
                    Page = Page.Replace(" lang=\"ru\"", "").Replace(" lang=\"es\"", "").Replace(" lang=\"de\"", "").Replace(" lang=\"fr\"", "").Replace(" lang=\"pt\"", "").Replace(" lang=\"it\"", "")
                        .Replace(" lang=\"zt\"", "").Replace(" lang=\"ja\"", "").Replace(" lang=\"nl\"", "").Replace(" lang=\"zh\"", "");
                    do
                    {
                        Page = Page.Substring(Page.IndexOf("class=\"yschttl spt\" href=\""));
                        if (!Page.Contains("class=\"yschttl spt\" href=\""))
                        {
                            break;
                        }
                        try
                        {
                            if (Page.Contains("\">") && Page.Contains("\" >") && Page.IndexOf("\" >") < Page.IndexOf("\">"))
                            {
                                tempString = Page.Substring(Page.IndexOf("href=\"http://") + 13, Page.IndexOf("\" >", Page.IndexOf("href=\"http://")) - Page.IndexOf("href=\"http://") - 13) + "\r\n";
                            }
                            else
                            {
                                tempString = Page.Substring(Page.IndexOf("href=\"") + 6, Page.IndexOf("\">", Page.IndexOf("href=\"")) - Page.IndexOf("href=\"") - 6) + "\r\n";
                            }
                        }
                        catch (Exception)
                        {

                        }
                        if (tempString.Contains("yahoo.com") || tempString.Contains("/r/"))
                        {
                            try
                            {
                                if (tempString.Contains("?p="))
                                {
                                    tempString = tempString.Substring(tempString.LastIndexOf("?p=") + 3);
                                    tempString = tempString.Replace("&bwmf=u", string.Empty).Replace("&bwms=p", string.Empty).Replace("&bwmf=s", string.Empty);
                                }

                                if (tempString.Contains("**http%3a//"))
                                {
                                    tempString = tempString.Substring(tempString.LastIndexOf("**http%3a//") + 11);
                                }
                                else if (tempString.Contains("**https%3a//"))
                                {
                                    tempString = tempString.Substring(tempString.LastIndexOf("**https%3a//") + 12);
                                }
                                else if (tempString.Contains("http://"))
                                {
                                    tempString = tempString.Substring(tempString.LastIndexOf("http://") + 7);
                                }
                            }
                            catch (Exception)
                            {
                                tempString = "";
                            }
                        }

                        if (tempString.Contains("\" data-"))
                        {
                            tempString = tempString.Substring(0, tempString.IndexOf("\" data-")) + "\r\n";
                        }


                        if (!tempString.Contains("yahoo.com"))
                        {
                            tempString = tempString.Replace("%3F", "?").Replace("%3D", "=").Replace("%26", "&").Replace("%2F", "/").Replace("%2520", "_");

                            if (tempString.Contains("\" data-"))
                            {
                                tempString = tempString.Substring(0, tempString.IndexOf("\" data-")) + "\r\n";
                            }

                            if (tempString.Contains("\"target=\"_blank"))
                            {
                                tempString = tempString.Substring(0, tempString.IndexOf("\"target=\"_blank")) + "\r\n"; ;
                            }

                            if (!tempString.Contains("title=\"") && !tempString.Contains("&bwm=i&b="))
                            {
                                if (!tempString.ToLower().StartsWith("http"))
                                {
                                    Data += "http://" + tempString;
                                }
                                else
                                {
                                    Data += tempString;
                                }
                            }
                        }
                        Page = Page.Substring(Page.IndexOf("class=\"yschttl spt\" href=\"") + 26);
                    } while (Page.Contains("class=\"yschttl spt\" href=\""));

                    string ends = ((PageNumber + 1) * 100 + 1).ToString();

                    if (Page.Contains("&pstart=") || Page.Contains("%26pstart%3D") || Page.Contains("\\u0026pstart="))
                    {
                        CanContinue = true;
                    }
                    else
                    {
                        CanContinue = false;
                    }

                }
                else
                {
                    if (Page.Contains("<p class=\"info\">"))
                    {
                        Page = Page.Substring(Page.IndexOf("<p class=\"info\">") + 16);
                        do
                        {
                            tempString = Page.Substring(Page.IndexOf("href=\"http://") + 13, Page.IndexOf("\">", Page.IndexOf("href=\"http://")) - Page.IndexOf("href=\"http://") - 13) + "\r\n";

                            if (tempString.Contains("\" title="))
                            {
                                tempString = tempString.Substring(0, tempString.IndexOf("\"")) + "\r\n";
                            }

                            if (tempString.Contains("\" data-"))
                            {
                                tempString = tempString.Substring(0, tempString.IndexOf("\" data-")) + "\r\n";
                            }

                            if (tempString.Contains("yahoo.com"))
                            {
                                try
                                {
                                    if (tempString.Contains("**http%3a//"))
                                    {
                                        tempString = tempString.Substring(tempString.IndexOf("**http%3a//") + 11);
                                    }
                                    else
                                    {
                                        tempString = tempString.Substring(tempString.IndexOf("**https%3a//") + 12);
                                    }
                                }
                                catch (Exception)
                                {
                                    tempString = "";
                                }
                            }

                            tempString = tempString.Replace("%3F", "?").Replace("%3D", "=").Replace("%26", "&").Replace("%2F", "/").Replace("%2520", "_");

                            if (tempString.Contains("\"target=\"_blank"))
                            {
                                tempString = tempString.Substring(0, tempString.IndexOf("\"target=\"_blank")) + "\r\n"; ;
                            }

                            if (!tempString.ToLower().StartsWith("http"))
                            {
                                Data += "http://" + tempString;
                            }
                            else
                            {
                                Data += tempString;
                            }

                            Page = Page.Substring(Page.IndexOf("<p class=\"info\">") + 16);
                        } while (Page.Contains("<p class=\"info\">"));

                        if (Page.IndexOf("Next") > 0)
                        {
                            CanContinue = true;
                        }
                        else
                        {
                            CanContinue = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void DownloadAndParseGoogle(string Keyword, int PageNumber, string Zone, ref int ProxyTick, ref int UATick, ref string Data, ref bool CanContinue)
        {
            string page = string.Empty;
            //Скачивание страницы
            string addParams = string.Empty;

            if (Keyword.Contains("&hl=") || Keyword.Contains("&gl=") || Keyword.Contains("&as_qdr="))
            {
                if (Keyword.Contains("&hl="))
                {
                    addParams = Keyword.Substring(Keyword.IndexOf("&hl="));
                    Keyword = Keyword.Substring(0, Keyword.IndexOf("&hl="));
                }
                else if (Keyword.Contains("&gl="))
                {
                    addParams = Keyword.Substring(Keyword.IndexOf("&gl="));
                    Keyword = Keyword.Substring(0, Keyword.IndexOf("&gl="));
                }
                else if (Keyword.Contains("&as_qdr="))
                {
                    addParams = Keyword.Substring(Keyword.IndexOf("&as_qdr="));
                    Keyword = Keyword.Substring(0, Keyword.IndexOf("&as_qdr="));
                }
            }

            if (WData.Zones)
            {
                try
                {
                    if (WData.AskEncoding == 0)
                    {
                        page = DownloadPage("http://www.google.com/search?ie=windows-1251&oe=utf-8&num=100&q=" + StringToANSICodes(Keyword) + " site:" + Zone + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
                    }
                    else
                    {
                        page = DownloadPage("http://www.google.com/search?ie=utf-8&oe=utf-8&num=100&q=" + StringToUTF8Codes(Keyword) + " site:" + Zone + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                if (WData.AskEncoding == 0)
                {
                    page = DownloadPage("http://www.google.com/search?ie=windows-1251&oe=utf-8&num=100&q=" + StringToANSICodes(Keyword) + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
                }
                else
                {
                    page = DownloadPage("http://www.google.com/search?ie=utf-8&oe=utf-8&num=100&q=" + StringToUTF8Codes(Keyword) + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
                }
            }
            //Парсинг
            ParseGoogle(page, PageNumber, ref Data, ref CanContinue);
        }

        private void ParseGoogle(string Page, int PageNumber, ref string Data, ref bool CanContinue)
        {
            try
            {
                string tempString = string.Empty;
                string lastString = string.Empty;
                do
                {
                    if (!Page.Contains("<h3 class=r") && !Page.Contains("<h3 class=\"r"))
                    {
                        break;
                    }

                    tempString = Page.Substring(Page.IndexOf("<a href=\"", Page.IndexOf("<h3 class=\"r")) + 9, Page.IndexOf("\"", Page.IndexOf("<a href=\"", Page.IndexOf("<h3 class=\"r")) + 9) - Page.IndexOf("<a href=\"", Page.IndexOf("<h3 class=\"r")) - 9) + "\r\n";

                    if (!tempString.Contains("google.com"))
                    {
                        if (tempString.Contains("http"))
                        {
                            tempString = tempString.Substring(tempString.IndexOf("http"));
                        }
                        if (tempString.Contains("&amp;sa=U&amp;ei="))
                        {
                            tempString = tempString.Substring(0, tempString.IndexOf("&amp;sa=U&amp;ei=")) + "\r\n";
                        }

                        if (lastString != tempString && !tempString.StartsWith("/"))
                        {
                            tempString = tempString.Replace("%3F", "?").Replace("%3D", "=");
                            Data += tempString.Substring(7);
                        }
                        lastString = tempString;
                    }
                    Page = Page.Substring(Page.IndexOf("class=\"g\"") + 9);
                } while (Page.Contains("class=\"g\""));

                string ends = ((PageNumber + 1) * 100).ToString();

                if (Page.Contains("start=" + ends))
                {
                    CanContinue = true;
                }
                else
                {
                    CanContinue = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void TextTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TextTextBox.SelectAll();
            }
        }

        private void TextControl_Load(object sender, EventArgs e)
        {
            AskTypeComboBox.SelectedIndex = 0;
            AskEncodingComboBox.SelectedIndex = 0;
            filterComboBox.SelectedIndex = 0;
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

        private void filterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (filterCheckBox.Checked)
            {
                filterNumericUpDown.Enabled = true;
                filterComboBox.Enabled = true;
            }
            else
            {
                filterNumericUpDown.Enabled = false;
                filterComboBox.Enabled = false;
            }
        }
    }
}
