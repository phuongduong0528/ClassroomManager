using ClassroomManager.App.Controller;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdatePhongHocWindow.xaml
    /// </summary>
    public partial class AddPhongHocWindow : Window
    {
        private string toaNha;
        private PhongHocController phongHocController;
        public AddPhongHocWindow()
        {
            InitializeComponent();
        }

        public AddPhongHocWindow(string nha)
        {
            InitializeComponent();
            toaNha = nha;
            phongHocController = new PhongHocController(Ultilities.ip, Ultilities.port);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxLoaiPhong.ItemsSource = await phongHocController.GetLoaiPhong();
            cbxLoaiPhong.SelectedIndex = 0;
        }

        private async void Okbutton_Click(object sender, RoutedEventArgs e)
        {
            if(txtbName.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            PhongHocDto phongHocDto = new PhongHocDto();
            phongHocDto.MaPhong = 0;
            phongHocDto.CoSo = "";
            phongHocDto.ToaNha = toaNha;
            phongHocDto.TenPhong = txtbName.Text;
            phongHocDto.LoaiPhong = cbxLoaiPhong.SelectedItem.ToString();
            phongHocDto.GhiChu = "";
            bool re = await phongHocController.Add(phongHocDto);
            if (re)
            {
                MessageBox.Show("Đã thêm thành công", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thêm", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
