namespace Search_Engines_Parser_2
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addKeywordsTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLinksTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBackLinksTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTextTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSnippetsTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinFilesФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eULAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserControl = new TabStrip.TestUserControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(772, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeywordsTabToolStripMenuItem,
            this.addLinksTabToolStripMenuItem,
            this.addBackLinksTabToolStripMenuItem,
            this.addTextTabToolStripMenuItem,
            this.addSnippetsTabToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            this.tabsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.tabsToolStripMenuItem.Text = "Вкладки";
            // 
            // addKeywordsTabToolStripMenuItem
            // 
            this.addKeywordsTabToolStripMenuItem.Name = "addKeywordsTabToolStripMenuItem";
            this.addKeywordsTabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addKeywordsTabToolStripMenuItem.Text = "Кейворды";
            this.addKeywordsTabToolStripMenuItem.Click += new System.EventHandler(this.addKeywordsTabToolStripMenuItem_Click);
            // 
            // addLinksTabToolStripMenuItem
            // 
            this.addLinksTabToolStripMenuItem.Name = "addLinksTabToolStripMenuItem";
            this.addLinksTabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addLinksTabToolStripMenuItem.Text = "Ссылки из выдачи";
            this.addLinksTabToolStripMenuItem.Click += new System.EventHandler(this.addLinksTabToolStripMenuItem_Click);
            // 
            // addBackLinksTabToolStripMenuItem
            // 
            this.addBackLinksTabToolStripMenuItem.Name = "addBackLinksTabToolStripMenuItem";
            this.addBackLinksTabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addBackLinksTabToolStripMenuItem.Text = "Бэклинки";
            this.addBackLinksTabToolStripMenuItem.Click += new System.EventHandler(this.addBackLinksTabToolStripMenuItem_Click);
            // 
            // addTextTabToolStripMenuItem
            // 
            this.addTextTabToolStripMenuItem.Name = "addTextTabToolStripMenuItem";
            this.addTextTabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addTextTabToolStripMenuItem.Text = "Текст";
            this.addTextTabToolStripMenuItem.Click += new System.EventHandler(this.addTextTabToolStripMenuItem_Click);
            // 
            // addSnippetsTabToolStripMenuItem
            // 
            this.addSnippetsTabToolStripMenuItem.Name = "addSnippetsTabToolStripMenuItem";
            this.addSnippetsTabToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addSnippetsTabToolStripMenuItem.Text = "Сниппеты";
            this.addSnippetsTabToolStripMenuItem.Click += new System.EventHandler(this.addSnippetsTabToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinFilesФайлыToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.toolsToolStripMenuItem.Text = "Инструменты";
            // 
            // joinFilesФайлыToolStripMenuItem
            // 
            this.joinFilesФайлыToolStripMenuItem.Name = "joinFilesФайлыToolStripMenuItem";
            this.joinFilesФайлыToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.joinFilesФайлыToolStripMenuItem.Text = "Собрать файлы";
            this.joinFilesФайлыToolStripMenuItem.Click += new System.EventHandler(this.joinFilesФайлыToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eULAToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // eULAToolStripMenuItem
            // 
            this.eULAToolStripMenuItem.Name = "eULAToolStripMenuItem";
            this.eULAToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.eULAToolStripMenuItem.Text = "Лицензионное соглашение";
            this.eULAToolStripMenuItem.Click += new System.EventHandler(this.eULAToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.aboutToolStripMenuItem.Text = "О программе...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(200, 20);
            this.checkForUpdatesToolStripMenuItem.Text = "Проверить наличие обновлений";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // UserControl
            // 
            this.UserControl.BackColor = System.Drawing.SystemColors.Control;
            this.UserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl.Location = new System.Drawing.Point(0, 24);
            this.UserControl.Name = "UserControl";
            this.UserControl.Size = new System.Drawing.Size(772, 393);
            this.UserControl.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(772, 417);
            this.Controls.Add(this.UserControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(788, 455);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Umax Search Engines Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabStrip.TestUserControl UserControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addKeywordsTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLinksTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBackLinksTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTextTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSnippetsTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eULAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinFilesФайлыToolStripMenuItem;
    }
}