namespace TabStrip
{
    partial class TestUserControl
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
            this.tabStrip1 = new FarsiLibrary.Win.FATabStrip();
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabStrip1
            // 
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabStrip1.Location = new System.Drawing.Point(0, 0);
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.Size = new System.Drawing.Size(432, 287);
            this.tabStrip1.TabIndex = 0;
            this.tabStrip1.TabStripItemClosing += new FarsiLibrary.Win.TabStripItemClosingHandler(this.tabStrip1_TabStripItemClosing);
            // 
            // TestUserControl
            // 
            this.Controls.Add(this.tabStrip1);
            this.Name = "TestUserControl";
            this.Size = new System.Drawing.Size(432, 287);
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarsiLibrary.Win.FATabStrip tabStrip1;

    }
}
