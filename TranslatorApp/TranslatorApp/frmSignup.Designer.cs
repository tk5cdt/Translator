namespace TranslatorApp
{
    partial class frmSignup
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
            this.uC_Signup1 = new UserControls.UC_Signup();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uC_Signup1
            // 
            this.uC_Signup1.Location = new System.Drawing.Point(30, 226);
            this.uC_Signup1.Name = "uC_Signup1";
            this.uC_Signup1.Size = new System.Drawing.Size(376, 312);
            this.uC_Signup1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "SIGN UP";
            // 
            // kryptonPictureBox1
            // 
            this.kryptonPictureBox1.Image = global::TranslatorApp.Properties.Resources.imgSignup;
            this.kryptonPictureBox1.Location = new System.Drawing.Point(15, 1);
            this.kryptonPictureBox1.Name = "kryptonPictureBox1";
            this.kryptonPictureBox1.Size = new System.Drawing.Size(397, 194);
            this.kryptonPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kryptonPictureBox1.TabIndex = 2;
            this.kryptonPictureBox1.TabStop = false;
            // 
            // frmSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 530);
            this.Controls.Add(this.kryptonPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uC_Signup1);
            this.Name = "frmSignup";
            this.Text = "SIGN UP";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UC_Signup uC_Signup1;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
    }
}