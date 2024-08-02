using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace TranslatorLibrary
{
    public class PasswordTextbox:KryptonTextBox
    {
        public PasswordTextbox() {
            this.Validating += PasswordTextbox_Validating;
        }

        private void PasswordTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex emailRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
            String mail = Text;
            Match match = emailRegex.Match(mail);

            if (!match.Success)
            {
                MessageBox.Show("Minimum eight characters, at least one uppercase letter, one number and one special character!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void Check_Password(object sender, EventArgs e)
        //{
        //    Regex emailRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
        //    String mail = Text;
        //    Match match = emailRegex.Match(mail);

        //    if (!match.Success)
        //    {
        //        MessageBox.Show("Minimum eight characters, at least one uppercase letter, one number and one special character!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
    }
}
