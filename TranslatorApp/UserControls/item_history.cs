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
    public partial class item_history : UserControl
    {
        public item_history()
        {
            InitializeComponent();

        }

        public string from
        {
            get { return lbl_from.Text; }
            set { lbl_from.Text = value; }
        }

        public string wordFrom
        {
            get { return lbl_wordfrom.Text; }
            set { lbl_wordfrom.Text = value; }
        }

        public string into
        {
            get { return lbl_into.Text; }
            set { lbl_into.Text = value; }
        }

        public string wordInto
        {
            get { return lbl_wordinto.Text; }
            set { lbl_wordinto.Text = value; }
        }

    }
}
