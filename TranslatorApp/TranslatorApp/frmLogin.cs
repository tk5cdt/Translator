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
    public partial class frmLogin : KryptonForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            uC_Login1.pEye.BackColor = Color.White;
            uC_Login1.pHide.BackColor = Color.White;

            uC_Login1.login.Click += UC_Login1_Click;
            uC_Login1.pEye.Click += PEye_Click;
            uC_Login1.pHide.Click += PHide_Click;
            llbSignup.Click += LlbSignup_Click;
        }

        private void LlbSignup_Click(object sender, EventArgs e)
        {
            frmSignup frm = new frmSignup();
            frm.Show();
            this.Hide();
        }

        private void PHide_Click(object sender, EventArgs e)
        {
            if (uC_Login1.password != null)
            {
                if (uC_Login1.password.PasswordChar == '*')
                {
                    uC_Login1.pEye.BringToFront();
                    uC_Login1.password.PasswordChar = '\0';
                }
            }
            
        }

        private void PEye_Click(object sender, EventArgs e)
        {
            if (uC_Login1.password != null)
            {
                if (uC_Login1.password.PasswordChar == '\0')
                {
                    uC_Login1.pHide.BringToFront();
                    uC_Login1.password.PasswordChar = '*';
                }
            }           
        }

        private void UC_Login1_Click(object sender, EventArgs e)
        {
            UserAPI userAPI = new UserAPI();
            if (!string.IsNullOrEmpty(uC_Login1.email.Text) && !string.IsNullOrEmpty(uC_Login1.password.Text))
            {
                LoginPostReponse reponse = userAPI.sendLoginContent(uC_Login1.email.Text, uC_Login1.password.Text);

                if (reponse != null)
                {
                    //frmTranslate frm = new frmTranslate();
                    frmTranslate frm = new frmTranslate(reponse.UID);
                    ////frm.MdiParent = this;
                    //frmHistory frm = new frmHistory();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect email or password. Please re-enter!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                MessageBox.Show("Please enter all required information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
