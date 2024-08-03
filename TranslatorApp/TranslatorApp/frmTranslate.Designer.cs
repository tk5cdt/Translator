namespace TranslatorApp
{
    partial class frmTranslate
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
            this.kryptonCustomPaletteBase1 = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonRichTextBox2 = new Krypton.Toolkit.KryptonRichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbFromLanguage = new System.Windows.Forms.ComboBox();
            this.cbbToLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kryptonCustomPaletteBase1
            // 
            this.kryptonCustomPaletteBase1.BaseFont = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonCustomPaletteBase1.BaseFontSize = 9F;
            this.kryptonCustomPaletteBase1.BasePaletteType = Krypton.Toolkit.BasePaletteType.Custom;
            this.kryptonCustomPaletteBase1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.kryptonCustomPaletteBase1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.kryptonCustomPaletteBase1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonCustomPaletteBase1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonCustomPaletteBase1.FormStyles.FormMain.StateCommon.Border.Rounding = 15F;
            this.kryptonCustomPaletteBase1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.kryptonCustomPaletteBase1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.kryptonCustomPaletteBase1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 12;
            this.kryptonCustomPaletteBase1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.kryptonCustomPaletteBase1.ThemeName = "";
            this.kryptonCustomPaletteBase1.UseKryptonFileDialogs = true;
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.CueHint.CueHintText = "Enter text here ....";
            this.kryptonRichTextBox1.CueHint.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(12, 87);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(383, 213);
            this.kryptonRichTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "";
            this.kryptonRichTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kryptonRichTextBox1_KeyPress);
            // 
            // kryptonRichTextBox2
            // 
            this.kryptonRichTextBox2.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonRichTextBox2.Location = new System.Drawing.Point(405, 87);
            this.kryptonRichTextBox2.Name = "kryptonRichTextBox2";
            this.kryptonRichTextBox2.ReadOnly = true;
            this.kryptonRichTextBox2.Size = new System.Drawing.Size(383, 213);
            this.kryptonRichTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox2.TabIndex = 1;
            this.kryptonRichTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbFromLanguage
            // 
            this.cbbFromLanguage.FormattingEnabled = true;
            this.cbbFromLanguage.Location = new System.Drawing.Point(12, 60);
            this.cbbFromLanguage.Name = "cbbFromLanguage";
            this.cbbFromLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbbFromLanguage.TabIndex = 3;
            this.cbbFromLanguage.SelectedIndexChanged += new System.EventHandler(this.cbbFromLanguage_SelectedIndexChanged);
            // 
            // cbbToLanguage
            // 
            this.cbbToLanguage.FormattingEnabled = true;
            this.cbbToLanguage.Location = new System.Drawing.Point(405, 60);
            this.cbbToLanguage.Name = "cbbToLanguage";
            this.cbbToLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbbToLanguage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // frmTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbToLanguage);
            this.Controls.Add(this.cbbFromLanguage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kryptonRichTextBox2);
            this.Controls.Add(this.kryptonRichTextBox1);
            this.Name = "frmTranslate";
            this.Palette = this.kryptonCustomPaletteBase1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.Text = "frmTranslate";
            this.Load += new System.EventHandler(this.frmTranslate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonCustomPaletteBase kryptonCustomPaletteBase1;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbFromLanguage;
        private System.Windows.Forms.ComboBox cbbToLanguage;
        private System.Windows.Forms.Label label1;
    }
}