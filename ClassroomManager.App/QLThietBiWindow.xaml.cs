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
    /// Interaction logic for QLThietBiWindow.xaml
    /// </summary>
    public partial class QLThietBiWindow : Window
    {
        private ThietBiController controller;
        public QLThietBiWindow()
        {
            InitializeComponent();
            controller = new ThietBiController(Ultilities.ip, Ultilities.port);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gvThietBi.ItemsSource = await controller.GetAll();
            cbxLoaiTb.ItemsSource = await controller.GetNhomTB();
            cbxLoaiTb.SelectedIndex = 0;
        }

        private void GvThietBi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ThietBiDto currentItem = gvThietBi.SelectedItem as ThietBiDto;
                cbxLoaiTb.SelectedItem = currentItem.NhomThietBi;
                txtbSoLuong.Text = currentItem.TongSoLuong.ToString();
                txtbTenTB.Text = currentItem.TenThietBi;
            }
            catch (Exception)
            {

            }
        }

        private async void BtnThemQLTB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ThietBiDto> allTB = await controller.GetAll();
                ThietBiDto temp = new ThietBiDto();
                temp.NhomThietBi = cbxLoaiTb.SelectedItem.ToString();
                temp.TenThietBi = txtbTenTB.Text;
                temp.TongSoLuong = Convert.ToInt32(txtbSoLuong.Text);
                if (allTB.Any(tb => tb.TenThietBi.Equals(temp.TenThietBi)))
                {
                    MessageBox.Show("", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    return;
                }
                bool re = await controller.Add(temp);
                gvThietBi.ItemsSource = await controller.GetAll();
            }
            catch (Exception)
            {

            }
        }

        private void TxtbSoLuong_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidInteger((sender as TextBox).Text + e.Text);
        }

        public static bool IsValidInteger(string input)
        {
            int i;
            return int.TryParse(input, out i);
        }

        private async void BtnUpdateQLTB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ThietBiDto> allTB = await controller.GetAll();
                ThietBiDto temp = gvThietBi.SelectedItem as ThietBiDto;
                temp.NhomThietBi = cbxLoaiTb.SelectedItem.ToString();
                temp.TenThietBi = txtbTenTB.Text;
                temp.TongSoLuong = Convert.ToInt32(txtbSoLuong.Text);
                bool re = await controller.Update(temp);
                gvThietBi.ItemsSource = await controller.GetAll();
            }
            catch (Exception)
            {

            }
        }
    }
}
