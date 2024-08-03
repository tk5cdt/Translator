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
using BLL;

namespace UserControls
{
    public partial class item_history : UserControl
    {
        public Action<string, string, string, string, DateTime, int> OnSaveFavorite;

        public KryptonPictureBox KryptonPictureBox;
        public item_history()
        {
            InitializeComponent();
            KryptonPictureBox = this.kryptonPictureBox1;
            kryptonPictureBox1.Click += KryptonPictureBox1_Click;
        }

        private async void KryptonPictureBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cu tui dii");
            ////GetKryptonPictureBox();
            OnSaveFavorite?.Invoke(lbl_wordfrom.Text, lbl_wordinto.Text, lbl_from.Text, lbl_into.Text, DateTime.Now, uid);

            //SaveFavoriteAPI saveFavoriteAPI = new SaveFavoriteAPI();
            //try
            //{
            //    var result = await saveFavoriteAPI.SaveFavoriteContent(lbl_wordfrom.Text, lbl_wordinto.Text, lbl_from.Text, lbl_into.Text, uid);
            //    // Xử lý kết quả lưu thành công
            //    if (result != null)
            //    {
            //        MessageBox.Show("Yêu thích đã được lưu thành công!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lưu yêu thích không thành công.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
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

        private void item_history_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void item_history_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        public KryptonPictureBox GetKryptonPictureBox()
        {
            return this.KryptonPictureBox;
        }

        private void item_history_Load(object sender, EventArgs e)
        {
            
        }

    }
}
