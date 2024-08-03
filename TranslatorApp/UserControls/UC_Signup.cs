using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class UC_Signup : UserControl
    {
        public KryptonButton signup;
        public KryptonTextBox username;
        public KryptonTextBox email;
        public KryptonTextBox password;
        public KryptonTextBox confirmPassword;
        public KryptonPictureBox pEyePass;
        public KryptonPictureBox pHidePass;
        public KryptonPictureBox pEyeConfirm;
        public KryptonPictureBox pHideConfirm;
        public UC_Signup()
        {
            InitializeComponent();
            signup = this.btnSignup;
            username = this.txtUsername;
            email = this.txtEmailSignup;
            password = this.txtPasswordSignup;
            confirmPassword = this.txtConfirm;
            pEyePass = this.picEyePass;
            pHidePass = this.picHidePass;
            pEyeConfirm = this.picEyeConfirm;
            pHideConfirm = this.picHideConfirm;
        }
    }
}
