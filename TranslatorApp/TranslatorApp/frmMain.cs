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
    public partial class frmMain : KryptonForm
    {
        Form child;
        public frmMain()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mTranslate.PerformClick();
            updateLoginButton();
        }

        private void updateLoginButton()
        {
            if (UserSession.Instance.Username != null)
            {
                mLogin.Text = UserSession.Instance.Username;
                mLogin.Click -= MLogin_Click;
                mLogout.Visible = true;
            }
            else
            {
                mLogin.Click += MLogin_Click;
                mLogin.Enabled = true;
                mLogout.Visible = false;
            }
        }

        private void MLogin_Click(object sender, EventArgs e)
        {
            Program.loginForm = new frmLogin();
            Program.loginForm.Show();
            Program.mainForm.Hide();
        }

        private void mTranslate_Click_1(object sender, EventArgs e)
        {
            if (child != null) child.Close();
            frmTranslate frm = new frmTranslate();
            child = frm;
            frm.MdiParent = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //private void mHistory_Click(object sender, EventArgs e)
        //{
        //    if ()
        //        if (child != null) child.Close();
        //    frmHistory frm = new frmHistory();
        //    child = frm;
        //    frm.MdiParent = this;
        //    frm.TopLevel = false;
        //    frm.FormBorderStyle = FormBorderStyle.None;
        //    frm.Dock = DockStyle.Fill;
        //    frm.Show();
        //}
    }
}
