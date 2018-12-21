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
    /// Interaction logic for QLPhongHocWindow.xaml
    /// </summary>
    public partial class QLPhongHocWindow : Window
    {
        private string phongHoc;
        private ThietBiPhongHocController tbController;
        private ThongTinBanGiaoController bgController;
        public QLPhongHocWindow()
        {
            InitializeComponent();
        }

        public QLPhongHocWindow(string phong)
        {
            InitializeComponent();
            phongHoc = phong;
        }

        private void BtnThem2_Click(object sender, RoutedEventArgs e)
        {
            if(tabControl.SelectedIndex == 0)
            {
                UpdateThietBiPhongHoc window = new UpdateThietBiPhongHoc(phongHoc);
                window.Closed += Window_Closed;
                window.Show();
            }
            else
            {

            }
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                gvThietBiPhong.ItemsSource = await tbController.GetByClass(phongHoc);
                gvBanGiao.ItemsSource =
                    await bgController.GetByMonth(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void BtnUpdate2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ThietBiPhongHocDto currentItem = gvThietBiPhong.SelectedItem as ThietBiPhongHocDto;
                UpdateThietBiPhongHoc window = new UpdateThietBiPhongHoc(currentItem);
                window.Closed += Window_Closed;
                window.Show();
            }
            catch (Exception)
            {

            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbController = new ThietBiPhongHocController(Ultilities.ip, Ultilities.port);
            bgController = new ThongTinBanGiaoController(Ultilities.ip, Ultilities.port);
            gvThietBiPhong.ItemsSource = await tbController.GetByClass(phongHoc);
            cbxMonth.SelectedItem = DateTime.Now.Month;
            gvBanGiao.ItemsSource = 
                await bgController.GetByMonth(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
        }
    }
}
