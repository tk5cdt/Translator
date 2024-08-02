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

        Timer timer = new Timer();
        public frmTranslate()
        {
            InitializeComponent();
        }

        private void rtbFrom_TextChanged(object sender, EventArgs e)
        {

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
