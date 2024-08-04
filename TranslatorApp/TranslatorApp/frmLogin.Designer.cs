namespace TranslatorApp
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
            this.uC_Login1 = new UserControls.UC_Login();
            this.label2 = new System.Windows.Forms.Label();
            this.llbSignup = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOGIN";
            // 
            // kryptonPictureBox1
            // 
            this.kryptonPictureBox1.Image = global::TranslatorApp.Properties.Resources.loginImg;
            this.kryptonPictureBox1.Location = new System.Drawing.Point(12, 3);
            this.kryptonPictureBox1.Name = "kryptonPictureBox1";
            this.kryptonPictureBox1.Size = new System.Drawing.Size(418, 221);
            this.kryptonPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kryptonPictureBox1.TabIndex = 3;
            this.kryptonPictureBox1.TabStop = false;
            // 
            // uC_Login1
            // 
            this.uC_Login1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_Login1.Location = new System.Drawing.Point(29, 294);
            this.uC_Login1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_Login1.Name = "uC_Login1";
            this.uC_Login1.Size = new System.Drawing.Size(376, 190);
            this.uC_Login1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(73, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "DON\'T HAVE AN ACCOUNT?";
            // 
            // llbSignup
            // 
            this.llbSignup.ActiveLinkColor = System.Drawing.Color.Black;
            this.llbSignup.AutoSize = true;
            this.llbSignup.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSignup.LinkColor = System.Drawing.Color.Black;
            this.llbSignup.Location = new System.Drawing.Point(276, 493);
            this.llbSignup.Name = "llbSignup";
            this.llbSignup.Size = new System.Drawing.Size(66, 17);
            this.llbSignup.TabIndex = 5;
            this.llbSignup.TabStop = true;
            this.llbSignup.Text = "SIGN UP";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 530);
            this.Controls.Add(this.llbSignup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kryptonPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_Login1);
            this.Name = "frmLogin";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UC_Login uC_Login1;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llbSignup;
    }
}