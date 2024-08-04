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
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.tbAlternatives = new Krypton.Toolkit.KryptonRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbToLanguage = new System.Windows.Forms.ComboBox();
            this.cbbFromLanguage = new System.Windows.Forms.ComboBox();
            this.kryptonRichTextBox2 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.kryptonButton2);
            this.panel1.Controls.Add(this.kryptonButton1);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.tbAlternatives);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbToLanguage);
            this.panel1.Controls.Add(this.cbbFromLanguage);
            this.panel1.Controls.Add(this.kryptonRichTextBox2);
            this.panel1.Controls.Add(this.kryptonRichTextBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 529);
            this.panel1.TabIndex = 0;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(464, 281);
            this.kryptonButton2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonButton2.Size = new System.Drawing.Size(30, 30);
            this.kryptonButton2.TabIndex = 17;
            this.kryptonButton2.Values.Image = global::TranslatorApp.Properties.Resources.ic_Volume;
            this.kryptonButton2.Values.Text = "speech";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(14, 281);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonButton1.Size = new System.Drawing.Size(30, 30);
            this.kryptonButton1.TabIndex = 16;
            this.kryptonButton1.Values.Image = global::TranslatorApp.Properties.Resources.ic_Volume;
            this.kryptonButton1.Values.Text = "speech";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 315);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Microsoft365White;
            this.kryptonLabel1.Size = new System.Drawing.Size(120, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "Alternatives";
            // 
            // tbAlternatives
            // 
            this.tbAlternatives.Location = new System.Drawing.Point(11, 348);
            this.tbAlternatives.Margin = new System.Windows.Forms.Padding(2);
            this.tbAlternatives.Name = "tbAlternatives";
            this.tbAlternatives.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.tbAlternatives.ReadOnly = true;
            this.tbAlternatives.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbAlternatives.Size = new System.Drawing.Size(433, 82);
            this.tbAlternatives.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlternatives.TabIndex = 14;
            this.tbAlternatives.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 13;
            // 
            // cbbToLanguage
            // 
            this.cbbToLanguage.FormattingEnabled = true;
            this.cbbToLanguage.Location = new System.Drawing.Point(464, 36);
            this.cbbToLanguage.Name = "cbbToLanguage";
            this.cbbToLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbbToLanguage.TabIndex = 12;
            this.cbbToLanguage.SelectedIndexChanged += new System.EventHandler(this.cbbToLanguage_SelectedIndexChanged);
            // 
            // cbbFromLanguage
            // 
            this.cbbFromLanguage.FormattingEnabled = true;
            this.cbbFromLanguage.Location = new System.Drawing.Point(14, 36);
            this.cbbFromLanguage.Name = "cbbFromLanguage";
            this.cbbFromLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbbFromLanguage.TabIndex = 11;
            // 
            // kryptonRichTextBox2
            // 
            this.kryptonRichTextBox2.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonRichTextBox2.Location = new System.Drawing.Point(464, 63);
            this.kryptonRichTextBox2.Name = "kryptonRichTextBox2";
            this.kryptonRichTextBox2.ReadOnly = true;
            this.kryptonRichTextBox2.Size = new System.Drawing.Size(430, 213);
            this.kryptonRichTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox2.TabIndex = 10;
            this.kryptonRichTextBox2.Text = "";
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.CueHint.CueHintText = "Enter text here ....";
            this.kryptonRichTextBox1.CueHint.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(14, 63);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(430, 213);
            this.kryptonRichTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.TabIndex = 9;
            this.kryptonRichTextBox1.Text = "";
            this.kryptonRichTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kryptonRichTextBox1_KeyPress);
            // 
            // frmTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(906, 529);
            this.Controls.Add(this.panel1);
            this.Name = "frmTranslate";
            this.PaletteMode = Krypton.Toolkit.PaletteMode.VisualStudio2010Render365;
            this.ShowIcon = false;
            this.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.StateCommon.Border.Color2 = System.Drawing.Color.Transparent;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "frmTranslate";
            this.Load += new System.EventHandler(this.frmTranslate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonRichTextBox tbAlternatives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbToLanguage;
        private System.Windows.Forms.ComboBox cbbFromLanguage;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox2;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}