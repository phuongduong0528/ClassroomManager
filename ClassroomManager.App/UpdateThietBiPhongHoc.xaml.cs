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
    /// Interaction logic for UpdateThietBiPhongHoc.xaml
    /// </summary>
    public partial class UpdateThietBiPhongHoc : Window
    {
        private string phongHoc;
        private ThietBiPhongHocController controller;
        private ThietBiController thietBi;
        private ThietBiPhongHocDto thietBiDto;
        public UpdateThietBiPhongHoc()
        {
            InitializeComponent();
        }
        public UpdateThietBiPhongHoc(string phong)
        {
            InitializeComponent();
            phongHoc = phong;
            thietBiDto = null;
            controller = new ThietBiPhongHocController(Ultilities.ip, Ultilities.port);
            thietBi = new ThietBiController(Ultilities.ip, Ultilities.port);
        }

        public UpdateThietBiPhongHoc(ThietBiPhongHocDto pthietBi)
        {
            InitializeComponent();
            this.thietBiDto = pthietBi;
            controller = new ThietBiPhongHocController(Ultilities.ip, Ultilities.port);
            thietBi = new ThietBiController(Ultilities.ip, Ultilities.port);
            txtbPhong.IsEnabled = true;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxThietBi.ItemsSource = (await thietBi.GetAll()).Select(tb=>tb.TenThietBi).ToList();
            cbxThietBi.SelectedIndex = 0;
            txtbPhong.Text = phongHoc;
            if(thietBiDto != null)
            {
                cbxThietBi.SelectedItem = thietBiDto.ThietBi;
                txtbSoLuong.Text = thietBiDto.SoLuong.ToString();
                txtbPhong.Text = thietBiDto.Phong;
            }
        }

        private async void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(thietBiDto == null)
                {
                    ThietBiPhongHocDto thietBiTemp = new ThietBiPhongHocDto();
                    thietBiTemp.Phong = phongHoc;
                    thietBiTemp.SoLuong = Convert.ToInt32(txtbSoLuong.Text);
                    thietBiTemp.ThietBi = cbxThietBi.SelectedItem.ToString();
                    bool re = await controller.AddThietBi(thietBiTemp);
                    if (!re)
                    {
                        MessageBox.Show("Không thể thêm", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    ThietBiPhongHocDto thietBiTemp = this.thietBiDto;
                    thietBiTemp.Id = thietBiDto.Id;
                    thietBiTemp.Phong = txtbPhong.Text;
                    thietBiTemp.SoLuong = Convert.ToInt32(txtbSoLuong.Text);
                    thietBiTemp.ThietBi = cbxThietBi.SelectedItem.ToString();
                    bool re = await controller.UpdateThietBi(thietBiTemp);
                    if (!re)
                    {
                        MessageBox.Show("Không thể sửa", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
