using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
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
        HistoryAPI historyAPI;

        public frmHistory(int id)
        {
            InitializeComponent();
            InitializeItemHistory();

            userControls = new List<item_history>();

            userControlHeight = 130;
            userControlWidth = 600;

        }

        //show list history
        private async Task ShowAsync()
        {
            // Khởi tạo HistoryAPI và lấy dữ liệu
            historyAPI = new HistoryAPI();

            try
            {
                List<HistoryReponse> historyReponses = await historyAPI.LoadHistoryContent(UserSession.Instance.Uid);

                // Xóa các điều khiển cũ
                kryptonPanel1.Controls.Clear();

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

                            from = history.fromlanguage,
                            into = history.tolanguage,
                            wordFrom = history.originalword,
                            wordInto = history.translatedword,
                            wordid = history.wordid,
                            isfavorite = history.isfavorite,
                        };

                        // Đăng ký sự kiện
                        newUserControl.OnSaveFavorite = HandleSaveFavorite;
                        newUserControl.OnDeleteHistory = HandleDeleteHistory;

                        newUserControl.UpdateFavoriteStatus(history.isfavorite);

                        userControls.Add(newUserControl);
                    }

                    // duyet qua danh sach control va hien thi len man hinh
                    for (int i = 0; i < userControls.Count; i++)
                    {
                        var control = userControls[i];
                        control.Top = i * (userControlHeight + 6) + 2;

                        int centerX = (kryptonPanel1.ClientSize.Width - userControlWidth) / 2;
                        control.Left = centerX;
                        
                        kryptonPanel1.Controls.Add(control);
                        kryptonPanel1.Controls.SetChildIndex(control, 0);
                    }

                    // Cập nhật vị trí các điều khiển trong panel
                    for (int i = 0; i < kryptonPanel1.Controls.Count; i++)
                    {
                        var control = kryptonPanel1.Controls[i];
                        control.Top = i * (userControlHeight + 6) + 2;

                        int centerX = (kryptonPanel1.ClientSize.Width - userControlWidth) / 2;
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
            itemHistoryControl.OnDeleteHistory = HandleDeleteHistory;
            
        }

        private void HandleSaveFavorite(string wordfrom, string wordinto, string from, string into, int wordid, KryptonPictureBox kryptonPicture, bool isfavorite)
        {
            // Lưu dữ liệu yêu thích qua API
            SaveFavoriteAPI saveFavoriteAPI = new SaveFavoriteAPI();
            HistoryAPI historyAPI = new HistoryAPI();

            try
            {
                if (!isfavorite)
                {
                    var result = saveFavoriteAPI.SaveFavoriteContent(wordfrom, wordinto, from, into, wordid, UserSession.Instance.Uid);
                    // Xử lý kết quả lưu thành công
                    if (result != null)
                    {
                        // Cập nhật trạng thái isfavorite
                        isfavorite = true;
                        historyAPI.UpdateHistory(isfavorite, wordid, UserSession.Instance.Uid);

                        // Cập nhật icon và trạng thái cho tất cả các item_history
                        foreach (var control in kryptonPanel1.Controls.OfType<item_history>())
                        {
                            if (control.wordid == wordid)
                            {
                                control.UpdateFavoriteStatus(isfavorite);
                                kryptonPicture.Image = Properties.Resources.save_click;
                                break;
                            }
                        }

                        MessageBox.Show("Yêu thích đã được lưu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lưu yêu thích không thành công.");
                    }
                }
                else
                {
                    FavoriteAPI favoriteAPI = new FavoriteAPI();
                    favoriteAPI.DeleteFavoriteInHistory(wordid, UserSession.Instance.Uid);
                    isfavorite = false;

                    historyAPI.UpdateHistory(isfavorite, wordid, UserSession.Instance.Uid);

                    // Cập nhật icon và trạng thái cho tất cả các item_history
                    foreach (var control in kryptonPanel1.Controls.OfType<item_history>())
                    {
                        if (control.wordid == wordid)
                        {
                            control.UpdateFavoriteStatus(isfavorite);
                            kryptonPicture.Image = Properties.Resources.save;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        private void HandleDeleteHistory(int wordid)
        {
            // Lưu dữ liệu yêu thích qua API
            HistoryAPI historyAPI = new HistoryAPI();
            try
            {
                //MessageBox.Show("wordid: " + wordid);
                var result = historyAPI.DeleteHistoryContent(wordid, UserSession.Instance.Uid);
                // Xử lý kết quả lưu thành công
                if (result != null)
                {
                    MessageBox.Show("Xóa lịch sử thành công!");
                    ShowAsync();
                }
                else
                {
                    MessageBox.Show("Xóa lịch sử không thành công.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void kryptonPictureBox1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                HistoryAPI historyAPI = new HistoryAPI();
                try
                {
                    var result = historyAPI.DeleteAllHistory(UserSession.Instance.Uid);
                    if (result != null)
                    {
                        MessageBox.Show("Xóa thành công!");
                        ShowAsync(); // Load lại danh sách sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
