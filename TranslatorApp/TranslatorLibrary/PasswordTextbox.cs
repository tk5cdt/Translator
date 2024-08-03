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
            this.Leave += PasswordTextbox_Leave;
        }

        private void PasswordTextbox_Leave(object sender, EventArgs e)
        {
            Regex passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
            String password = Text;
            Match match = passwordRegex.Match(password);

            if (!match.Success)
            {
                MessageBox.Show("Minimum eight characters, at least one uppercase letter, one number and one special character!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
