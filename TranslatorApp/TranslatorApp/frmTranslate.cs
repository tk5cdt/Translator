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
using System.Speech.Synthesis;
using System.Globalization;

namespace TranslatorApp
{
    public partial class frmTranslate : KryptonForm
    {
        private int _id;
        
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
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
            timer.Interval = 1000;
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
        }

        private void loadAlternatives(TranslatePostResponse response)
        {
            tbAlternatives.Text = string.Empty;
            if (response.alternatives != null)
            {
                var count = 0;
                foreach (var item in response.alternatives)
                {
                    tbAlternatives.Text += ++count + ". " + item + "\n";
                }
                tbAlternatives.Text = tbAlternatives.Text.Trim();
            }
        }

        public async void saveHistory(string origi, string trans, string fromlang, string tolang, DateTime dt, int _id, bool isfavorite)
        {
            SaveHistoryAPI saveHistoryAPI = new SaveHistoryAPI();
            try
            {
                Languages lang = new Languages();
                
                var result = await saveHistoryAPI.SaveHistoryContent(origi, trans, fromlang, tolang, dt, UserSession.Instance.Uid, isfavorite);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private async void Translate()
        {
            if (kryptonRichTextBox1.Text == string.Empty)
            {
                kryptonRichTextBox2.Text = string.Empty;
                return;
            }
            string q = kryptonRichTextBox1.Text;
            string source = cbbFromLanguage.SelectedValue.ToString();
            string target = cbbToLanguage.SelectedValue.ToString();
            TranslateAPI translateAPI = new TranslateAPI();
            TranslatePostResponse response = await translateAPI.sendTranslateContent(q, source, target);
            kryptonRichTextBox2.Text = response.translatedText;
            if (cbbFromLanguage.SelectedIndex == 0)
            {
                string lang = response.detectedLanguage.language;
                List<Languages> languages = new List<Languages>();
                languages = (List<Languages>)cbbFromLanguage.DataSource;
                string langDetected = languages.Where(x => x.code == lang).FirstOrDefault().name;
                label1.Text = "Detected language: " + langDetected + "\nConfidence: " + response.detectedLanguage.confidence + "%";

                saveHistory(kryptonRichTextBox1.Text, kryptonRichTextBox2.Text, langDetected, target, DateTime.Now, UserSession.Instance.Uid, false);
            }
            loadAlternatives(response);
        }

        private void kryptonRichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = string.Empty;
            timer.Stop();
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmHistory frm = new frmHistory(_id);
            frmFavorite frm = new frmFavorite(_id);
            frm.Show();
        }

        private void cbbFromLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kryptonRichTextBox1.Text != string.Empty)
                Translate();
        }

        private void loadToCbb()
        {
            TranslateAPI translateAPI = new TranslateAPI();
            List<Languages> languages = translateAPI.GetLanguages();
            cbbToLanguage.DisplayMember = "name";
            cbbToLanguage.ValueMember = "code";
            cbbToLanguage.DataSource = languages.Where(l => l.code != "vi").ToList<Languages>();
        }

        private void cbbToLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(kryptonRichTextBox1.Text != string.Empty)
                Translate();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonRichTextBox1.Text == string.Empty) return;
            string lang = cbbFromLanguage.SelectedValue.ToString();
            if (cbbFromLanguage.SelectedValue.ToString() == "auto")
            {
                List<Languages> languages = (List<Languages>)cbbFromLanguage.DataSource;
                lang = languages.Where(x => x.name == label1.Text.Split('\n')[0].Split(':')[1].Trim()).FirstOrDefault().code;
            }
                
            speechSynthesizer.Dispose();
            speechSynthesizer = new SpeechSynthesizer();
            var voice = speechSynthesizer.GetInstalledVoices();

            speechSynthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo(lang));
            speechSynthesizer.SpeakAsync(kryptonRichTextBox1.Text);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (kryptonRichTextBox2.Text == string.Empty) return;
            speechSynthesizer.Dispose();
            speechSynthesizer = new SpeechSynthesizer();
            var voice = speechSynthesizer.GetInstalledVoices();

            speechSynthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo(cbbToLanguage.SelectedValue.ToString()));
            speechSynthesizer.SpeakAsync(kryptonRichTextBox2.Text);
        }
    }
}
