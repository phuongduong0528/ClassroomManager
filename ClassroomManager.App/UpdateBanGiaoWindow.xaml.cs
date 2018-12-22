using ClassroomManager.App.Controller;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClassroomManager.App
{
    /// <summary>
    /// Interaction logic for UpdateBanGiaoWindow.xaml
    /// </summary>
    public partial class UpdateBanGiaoWindow : Window
    {
        private string phongHoc;
        private ThongTinBanGiaoController controller;
        public UpdateBanGiaoWindow()
        {
            InitializeComponent();
        }

        public UpdateBanGiaoWindow(string phongHoc)
        {
            InitializeComponent();
            this.phongHoc = phongHoc;
            controller = new ThongTinBanGiaoController(Ultilities.ip, Ultilities.port);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            ThongTinBanGiaoDto temp = new ThongTinBanGiaoDto();
            temp.Ngay = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            temp.NguoiDung = Ultilities.userName;
            temp.Phong = phongHoc;
            temp.TinhTrang = new TextRange(rtbTinhTrang.Document.ContentStart, rtbTinhTrang.Document.ContentEnd).Text;
            if(temp.TinhTrang == "")
            {
                MessageBox.Show("Mục tình trạng không được để trống", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool re = await controller.Add(temp);
            if (re)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thêm", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
