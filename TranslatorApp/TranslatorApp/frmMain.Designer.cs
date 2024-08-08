namespace TranslatorApp
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.savedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.mLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonCustomPaletteBase1 = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTranslate,
            this.savedToolStripMenuItem,
            this.mLogin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mTranslate
            // 
            this.mTranslate.Image = global::TranslatorApp.Properties.Resources.ic_langauge;
            this.mTranslate.Name = "mTranslate";
            this.mTranslate.Size = new System.Drawing.Size(105, 20);
            this.mTranslate.Text = "Translate Text";
            this.mTranslate.Click += new System.EventHandler(this.mTranslate_Click_1);
            // 
            // savedToolStripMenuItem
            // 
            this.savedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mHistory,
            this.mFavorite});
            this.savedToolStripMenuItem.Image = global::TranslatorApp.Properties.Resources.ic_Save;
            this.savedToolStripMenuItem.Name = "savedToolStripMenuItem";
            this.savedToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.savedToolStripMenuItem.Text = "Saved";
            // 
            // mHistory
            // 
            this.mHistory.Image = global::TranslatorApp.Properties.Resources.ic_History;
            this.mHistory.Name = "mHistory";
            this.mHistory.Size = new System.Drawing.Size(116, 22);
            this.mHistory.Text = "History";
            this.mHistory.Click += new System.EventHandler(this.mHistory_Click_1);
            // 
            // mFavorite
            // 
            this.mFavorite.Image = global::TranslatorApp.Properties.Resources.ic_Favorite;
            this.mFavorite.Name = "mFavorite";
            this.mFavorite.Size = new System.Drawing.Size(116, 22);
            this.mFavorite.Text = "Favorite";
            this.mFavorite.Click += new System.EventHandler(this.mFavorite_Click);
            // 
            // mLogin
            // 
            this.mLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLogout});
            this.mLogin.Image = global::TranslatorApp.Properties.Resources.ic_Account;
            this.mLogin.Name = "mLogin";
            this.mLogin.Size = new System.Drawing.Size(65, 20);
            this.mLogin.Text = "Login";
            // 
            // mLogout
            // 
            this.mLogout.Image = global::TranslatorApp.Properties.Resources.ic_Logout;
            this.mLogout.Name = "mLogout";
            this.mLogout.Size = new System.Drawing.Size(112, 22);
            this.mLogout.Text = "Logout";
            this.mLogout.Visible = false;
            this.mLogout.Click += new System.EventHandler(this.mLogout_Click);
            // 
            // kryptonCustomPaletteBase1
            // 
            this.kryptonCustomPaletteBase1.BaseFont = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonCustomPaletteBase1.BaseFontSize = 9F;
            this.kryptonCustomPaletteBase1.BasePaletteType = Krypton.Toolkit.BasePaletteType.Custom;
            this.kryptonCustomPaletteBase1.ThemeName = "";
            this.kryptonCustomPaletteBase1.UseKryptonFileDialogs = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 529);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Palette = this.kryptonCustomPaletteBase1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mTranslate;
        private System.Windows.Forms.ToolStripMenuItem savedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mHistory;
        private System.Windows.Forms.ToolStripMenuItem mFavorite;
        private System.Windows.Forms.ToolStripMenuItem mLogin;
        private System.Windows.Forms.ToolStripMenuItem mLogout;
        private Krypton.Toolkit.KryptonCustomPaletteBase kryptonCustomPaletteBase1;
    }
}

