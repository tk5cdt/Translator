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

namespace TranslatorApp
{
    public partial class frmTranslate : KryptonForm
    {
        private int _id;

        Timer timer = new Timer();
        public frmTranslate()
        {
            InitializeComponent();
        }
        public frmTranslate(int id)
        {
            InitializeComponent();
            this._id = id;
        }

        private void frmTranslate_Load(object sender, EventArgs e)
        {
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Translate();
        }

        private void Translate()
        {
            TranslateAPI translateAPI = new TranslateAPI();
            TranslatePostResponse response = translateAPI.sendTranslateContent(kryptonRichTextBox1.Text);
            kryptonRichTextBox2.Text = response.translatedText;
        }

        private void kryptonRichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
