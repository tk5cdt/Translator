namespace UserControls
{
    partial class UC_Signup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirm = new Krypton.Toolkit.KryptonTextBox();
            this.btnSignup = new Krypton.Toolkit.KryptonButton();
            this.picHidePass = new Krypton.Toolkit.KryptonPictureBox();
            this.picEyePass = new Krypton.Toolkit.KryptonPictureBox();
            this.picHideConfirm = new Krypton.Toolkit.KryptonPictureBox();
            this.picEyeConfirm = new Krypton.Toolkit.KryptonPictureBox();
            this.txtPasswordSignup = new TranslatorLibrary.PasswordTextbox();
            this.txtEmailSignup = new TranslatorLibrary.EmailTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.picHidePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHideConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(10, 36);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(363, 33);
            this.txtUsername.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtUsername.StateCommon.Border.Rounding = 15F;
            this.txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Confirm Password";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(10, 219);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(363, 33);
            this.txtConfirm.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtConfirm.StateCommon.Border.Rounding = 15F;
            this.txtConfirm.TabIndex = 4;
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(123, 262);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(109, 34);
            this.btnSignup.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSignup.StateCommon.Border.Rounding = 15F;
            this.btnSignup.TabIndex = 4;
            this.btnSignup.Values.Text = "SIGN UP";
            // 
            // picHidePass
            // 
            this.picHidePass.Image = global::UserControls.Properties.Resources.pHide;
            this.picHidePass.Location = new System.Drawing.Point(325, 162);
            this.picHidePass.Name = "picHidePass";
            this.picHidePass.Size = new System.Drawing.Size(34, 24);
            this.picHidePass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHidePass.TabIndex = 5;
            this.picHidePass.TabStop = false;
            // 
            // picEyePass
            // 
            this.picEyePass.Image = global::UserControls.Properties.Resources.pEye;
            this.picEyePass.Location = new System.Drawing.Point(325, 162);
            this.picEyePass.Name = "picEyePass";
            this.picEyePass.Size = new System.Drawing.Size(34, 24);
            this.picEyePass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyePass.TabIndex = 5;
            this.picEyePass.TabStop = false;
            // 
            // picHideConfirm
            // 
            this.picHideConfirm.Image = global::UserControls.Properties.Resources.pHide;
            this.picHideConfirm.Location = new System.Drawing.Point(325, 223);
            this.picHideConfirm.Name = "picHideConfirm";
            this.picHideConfirm.Size = new System.Drawing.Size(34, 24);
            this.picHideConfirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHideConfirm.TabIndex = 6;
            this.picHideConfirm.TabStop = false;
            // 
            // picEyeConfirm
            // 
            this.picEyeConfirm.Image = global::UserControls.Properties.Resources.pEye;
            this.picEyeConfirm.Location = new System.Drawing.Point(325, 223);
            this.picEyeConfirm.Name = "picEyeConfirm";
            this.picEyeConfirm.Size = new System.Drawing.Size(34, 24);
            this.picEyeConfirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEyeConfirm.TabIndex = 6;
            this.picEyeConfirm.TabStop = false;
            // 
            // txtPasswordSignup
            // 
            this.txtPasswordSignup.Location = new System.Drawing.Point(10, 158);
            this.txtPasswordSignup.Name = "txtPasswordSignup";
            this.txtPasswordSignup.PasswordChar = '*';
            this.txtPasswordSignup.Size = new System.Drawing.Size(363, 33);
            this.txtPasswordSignup.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPasswordSignup.StateCommon.Border.Rounding = 15F;
            this.txtPasswordSignup.TabIndex = 3;
            // 
            // txtEmailSignup
            // 
            this.txtEmailSignup.Location = new System.Drawing.Point(10, 98);
            this.txtEmailSignup.Name = "txtEmailSignup";
            this.txtEmailSignup.Size = new System.Drawing.Size(363, 33);
            this.txtEmailSignup.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtEmailSignup.StateCommon.Border.Rounding = 15F;
            this.txtEmailSignup.TabIndex = 2;
            // 
            // UC_Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picEyeConfirm);
            this.Controls.Add(this.picHideConfirm);
            this.Controls.Add(this.picEyePass);
            this.Controls.Add(this.picHidePass);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.txtPasswordSignup);
            this.Controls.Add(this.txtEmailSignup);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UC_Signup";
            this.Size = new System.Drawing.Size(376, 312);
            ((System.ComponentModel.ISupportInitialize)(this.picHidePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHideConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEyeConfirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonTextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Krypton.Toolkit.KryptonTextBox txtConfirm;
        private TranslatorLibrary.EmailTextbox txtEmailSignup;
        private TranslatorLibrary.PasswordTextbox txtPasswordSignup;
        private Krypton.Toolkit.KryptonButton btnSignup;
        private Krypton.Toolkit.KryptonPictureBox picHidePass;
        private Krypton.Toolkit.KryptonPictureBox picEyePass;
        private Krypton.Toolkit.KryptonPictureBox picHideConfirm;
        private Krypton.Toolkit.KryptonPictureBox picEyeConfirm;
    }
}
