using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace UserControls
{
    public partial class UC_Login: UserControl
    {
        public KryptonButton login;
        public KryptonTextBox email;
        public KryptonTextBox password;
        public UC_Login()
        {
            InitializeComponent();
            login = this.btnLogin;
            email = this.txtEmail;
            password = this.txtPassword;
        }
    }
}
