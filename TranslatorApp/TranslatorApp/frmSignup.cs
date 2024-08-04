using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Krypton.Toolkit;

namespace TranslatorApp
{
    public partial class frmSignup : KryptonForm
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            uC_Signup1.pEyePass.BackColor = Color.White;
            uC_Signup1.pHidePass.BackColor = Color.White;
            uC_Signup1.pEyeConfirm.BackColor = Color.White;
            uC_Signup1.pHideConfirm.BackColor = Color.White;

            uC_Signup1.signup.Click += Signup_Click;
            uC_Signup1.pEyePass.Click += PEyePass_Click;
            uC_Signup1.pHidePass.Click += PHidePass_Click;
            uC_Signup1.pEyeConfirm.Click += PEyeConfirm_Click;
            uC_Signup1.pHideConfirm.Click += PHideConfirm_Click;
            this.FormClosed += FrmSignup_FormClosed;
        }

        private void FrmSignup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainForm.Show();
        }

        private void PHideConfirm_Click(object sender, EventArgs e)
        {
            if (uC_Signup1.confirmPassword != null)
            {
                if (uC_Signup1.confirmPassword.PasswordChar == '\0')
                {
                    uC_Signup1.pEyeConfirm.BringToFront();
                    uC_Signup1.confirmPassword.PasswordChar = '*';
                }
            }
        }

        private void PEyeConfirm_Click(object sender, EventArgs e)
        {
            if (uC_Signup1.confirmPassword != null)
            {
                if (uC_Signup1.confirmPassword.PasswordChar == '*')
                {
                    uC_Signup1.pHideConfirm.BringToFront();
                    uC_Signup1.confirmPassword.PasswordChar = '\0';
                }
            }
        }

        private void PHidePass_Click(object sender, EventArgs e)
        {
            if (uC_Signup1.password != null)
            {
                if (uC_Signup1.password.PasswordChar == '\0')
                {
                    uC_Signup1.pEyePass.BringToFront();
                    uC_Signup1.password.PasswordChar = '*';
                }
            }
        }

        private void PEyePass_Click(object sender, EventArgs e)
        {
            if (uC_Signup1.password != null)
            {
                if (uC_Signup1.password.PasswordChar == '*')
                {
                    uC_Signup1.pHidePass.BringToFront();
                    uC_Signup1.password.PasswordChar = '\0';
                }
            }
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            UserAPI userAPI = new UserAPI();
            if (!string.IsNullOrEmpty(uC_Signup1.email.Text) && !string.IsNullOrEmpty(uC_Signup1.password.Text) && !string.IsNullOrEmpty(uC_Signup1.username.Text) && !string.IsNullOrEmpty(uC_Signup1.confirmPassword.Text))
            {
                SignupPostReponse response = userAPI.sendSignupContent(uC_Signup1.username.Text, uC_Signup1.email.Text, uC_Signup1.password.Text, uC_Signup1.confirmPassword.Text);

                if (response.IsSuccess)
                {
                    //frmTranslate frm = new frmTranslate();
                    frmLogin frm = new frmLogin();
                    ////frm.MdiParent = this;
                    //frmHistory frm = new frmHistory();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(response.message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter all required information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.loginForm = new frmLogin();
            Program.loginForm.Show();
            this.Hide();
        }
    }
}
