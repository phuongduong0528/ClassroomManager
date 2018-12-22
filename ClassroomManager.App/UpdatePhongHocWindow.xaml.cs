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
    public partial class UpdatePhongHocWindow : Window
    {
        private PhongHocDto phongHocDto;
        private PhongHocController phongHocController;
        public UpdatePhongHocWindow()
        {
            InitializeComponent();
        }
        public UpdatePhongHocWindow(PhongHocDto phongHocDto)
        {
            InitializeComponent();
            this.phongHocDto = phongHocDto;
            phongHocController = new PhongHocController(Ultilities.ip, Ultilities.port);
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtbName2.Text = phongHocDto.TenPhong;
                cbxLoaiPhong.ItemsSource = await phongHocController.GetLoaiPhong();
                cbxLoaiPhong.SelectedItem = phongHocDto.LoaiPhong;
                cbxCoSo.ItemsSource = await phongHocController.GetCoSo();
                cbxCoSo.SelectedItem = phongHocDto.CoSo;
                cbxToaNha.ItemsSource = await phongHocController.GetNha(phongHocDto.CoSo);
                cbxToaNha.SelectedItem = phongHocDto.ToaNha;
                rtbGhiChu.Document.Blocks.Add(new Paragraph(new Run(phongHocDto.GhiChu)));
            }
            catch (Exception)
            {
                MessageBox.Show("Lựa chọn không hợp lệ","",MessageBoxButton.OK,MessageBoxImage.Error);
                this.Close();
            }
            
        }

        private async void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            PhongHocDto temp = new PhongHocDto();
            temp.MaPhong = phongHocDto.MaPhong;
            temp.CoSo = cbxCoSo.SelectedItem.ToString();
            temp.GhiChu = new TextRange(rtbGhiChu.Document.ContentStart, rtbGhiChu.Document.ContentEnd).Text;
            temp.LoaiPhong = cbxLoaiPhong.SelectedItem.ToString();
            temp.TenPhong = txtbName2.Text;
            temp.ToaNha = cbxToaNha.SelectedItem.ToString();

            bool re = await phongHocController.Update(temp);
            if (re)
            {
                MessageBox.Show("Đã sửa thành công", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thêm", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
