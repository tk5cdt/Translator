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
    public partial class item_history : UserControl
    {
        public Action<int> OnDeleteHistory;
        public Action<string, string, string, string,int, KryptonPictureBox, bool> OnSaveFavorite;

        public item_history()
        {
            InitializeComponent();
            kryptonPictureBox1.Click += KryptonPictureBox1_Click;
            UpdateFavoriteStatus(isfavorite);
        }

        private async void KryptonPictureBox1_Click(object sender, EventArgs e)
        {
            OnSaveFavorite?.Invoke(lbl_wordfrom.Text, lbl_wordinto.Text, lbl_from.Text, lbl_into.Text, wordid, kryptonPictureBox1, isfavorite);
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

        public int wordid
        {
            get;
            set;
        }

        public bool isfavorite
        { get; set; }

        private void item_history_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void item_history_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void item_history_Load(object sender, EventArgs e)
        {

        }

        public void setIcon(bool isfavorite)
        {
            if (isfavorite == true)
            {

            }
        }
        public void UpdateFavoriteStatus(bool favorite)
        {
            this.isfavorite = favorite;
            kryptonPictureBox1.Image = favorite ? Properties.Resources.save_click : Properties.Resources.save;
        }


        private void kryptonPictureBox2_Click(object sender, EventArgs e)
        {
            OnDeleteHistory?.Invoke(wordid);
        }
    }
}
