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
            timer.Interval = 1200;
            timer.Tick += Timer_Tick;
            loadFromCbb();
            loadToCbb();
        }

        private void loadFromCbb()
        {
            TranslateAPI translateAPI = new TranslateAPI();
            List<Languages> languages = translateAPI.GetLanguages();
            Languages lang = new Languages();
            lang.code = "auto";
            lang.name = "Detect language";
            languages.Insert(0, lang);
            cbbFromLanguage.DisplayMember = "name";
            cbbFromLanguage.ValueMember = "code";
            cbbFromLanguage.DataSource = languages.Where(l => l.code != "vi").ToList<Languages>();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Translate();
            //saveHistory();
        }
        public async void saveHistory()
        {
            SaveHistoryAPI saveHistoryAPI = new SaveHistoryAPI();
            await saveHistoryAPI.SaveHistoryContent(kryptonRichTextBox1.Text, kryptonRichTextBox2.Text, "en", "en", DateTime.Now, _id);

        }

        private void Translate()
        {
            string q = kryptonRichTextBox1.Text;
            string source = cbbFromLanguage.SelectedValue.ToString();
            string target = cbbToLanguage.SelectedValue.ToString();
            TranslateAPI translateAPI = new TranslateAPI();
            TranslatePostResponse response = translateAPI.sendTranslateContent(q, source, target);
            kryptonRichTextBox2.Text = response.translatedText;
            if (cbbFromLanguage.SelectedIndex == 0)
            {
                string lang = response.detectedLanguage.language;
                List<Languages> languages = new List<Languages>();
                languages = (List<Languages>)cbbFromLanguage.DataSource;
                string langDetected = languages.Where(x => x.code == lang).FirstOrDefault().name;
                label1.Text = "Detected language: " + langDetected + "; Confidence: " + response.detectedLanguage.confidence + "%";
            }
        }

        private void kryptonRichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHistory frm = new frmHistory(_id);
            frm.Show();
        }

        private void cbbFromLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadToCbb()
        {
            TranslateAPI translateAPI = new TranslateAPI();
            List<Languages> languages = translateAPI.GetLanguages();
            cbbToLanguage.DisplayMember = "name";
            cbbToLanguage.ValueMember = "code";
            cbbToLanguage.DataSource = languages.Where(l => l.code != "vi").ToList<Languages>();
        }
    }
}
