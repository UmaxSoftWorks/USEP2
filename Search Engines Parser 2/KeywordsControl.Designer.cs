namespace Search_Engines_Parser_2
{
    partial class KeywordsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProxyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProxyToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.AskGroupBox = new System.Windows.Forms.GroupBox();
            this.SECheckBoxComboBox = new PresentationControls.CheckBoxComboBox();
            this.AskEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AskTextBox = new System.Windows.Forms.TextBox();
            this.SelectAskFileFolderButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AskTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.SSSGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveSplitterTextBox = new System.Windows.Forms.TextBox();
            this.SaveEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.SaveTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.PasrsingSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.PauseUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.TrashCheckBox = new System.Windows.Forms.CheckBox();
            this.ProgressCheckBox = new System.Windows.Forms.CheckBox();
            this.ParsingPagesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ProxyTabPage = new System.Windows.Forms.TabPage();
            this.ProxyTextBox = new System.Windows.Forms.TextBox();
            this.ProxyCheckStartStopButton = new System.Windows.Forms.Button();
            this.ProxySettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProxySwitchUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ProxyUseCheckBox = new System.Windows.Forms.CheckBox();
            this.UATabPage = new System.Windows.Forms.TabPage();
            this.UATextBox = new System.Windows.Forms.TextBox();
            this.UAContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UAToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UASettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.UAUseRandomCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UASwitchUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.KeywordsGroupBox = new System.Windows.Forms.GroupBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.KeywordsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumbersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.StatusStrip.SuspendLayout();
            this.ProxyContextMenuStrip.SuspendLayout();
            this.SettingsGroupBox.SuspendLayout();
            this.AskGroupBox.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.SSSGroupBox.SuspendLayout();
            this.PasrsingSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PauseUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingPagesUpDown)).BeginInit();
            this.ProxyTabPage.SuspendLayout();
            this.ProxySettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxySwitchUpDown)).BeginInit();
            this.UATabPage.SuspendLayout();
            this.UAContextMenuStrip.SuspendLayout();
            this.UASettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UASwitchUpDown)).BeginInit();
            this.KeywordsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 500;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusToolStripProgressBar,
            this.StatusToolStripLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 408);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(765, 22);
            this.StatusStrip.TabIndex = 0;
            // 
            // StatusToolStripProgressBar
            // 
            this.StatusToolStripProgressBar.Name = "StatusToolStripProgressBar";
            this.StatusToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // StatusToolStripLabel
            // 
            this.StatusToolStripLabel.Name = "StatusToolStripLabel";
            this.StatusToolStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ProxyContextMenuStrip
            // 
            this.ProxyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadProxyToolStripMenuItem,
            this.SaveProxyToolStripMenuItem,
            this.ProxyToolStripSeparator,
            this.SelectAllProxyToolStripMenuItem,
            this.ClearProxyToolStripMenuItem});
            this.ProxyContextMenuStrip.Name = "ContextMenuStrip";
            this.ProxyContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ProxyContextMenuStrip.Size = new System.Drawing.Size(153, 98);
            // 
            // LoadProxyToolStripMenuItem
            // 
            this.LoadProxyToolStripMenuItem.Name = "LoadProxyToolStripMenuItem";
            this.LoadProxyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LoadProxyToolStripMenuItem.Text = "Загрузить из...";
            this.LoadProxyToolStripMenuItem.Click += new System.EventHandler(this.LoadProxyToolStripMenuItem_Click);
            // 
            // SaveProxyToolStripMenuItem
            // 
            this.SaveProxyToolStripMenuItem.Name = "SaveProxyToolStripMenuItem";
            this.SaveProxyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveProxyToolStripMenuItem.Text = "Сохранить в...";
            this.SaveProxyToolStripMenuItem.Click += new System.EventHandler(this.SaveProxyToolStripMenuItem_Click);
            // 
            // ProxyToolStripSeparator
            // 
            this.ProxyToolStripSeparator.Name = "ProxyToolStripSeparator";
            this.ProxyToolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // SelectAllProxyToolStripMenuItem
            // 
            this.SelectAllProxyToolStripMenuItem.Name = "SelectAllProxyToolStripMenuItem";
            this.SelectAllProxyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SelectAllProxyToolStripMenuItem.Text = "Выделить все";
            this.SelectAllProxyToolStripMenuItem.Click += new System.EventHandler(this.SelectAllProxyToolStripMenuItem_Click);
            // 
            // ClearProxyToolStripMenuItem
            // 
            this.ClearProxyToolStripMenuItem.Name = "ClearProxyToolStripMenuItem";
            this.ClearProxyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ClearProxyToolStripMenuItem.Text = "Очистить";
            this.ClearProxyToolStripMenuItem.Click += new System.EventHandler(this.ClearProxyToolStripMenuItem_Click);
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.AskGroupBox);
            this.SettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.SettingsGroupBox.MinimumSize = new System.Drawing.Size(575, 84);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(588, 84);
            this.SettingsGroupBox.TabIndex = 0;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Опции";
            // 
            // AskGroupBox
            // 
            this.AskGroupBox.Controls.Add(this.SECheckBoxComboBox);
            this.AskGroupBox.Controls.Add(this.AskEncodingComboBox);
            this.AskGroupBox.Controls.Add(this.label3);
            this.AskGroupBox.Controls.Add(this.AskTextBox);
            this.AskGroupBox.Controls.Add(this.SelectAskFileFolderButton);
            this.AskGroupBox.Controls.Add(this.label4);
            this.AskGroupBox.Controls.Add(this.AskTypeComboBox);
            this.AskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AskGroupBox.Location = new System.Drawing.Point(3, 16);
            this.AskGroupBox.MinimumSize = new System.Drawing.Size(437, 65);
            this.AskGroupBox.Name = "AskGroupBox";
            this.AskGroupBox.Size = new System.Drawing.Size(582, 65);
            this.AskGroupBox.TabIndex = 1;
            this.AskGroupBox.TabStop = false;
            this.AskGroupBox.Text = "Поисковые системы / Запросы";
            // 
            // SECheckBoxComboBox
            // 
            checkBoxProperties1.AutoSize = true;
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SECheckBoxComboBox.CheckBoxProperties = checkBoxProperties1;
            this.SECheckBoxComboBox.DisplayMemberSingleItem = "";
            this.SECheckBoxComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SECheckBoxComboBox.FormattingEnabled = true;
            this.SECheckBoxComboBox.Items.AddRange(new object[] {
            "DT.com"});
            this.SECheckBoxComboBox.Location = new System.Drawing.Point(6, 17);
            this.SECheckBoxComboBox.Name = "SECheckBoxComboBox";
            this.SECheckBoxComboBox.Size = new System.Drawing.Size(145, 21);
            this.SECheckBoxComboBox.TabIndex = 0;
            // 
            // AskEncodingComboBox
            // 
            this.AskEncodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AskEncodingComboBox.FormattingEnabled = true;
            this.AskEncodingComboBox.Items.AddRange(new object[] {
            "ANSI (Win-1251)",
            "UTF-8"});
            this.AskEncodingComboBox.Location = new System.Drawing.Point(385, 17);
            this.AskEncodingComboBox.Name = "AskEncodingComboBox";
            this.AskEncodingComboBox.Size = new System.Drawing.Size(110, 21);
            this.AskEncodingComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Кодировка";
            // 
            // AskTextBox
            // 
            this.AskTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AskTextBox.Location = new System.Drawing.Point(3, 42);
            this.AskTextBox.Name = "AskTextBox";
            this.AskTextBox.Size = new System.Drawing.Size(576, 20);
            this.AskTextBox.TabIndex = 5;
            // 
            // SelectAskFileFolderButton
            // 
            this.SelectAskFileFolderButton.Enabled = false;
            this.SelectAskFileFolderButton.Location = new System.Drawing.Point(501, 15);
            this.SelectAskFileFolderButton.Name = "SelectAskFileFolderButton";
            this.SelectAskFileFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectAskFileFolderButton.TabIndex = 6;
            this.SelectAskFileFolderButton.Text = "Выбрать файл";
            this.SelectAskFileFolderButton.UseVisualStyleBackColor = true;
            this.SelectAskFileFolderButton.Click += new System.EventHandler(this.SelectAskFileFolderButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Тип";
            // 
            // AskTypeComboBox
            // 
            this.AskTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AskTypeComboBox.FormattingEnabled = true;
            this.AskTypeComboBox.Items.AddRange(new object[] {
            "Одиночный запрос",
            "Из файла"});
            this.AskTypeComboBox.Location = new System.Drawing.Point(186, 17);
            this.AskTypeComboBox.Name = "AskTypeComboBox";
            this.AskTypeComboBox.Size = new System.Drawing.Size(125, 21);
            this.AskTypeComboBox.TabIndex = 2;
            this.AskTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.AskComboBox_SelectedIndexChanged);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.TabControl);
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingsPanel.Location = new System.Drawing.Point(588, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(177, 408);
            this.SettingsPanel.TabIndex = 2;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.GeneralTabPage);
            this.TabControl.Controls.Add(this.ProxyTabPage);
            this.TabControl.Controls.Add(this.UATabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(177, 408);
            this.TabControl.TabIndex = 0;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.GeneralTabPage.Controls.Add(this.SSSGroupBox);
            this.GeneralTabPage.Controls.Add(this.PasrsingSettingsGroupBox);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(169, 382);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "Общее";
            // 
            // SSSGroupBox
            // 
            this.SSSGroupBox.Controls.Add(this.SaveSplitterTextBox);
            this.SSSGroupBox.Controls.Add(this.SaveEncodingComboBox);
            this.SSSGroupBox.Controls.Add(this.SaveTypeComboBox);
            this.SSSGroupBox.Controls.Add(this.SaveButton);
            this.SSSGroupBox.Controls.Add(this.StopButton);
            this.SSSGroupBox.Controls.Add(this.StartButton);
            this.SSSGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SSSGroupBox.Location = new System.Drawing.Point(3, 93);
            this.SSSGroupBox.MinimumSize = new System.Drawing.Size(163, 211);
            this.SSSGroupBox.Name = "SSSGroupBox";
            this.SSSGroupBox.Size = new System.Drawing.Size(163, 211);
            this.SSSGroupBox.TabIndex = 1;
            this.SSSGroupBox.TabStop = false;
            this.SSSGroupBox.Text = "Меню";
            // 
            // SaveSplitterTextBox
            // 
            this.SaveSplitterTextBox.Location = new System.Drawing.Point(3, 163);
            this.SaveSplitterTextBox.Name = "SaveSplitterTextBox";
            this.SaveSplitterTextBox.Size = new System.Drawing.Size(157, 20);
            this.SaveSplitterTextBox.TabIndex = 5;
            this.SaveSplitterTextBox.Text = "[TAB]";
            // 
            // SaveEncodingComboBox
            // 
            this.SaveEncodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SaveEncodingComboBox.FormattingEnabled = true;
            this.SaveEncodingComboBox.Items.AddRange(new object[] {
            "ANSI (Win-1251)",
            "UTF-8"});
            this.SaveEncodingComboBox.Location = new System.Drawing.Point(3, 136);
            this.SaveEncodingComboBox.Name = "SaveEncodingComboBox";
            this.SaveEncodingComboBox.Size = new System.Drawing.Size(157, 21);
            this.SaveEncodingComboBox.TabIndex = 4;
            // 
            // SaveTypeComboBox
            // 
            this.SaveTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SaveTypeComboBox.FormattingEnabled = true;
            this.SaveTypeComboBox.Items.AddRange(new object[] {
            "Кейворды и цифры",
            "Только кейворды"});
            this.SaveTypeComboBox.Location = new System.Drawing.Point(3, 109);
            this.SaveTypeComboBox.Name = "SaveTypeComboBox";
            this.SaveTypeComboBox.Size = new System.Drawing.Size(157, 21);
            this.SaveTypeComboBox.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveButton.Location = new System.Drawing.Point(3, 185);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(157, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Сохранить ...";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(3, 80);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(157, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Стоп";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(3, 15);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(157, 59);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PasrsingSettingsGroupBox
            // 
            this.PasrsingSettingsGroupBox.Controls.Add(this.PauseUpDown);
            this.PasrsingSettingsGroupBox.Controls.Add(this.label8);
            this.PasrsingSettingsGroupBox.Controls.Add(this.TrashCheckBox);
            this.PasrsingSettingsGroupBox.Controls.Add(this.ProgressCheckBox);
            this.PasrsingSettingsGroupBox.Controls.Add(this.ParsingPagesUpDown);
            this.PasrsingSettingsGroupBox.Controls.Add(this.label5);
            this.PasrsingSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PasrsingSettingsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.PasrsingSettingsGroupBox.MinimumSize = new System.Drawing.Size(163, 90);
            this.PasrsingSettingsGroupBox.Name = "PasrsingSettingsGroupBox";
            this.PasrsingSettingsGroupBox.Size = new System.Drawing.Size(163, 90);
            this.PasrsingSettingsGroupBox.TabIndex = 0;
            this.PasrsingSettingsGroupBox.TabStop = false;
            this.PasrsingSettingsGroupBox.Text = "Настройки парсинга";
            // 
            // PauseUpDown
            // 
            this.PauseUpDown.Location = new System.Drawing.Point(103, 44);
            this.PauseUpDown.Name = "PauseUpDown";
            this.PauseUpDown.Size = new System.Drawing.Size(57, 20);
            this.PauseUpDown.TabIndex = 5;
            this.PauseUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Паузы";
            // 
            // TrashCheckBox
            // 
            this.TrashCheckBox.AutoSize = true;
            this.TrashCheckBox.Checked = true;
            this.TrashCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TrashCheckBox.Location = new System.Drawing.Point(88, 70);
            this.TrashCheckBox.Name = "TrashCheckBox";
            this.TrashCheckBox.Size = new System.Drawing.Size(68, 17);
            this.TrashCheckBox.TabIndex = 3;
            this.TrashCheckBox.Text = "\"Мусор\"";
            this.TrashCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProgressCheckBox
            // 
            this.ProgressCheckBox.AutoSize = true;
            this.ProgressCheckBox.Location = new System.Drawing.Point(7, 70);
            this.ProgressCheckBox.Name = "ProgressCheckBox";
            this.ProgressCheckBox.Size = new System.Drawing.Size(75, 17);
            this.ProgressCheckBox.TabIndex = 2;
            this.ProgressCheckBox.Text = "Прогресс";
            this.ProgressCheckBox.UseVisualStyleBackColor = true;
            // 
            // ParsingPagesUpDown
            // 
            this.ParsingPagesUpDown.Location = new System.Drawing.Point(103, 18);
            this.ParsingPagesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ParsingPagesUpDown.Name = "ParsingPagesUpDown";
            this.ParsingPagesUpDown.Size = new System.Drawing.Size(57, 20);
            this.ParsingPagesUpDown.TabIndex = 1;
            this.ParsingPagesUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Глубина парсинга";
            // 
            // ProxyTabPage
            // 
            this.ProxyTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.ProxyTabPage.Controls.Add(this.ProxyTextBox);
            this.ProxyTabPage.Controls.Add(this.ProxyCheckStartStopButton);
            this.ProxyTabPage.Controls.Add(this.ProxySettingsGroupBox);
            this.ProxyTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProxyTabPage.Name = "ProxyTabPage";
            this.ProxyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProxyTabPage.Size = new System.Drawing.Size(169, 382);
            this.ProxyTabPage.TabIndex = 1;
            this.ProxyTabPage.Text = "Proxy";
            // 
            // ProxyTextBox
            // 
            this.ProxyTextBox.ContextMenuStrip = this.ProxyContextMenuStrip;
            this.ProxyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyTextBox.Enabled = false;
            this.ProxyTextBox.Location = new System.Drawing.Point(3, 98);
            this.ProxyTextBox.Multiline = true;
            this.ProxyTextBox.Name = "ProxyTextBox";
            this.ProxyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProxyTextBox.Size = new System.Drawing.Size(163, 258);
            this.ProxyTextBox.TabIndex = 1;
            // 
            // ProxyCheckStartStopButton
            // 
            this.ProxyCheckStartStopButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProxyCheckStartStopButton.Enabled = false;
            this.ProxyCheckStartStopButton.Location = new System.Drawing.Point(3, 356);
            this.ProxyCheckStartStopButton.Name = "ProxyCheckStartStopButton";
            this.ProxyCheckStartStopButton.Size = new System.Drawing.Size(163, 23);
            this.ProxyCheckStartStopButton.TabIndex = 2;
            this.ProxyCheckStartStopButton.Text = "Проверить | Стоп";
            this.ProxyCheckStartStopButton.UseVisualStyleBackColor = true;
            this.ProxyCheckStartStopButton.Click += new System.EventHandler(this.ProxyCheckStartStopButton_Click);
            // 
            // ProxySettingsGroupBox
            // 
            this.ProxySettingsGroupBox.Controls.Add(this.label2);
            this.ProxySettingsGroupBox.Controls.Add(this.ProxySwitchUpDown);
            this.ProxySettingsGroupBox.Controls.Add(this.label1);
            this.ProxySettingsGroupBox.Controls.Add(this.ProxyUseCheckBox);
            this.ProxySettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProxySettingsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ProxySettingsGroupBox.MinimumSize = new System.Drawing.Size(163, 95);
            this.ProxySettingsGroupBox.Name = "ProxySettingsGroupBox";
            this.ProxySettingsGroupBox.Size = new System.Drawing.Size(163, 95);
            this.ProxySettingsGroupBox.TabIndex = 0;
            this.ProxySettingsGroupBox.TabStop = false;
            this.ProxySettingsGroupBox.Text = "Настройки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "запросов";
            // 
            // ProxySwitchUpDown
            // 
            this.ProxySwitchUpDown.Enabled = false;
            this.ProxySwitchUpDown.Location = new System.Drawing.Point(6, 68);
            this.ProxySwitchUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProxySwitchUpDown.Name = "ProxySwitchUpDown";
            this.ProxySwitchUpDown.Size = new System.Drawing.Size(57, 20);
            this.ProxySwitchUpDown.TabIndex = 2;
            this.ProxySwitchUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Переключаться между\r\nпрокси через каждые";
            // 
            // ProxyUseCheckBox
            // 
            this.ProxyUseCheckBox.AutoSize = true;
            this.ProxyUseCheckBox.Location = new System.Drawing.Point(6, 19);
            this.ProxyUseCheckBox.Name = "ProxyUseCheckBox";
            this.ProxyUseCheckBox.Size = new System.Drawing.Size(99, 17);
            this.ProxyUseCheckBox.TabIndex = 0;
            this.ProxyUseCheckBox.Text = "Использовать";
            this.ProxyUseCheckBox.UseVisualStyleBackColor = true;
            this.ProxyUseCheckBox.CheckedChanged += new System.EventHandler(this.ProxyUseCheckBox_CheckedChanged);
            // 
            // UATabPage
            // 
            this.UATabPage.BackColor = System.Drawing.SystemColors.Control;
            this.UATabPage.Controls.Add(this.UATextBox);
            this.UATabPage.Controls.Add(this.UASettingsGroupBox);
            this.UATabPage.Location = new System.Drawing.Point(4, 22);
            this.UATabPage.Name = "UATabPage";
            this.UATabPage.Size = new System.Drawing.Size(169, 382);
            this.UATabPage.TabIndex = 2;
            this.UATabPage.Text = "UserAgent";
            // 
            // UATextBox
            // 
            this.UATextBox.ContextMenuStrip = this.UAContextMenuStrip;
            this.UATextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UATextBox.Location = new System.Drawing.Point(0, 78);
            this.UATextBox.Multiline = true;
            this.UATextBox.Name = "UATextBox";
            this.UATextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UATextBox.Size = new System.Drawing.Size(169, 304);
            this.UATextBox.TabIndex = 1;
            // 
            // UAContextMenuStrip
            // 
            this.UAContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadUAToolStripMenuItem,
            this.SaveUAToolStripMenuItem,
            this.UAToolStripSeparator,
            this.SelectAllUAToolStripMenuItem,
            this.ClearUAToolStripMenuItem});
            this.UAContextMenuStrip.Name = "UAContextMenuStrip";
            this.UAContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.UAContextMenuStrip.Size = new System.Drawing.Size(153, 98);
            // 
            // LoadUAToolStripMenuItem
            // 
            this.LoadUAToolStripMenuItem.Name = "LoadUAToolStripMenuItem";
            this.LoadUAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LoadUAToolStripMenuItem.Text = "Загрузить из...";
            this.LoadUAToolStripMenuItem.Click += new System.EventHandler(this.LoadUAToolStripMenuItem_Click);
            // 
            // SaveUAToolStripMenuItem
            // 
            this.SaveUAToolStripMenuItem.Name = "SaveUAToolStripMenuItem";
            this.SaveUAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveUAToolStripMenuItem.Text = "Сохранить в...";
            this.SaveUAToolStripMenuItem.Click += new System.EventHandler(this.SaveUAToolStripMenuItem_Click);
            // 
            // UAToolStripSeparator
            // 
            this.UAToolStripSeparator.Name = "UAToolStripSeparator";
            this.UAToolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // SelectAllUAToolStripMenuItem
            // 
            this.SelectAllUAToolStripMenuItem.Name = "SelectAllUAToolStripMenuItem";
            this.SelectAllUAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SelectAllUAToolStripMenuItem.Text = "Выделить все";
            this.SelectAllUAToolStripMenuItem.Click += new System.EventHandler(this.SelectAllUAToolStripMenuItem_Click);
            // 
            // ClearUAToolStripMenuItem
            // 
            this.ClearUAToolStripMenuItem.Name = "ClearUAToolStripMenuItem";
            this.ClearUAToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ClearUAToolStripMenuItem.Text = "Очистить";
            this.ClearUAToolStripMenuItem.Click += new System.EventHandler(this.ClearUAToolStripMenuItem_Click);
            // 
            // UASettingsGroupBox
            // 
            this.UASettingsGroupBox.Controls.Add(this.UAUseRandomCheckBox);
            this.UASettingsGroupBox.Controls.Add(this.label6);
            this.UASettingsGroupBox.Controls.Add(this.UASwitchUpDown);
            this.UASettingsGroupBox.Controls.Add(this.label7);
            this.UASettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.UASettingsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.UASettingsGroupBox.MinimumSize = new System.Drawing.Size(169, 78);
            this.UASettingsGroupBox.Name = "UASettingsGroupBox";
            this.UASettingsGroupBox.Size = new System.Drawing.Size(169, 78);
            this.UASettingsGroupBox.TabIndex = 0;
            this.UASettingsGroupBox.TabStop = false;
            this.UASettingsGroupBox.Text = "Настройки";
            // 
            // UAUseRandomCheckBox
            // 
            this.UAUseRandomCheckBox.AutoSize = true;
            this.UAUseRandomCheckBox.Location = new System.Drawing.Point(6, 58);
            this.UAUseRandomCheckBox.Name = "UAUseRandomCheckBox";
            this.UAUseRandomCheckBox.Size = new System.Drawing.Size(125, 17);
            this.UAUseRandomCheckBox.TabIndex = 4;
            this.UAUseRandomCheckBox.Text = "Выбирать случайно";
            this.UAUseRandomCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "запросов";
            // 
            // UASwitchUpDown
            // 
            this.UASwitchUpDown.Location = new System.Drawing.Point(6, 32);
            this.UASwitchUpDown.Name = "UASwitchUpDown";
            this.UASwitchUpDown.Size = new System.Drawing.Size(57, 20);
            this.UASwitchUpDown.TabIndex = 2;
            this.UASwitchUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Переключаться через";
            // 
            // KeywordsGroupBox
            // 
            this.KeywordsGroupBox.Controls.Add(this.DataGridView);
            this.KeywordsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeywordsGroupBox.Location = new System.Drawing.Point(0, 84);
            this.KeywordsGroupBox.Name = "KeywordsGroupBox";
            this.KeywordsGroupBox.Size = new System.Drawing.Size(588, 324);
            this.KeywordsGroupBox.TabIndex = 1;
            this.KeywordsGroupBox.TabStop = false;
            this.KeywordsGroupBox.Text = "Кейворды";
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeywordsColumn,
            this.NumbersColumn});
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(3, 16);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.Size = new System.Drawing.Size(582, 305);
            this.DataGridView.TabIndex = 0;
            // 
            // KeywordsColumn
            // 
            this.KeywordsColumn.HeaderText = "Кейворды";
            this.KeywordsColumn.Name = "KeywordsColumn";
            this.KeywordsColumn.ReadOnly = true;
            this.KeywordsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KeywordsColumn.Width = 400;
            // 
            // NumbersColumn
            // 
            this.NumbersColumn.HeaderText = "#";
            this.NumbersColumn.Name = "NumbersColumn";
            this.NumbersColumn.ReadOnly = true;
            this.NumbersColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumbersColumn.Width = 120;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Text|*.txt";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Text|*.txt";
            // 
            // KeywordsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.KeywordsGroupBox);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.StatusStrip);
            this.Name = "KeywordsControl";
            this.Size = new System.Drawing.Size(765, 430);
            this.Load += new System.EventHandler(this.KeywordsControl_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ProxyContextMenuStrip.ResumeLayout(false);
            this.SettingsGroupBox.ResumeLayout(false);
            this.AskGroupBox.ResumeLayout(false);
            this.AskGroupBox.PerformLayout();
            this.SettingsPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.SSSGroupBox.ResumeLayout(false);
            this.SSSGroupBox.PerformLayout();
            this.PasrsingSettingsGroupBox.ResumeLayout(false);
            this.PasrsingSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PauseUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingPagesUpDown)).EndInit();
            this.ProxyTabPage.ResumeLayout(false);
            this.ProxyTabPage.PerformLayout();
            this.ProxySettingsGroupBox.ResumeLayout(false);
            this.ProxySettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxySwitchUpDown)).EndInit();
            this.UATabPage.ResumeLayout(false);
            this.UATabPage.PerformLayout();
            this.UAContextMenuStrip.ResumeLayout(false);
            this.UASettingsGroupBox.ResumeLayout(false);
            this.UASettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UASwitchUpDown)).EndInit();
            this.KeywordsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripProgressBar StatusToolStripProgressBar;
        private System.Windows.Forms.ContextMenuStrip ProxyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LoadProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ProxyToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SelectAllProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearProxyToolStripMenuItem;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.GroupBox KeywordsGroupBox;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.GroupBox AskGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AskTypeComboBox;
        private System.Windows.Forms.TextBox AskTextBox;
        private System.Windows.Forms.Button SelectAskFileFolderButton;
        private System.Windows.Forms.ComboBox AskEncodingComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox PasrsingSettingsGroupBox;
        private System.Windows.Forms.CheckBox TrashCheckBox;
        private System.Windows.Forms.CheckBox ProgressCheckBox;
        private System.Windows.Forms.NumericUpDown ParsingPagesUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox SSSGroupBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage ProxyTabPage;
        private System.Windows.Forms.TabPage UATabPage;
        private System.Windows.Forms.GroupBox ProxySettingsGroupBox;
        private System.Windows.Forms.NumericUpDown ProxySwitchUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ProxyUseCheckBox;
        private System.Windows.Forms.TextBox ProxyTextBox;
        private System.Windows.Forms.Button ProxyCheckStartStopButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SaveTypeComboBox;
        private System.Windows.Forms.TextBox UATextBox;
        private System.Windows.Forms.GroupBox UASettingsGroupBox;
        private System.Windows.Forms.CheckBox UAUseRandomCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown UASwitchUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeywordsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumbersColumn;
        private System.Windows.Forms.ContextMenuStrip UAContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LoadUAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveUAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator UAToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SelectAllUAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearUAToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.ComboBox SaveEncodingComboBox;
        private System.Windows.Forms.NumericUpDown PauseUpDown;
        private System.Windows.Forms.Label label8;
        private PresentationControls.CheckBoxComboBox SECheckBoxComboBox;
        private System.Windows.Forms.TextBox SaveSplitterTextBox;
        private System.Windows.Forms.ToolStripStatusLabel StatusToolStripLabel;
    }
}
