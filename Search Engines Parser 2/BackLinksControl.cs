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
    public partial class BackLinksControl : UserControl
    {
        private WorkData WData;
        private bool ProxyChecks;

        public BackLinksControl()
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
                LinksTextBox.Text = string.Empty;
                WData.Data = string.Empty;
                WData.DataNumbers = string.Empty;
                WData = null;
            }
            catch (Exception)
            {
            }
        }

        private void BackLinksControl_Load(object sender, EventArgs e)
        {
            AskTypeComboBox.SelectedIndex = 0;
            AskEncodingComboBox.SelectedIndex = 0;

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
                        LinksTextBox.Text = WData.Data;
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
                File.WriteAllText(SaveFileDialog.FileName, LinksTextBox.Text, Encoding.Default);
            }
            else
            {
                File.WriteAllText(SaveFileDialog.FileName, LinksTextBox.Text, Encoding.UTF8);
            }
        }

        private void ParsingPagesUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (SECheckBoxComboBox.CheckBoxItems[2].Checked)
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
            LinksTextBox.Text = "";

            WData = new WorkData();
            //Сбор и проверка данных
            if (!SECheckBoxComboBox.CheckBoxItems[1].Checked)
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
            else
            {
                if (WData.AskType == 0)
                {
                    if (AskTextBox.Text.StartsWith("http://"))
                    {
                        AskTextBox.Text = AskTextBox.Text.Substring(7);
                    }
                }
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
                    for (int i = 0; i < WData.Keywords.Length; i++)
                    {
                        if (WData.Keywords[i] == "")
                        {
                            continue;
                        }
                        else
                        {
                            if (WData.Keywords[i].StartsWith("http://"))
                            {
                                WData.Keywords[i] = WData.Keywords[i].Substring(7);
                            }
                        }
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

            WData.HTTPLinks = httpCheckBox.Checked;

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

                                //Сохранение
                                if (WData.AskType == 0)
                                {
                                    AddCurrentDataToMainData(ref data);
                                }
                                else
                                {
                                    SaveDataToFile(WData.Keywords[i], ref data);
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
                        page = DownloadPage("http://www.google.com/search?ie=windows-1251&oe=utf-8&num=100&q=link:" + StringToANSICodes(Keyword) + " site:" + Zone + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
                    }
                    else
                    {
                        page = DownloadPage("http://www.google.com/search?ie=utf-8&oe=utf-8&num=100&q=link:" + StringToUTF8Codes(Keyword) + " site:" + Zone + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
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
                    page = DownloadPage("http://www.google.com/search?ie=windows-1251&oe=utf-8&num=100&q=link:" + StringToANSICodes(Keyword) + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
                }
                else
                {
                    page = DownloadPage("http://www.google.com/search?ie=utf-8&oe=utf-8&num=100&q=link:" + StringToUTF8Codes(Keyword) + addParams + "&start=" + (PageNumber * 100).ToString(), ref ProxyTick, ref UATick);
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
                            if (WData.HTTPLinks)
                            {
                                Data += tempString;
                            }
                            else
                            {
                                Data += tempString.Substring(7);
                            }
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

        private void LinksTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                LinksTextBox.SelectAll();
            }
        }
    }
}
