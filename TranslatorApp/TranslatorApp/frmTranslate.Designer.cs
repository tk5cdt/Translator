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
            this.tbAlternatives = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kryptonCustomPaletteBase1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.kryptonButton1);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.tbAlternatives);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbToLanguage);
            this.panel1.Controls.Add(this.cbbFromLanguage);
            this.panel1.Controls.Add(this.kryptonRichTextBox2);
            this.panel1.Controls.Add(this.kryptonRichTextBox1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 451);
            this.panel1.TabIndex = 0;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(14, 281);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonButton1.Size = new System.Drawing.Size(56, 20);
            this.kryptonButton1.TabIndex = 16;
            this.kryptonButton1.Values.Text = "speech";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 300);
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
            this.tbAlternatives.Location = new System.Drawing.Point(11, 333);
            this.tbAlternatives.Margin = new System.Windows.Forms.Padding(2);
            this.tbAlternatives.Name = "tbAlternatives";
            this.tbAlternatives.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.tbAlternatives.ReadOnly = true;
            this.tbAlternatives.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbAlternatives.Size = new System.Drawing.Size(287, 82);
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
            this.cbbToLanguage.Location = new System.Drawing.Point(407, 36);
            this.cbbToLanguage.Name = "cbbToLanguage";
            this.cbbToLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbbToLanguage.TabIndex = 12;
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
            this.kryptonRichTextBox2.Location = new System.Drawing.Point(407, 63);
            this.kryptonRichTextBox2.Name = "kryptonRichTextBox2";
            this.kryptonRichTextBox2.ReadOnly = true;
            this.kryptonRichTextBox2.Size = new System.Drawing.Size(383, 213);
            this.kryptonRichTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox2.TabIndex = 10;
            this.kryptonRichTextBox2.Text = "";
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.CueHint.CueHintText = "Enter text here ....";
            this.kryptonRichTextBox1.CueHint.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(12, 50);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(383, 213);
            this.kryptonRichTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(16, 107);
            this.kryptonRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(511, 262);
            this.kryptonRichTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "";
            this.kryptonRichTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kryptonRichTextBox1_KeyPress);
            // 
            // frmTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.tbAlternatives);
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbToLanguage);
            this.Controls.Add(this.cbbFromLanguage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kryptonRichTextBox2);
            this.Controls.Add(this.kryptonRichTextBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTranslate";
            this.Palette = this.kryptonCustomPaletteBase1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.StateCommon.Border.Color2 = System.Drawing.Color.Transparent;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
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
        private Krypton.Toolkit.KryptonRichTextBox tbAlternatives;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}