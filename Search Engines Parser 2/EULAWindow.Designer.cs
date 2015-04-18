namespace Search_Engines_Parser_2
{
    partial class EULAWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EULAWindow));
            this.EULATextBox = new System.Windows.Forms.TextBox();
            this.EULACheckBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EULATextBox
            // 
            this.EULATextBox.Enabled = false;
            this.EULATextBox.Location = new System.Drawing.Point(12, 12);
            this.EULATextBox.Multiline = true;
            this.EULATextBox.Name = "EULATextBox";
            this.EULATextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EULATextBox.Size = new System.Drawing.Size(566, 208);
            this.EULATextBox.TabIndex = 0;
            this.EULATextBox.Text = resources.GetString("EULATextBox.Text");
            // 
            // EULACheckBox
            // 
            this.EULACheckBox.AutoSize = true;
            this.EULACheckBox.Location = new System.Drawing.Point(85, 231);
            this.EULACheckBox.Name = "EULACheckBox";
            this.EULACheckBox.Size = new System.Drawing.Size(262, 17);
            this.EULACheckBox.TabIndex = 1;
            this.EULACheckBox.Text = "Я согласен(на) с лицензионным соглашением";
            this.EULACheckBox.UseVisualStyleBackColor = true;
            this.EULACheckBox.CheckedChanged += new System.EventHandler(this.EULACheckBox_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(353, 227);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // EULAWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 260);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.EULACheckBox);
            this.Controls.Add(this.EULATextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EULAWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лицензионное соглашение";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EULAWindow_FormClosing);
            this.Load += new System.EventHandler(this.EULAWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EULATextBox;
        private System.Windows.Forms.CheckBox EULACheckBox;
        private System.Windows.Forms.Button OKButton;
    }
}