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
using Krypton.Toolkit;
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
            //InitializeItemHistoryEvents();
            InitializeItemHistory();
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


            //saveFavorite();
        }

        //show list history
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

                    // duyet qua danh sach historyresponse, gan du lieu vao cac item_history va luu vao danh sach control
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

                        // Đăng ký sự kiện
                        newUserControl.OnSaveFavorite = HandleSaveFavorite;

                        userControls.Add(newUserControl);
                    }

                    // duyet qua danh sach control va hien thi len man hinh
                    for (int i = 0; i < userControls.Count; i++)
                    {
                        var control = userControls[i];
                        control.Top = i * (userControlHeight + 6) + 2;

                        int centerX = (panel.ClientSize.Width - userControlWidth) / 2;
                        control.Left = centerX;

                        panel.Controls.Add(control);
                        panel.Controls.SetChildIndex(control, 0);
                    }

                    // Cập nhật vị trí các điều khiển trong panel
                    for (int i = 0; i < panel.Controls.Count; i++)
                    {
                        var control = panel.Controls[i];
                        control.Top = i * (userControlHeight + 6) + 2;

                        int centerX = (panel.ClientSize.Width - userControlWidth) / 2;
                        control.Left = centerX;
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

        private async void frmHistory_Load(object sender, EventArgs e)
        {
            await ShowAsync();
        }

        private void InitializeItemHistory()
        {
            var itemHistoryControl = new item_history();
            itemHistoryControl.OnSaveFavorite = HandleSaveFavorite;
        }

        private void HandleSaveFavorite(string wordfrom, string wordinto, string from, string into, DateTime timesave, int id)
        {
            // Hiển thị thông báo đã lưu
            MessageBox.Show($"Word From: {wordfrom}\nWord Into: {wordinto}\nFrom: {from}\nInto: {into}\nDate: {timesave}\nID: {id}");

            // Lưu dữ liệu yêu thích qua API
            SaveFavoriteAPI saveFavoriteAPI = new SaveFavoriteAPI();
            try
            {
                var result = saveFavoriteAPI.SaveFavoriteContent(wordfrom, wordinto, from, into, _id);
                // Xử lý kết quả lưu thành công
                if (result != null)
                {
                    MessageBox.Show("Yêu thích đã được lưu thành công!");
                }
                else
                {
                    MessageBox.Show("Lưu yêu thích không thành công.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
