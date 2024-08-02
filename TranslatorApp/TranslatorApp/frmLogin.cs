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
            uC_Login1.login.Click += UC_Login1_Click;
        }

        private void UC_Login1_Click(object sender, EventArgs e)
        {
            UserAPI userAPI = new UserAPI();
            if (!string.IsNullOrEmpty(uC_Login1.email.Text) || !string.IsNullOrEmpty(uC_Login1.password.Text))
            {
                LoginPostReponse reponse = userAPI.sendLoginContent(uC_Login1.email.Text, uC_Login1.password.Text);
                if (reponse != null)
                {
                    frmTranslate frm = new frmTranslate();
                    //frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Email hoặc mật khẩu sai. Vui lòng nhập lại!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
