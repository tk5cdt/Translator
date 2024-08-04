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
    public class EmailTextbox: KryptonTextBox
    {
        public EmailTextbox()
        {
            this.Leave += EmailTextbox_Leave;
        }

        private void EmailTextbox_Leave(object sender, EventArgs e)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            String mail = Text;
            Match match = emailRegex.Match(mail);

            if (!match.Success)
            {
                MessageBox.Show("Email is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
