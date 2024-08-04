using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace UserControls
{
    public partial class item_favorite : UserControl
    {
        public Action<int> DeleteFavorite;

        public KryptonPictureBox KryptonPictureBox;

        public item_favorite()
        {
            InitializeComponent();
            KryptonPictureBox = this.kryptonPictureBox1;
            kryptonPictureBox1.Click += KryptonPictureBox1_Click;
        }

        private void KryptonPictureBox1_Click(object sender, EventArgs e)
        {
            DeleteFavorite?.Invoke(wordid);
        }

        public int wordid
        {
            get;
            set;
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

        public int uid
        {
            get;
            set;
        }


        public KryptonPictureBox GetKryptonPictureBox()
        {
            return this.KryptonPictureBox;
        }

        private void item_favorite_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void item_favorite_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
