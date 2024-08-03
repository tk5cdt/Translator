using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ComponentFactory.Krypton.Toolkit;
using UserControls;

namespace TranslatorApp
{
    public partial class frmHistory : KryptonForm
    {
        private List<item_history> userControls;
        private int userControlHeight;
        private int userControlWidth;
        private Panel panel;
        private int _id;

        public frmHistory(int id)
        {
            InitializeComponent();
            this._id = id;

            userControls = new List<item_history>();

            userControlHeight = 130;
            userControlWidth = 600;

            panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(panel);

            Button buttonShowUserControl = new Button
            {
                Text = "Show User Control",
                Dock = DockStyle.Top // Đặt button ở phía trên cùng của Form
            };
            buttonShowUserControl.Click += ButtonShowUserControl_Click;
            this.Controls.Add(buttonShowUserControl);
        }


        private void ButtonShowUserControl_Click(object sender, EventArgs e)
        {
            //ShowAsync();
        }

        private async Task ShowAsync()
        {
            // Khởi tạo HistoryAPI và lấy dữ liệu
            HistoryAPI historyAPI = new HistoryAPI();

            try
            {
                List<HistoryReponse> historyReponses = await historyAPI.LoadHistoryContent(_id);

                // Xóa các điều khiển cũ
                panel.Controls.Clear();

                if (historyReponses != null && historyReponses.Count > 0)
                {
                    List<Control> userControls = new List<Control>();

                    for (int i = 0; i < historyReponses.Count; i++)
                    {
                        var history = historyReponses[i];

                        item_history newUserControl = new item_history
                        {
                            Width = userControlWidth,
                            Height = userControlHeight,
                            Anchor = AnchorStyles.Top,
                            
                        };
                        newUserControl.from = historyReponses[i].fromlanguage;
                        newUserControl.into = historyReponses[i].tolanguage;
                        newUserControl.wordFrom = historyReponses[i].originalword;
                        newUserControl.wordInto = historyReponses[i].translatedword;
                        //newUserControl.timeSave = DateTime.Parse(historyReponses[i].timesave);

                        userControls.Add(newUserControl);
                    }

                    for (int i = 0; i < userControls.Count; i++)
                    {
                        var control = userControls[i];
                        control.Top = i * (userControlHeight + 6);

                        int centerX = (panel.ClientSize.Width - userControlWidth) / 2;
                        control.Left = centerX;

                        panel.Controls.Add(control);
                    }
                }
                else
                {
                    Console.WriteLine("No history found.");
                }
            }
            catch (Exception ex)
            {
                // In chi tiết lỗi để xử lý
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }


        private void frmHistory_Load(object sender, EventArgs e)
        {
            ShowAsync();
        }
    }
}
