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
using UserControls;
using BLL;

namespace TranslatorApp
{
    public partial class frmFavorite : KryptonForm
    {

        private List<item_history> userControls;
        private int userControlHeight;
        private int userControlWidth;

        private Panel panel;
        private int _id;
        public frmFavorite(int id)
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


        }
        //show list history
        private async Task ShowAsync()
        {
            // Khởi tạo HistoryAPI và lấy dữ liệu
            FavoriteAPI favoriteAPI = new FavoriteAPI();

            try
            {
                List<FavoriteResponse> favoriteResponses = await favoriteAPI.LoadFavoriteContent(_id);

                // Xóa các điều khiển cũ
                panel.Controls.Clear();

                if (favoriteResponses != null && favoriteResponses.Count > 0)
                {
                    List<Control> userControls = new List<Control>();

                    // duyet qua danh sach historyresponse, gan du lieu vao cac item_history va luu vao danh sach control
                    for (int i = 0; i < favoriteResponses.Count; i++)
                    {
                        var history = favoriteResponses[i];

                        item_history newUserControl = new item_history
                        {
                            Width = userControlWidth,
                            Height = userControlHeight,
                            Anchor = AnchorStyles.Top,

                        };
                        newUserControl.from = favoriteResponses[i].fromlanguage;
                        newUserControl.into = favoriteResponses[i].tolanguage;
                        newUserControl.wordFrom = favoriteResponses[i].originalword;
                        newUserControl.wordInto = favoriteResponses[i].translatedword;
                        //newUserControl.timeSave = DateTime.Parse(historyReponses[i].timesave);


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

        private void frmFavorite_Load(object sender, EventArgs e)
        {
            ShowAsync();
        }
    }
}
