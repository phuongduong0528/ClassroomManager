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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassroomManager.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhongHocController phongHocController;
        List<Services.Dto.PhongHocDto> listPhs;
        public MainWindow()
        {
            InitializeComponent();
            phongHocController = new PhongHocController(Ultilities.ip, Ultilities.port);
            if(Ultilities.userRole == "Guest")
            {
                menuItemQT.Visibility = Visibility.Hidden;
                menuItemQLTB.IsEnabled = false;
                btnThem.IsEnabled = false;
                btnUpdate.IsEnabled = false;
            }
        }

        private async void MainFromLoaded(object sender, RoutedEventArgs e)
        {
            cbxCoSo.ItemsSource = await phongHocController.GetCoSo();
            cbxCoSo.SelectedIndex = 2;
            cbxNha.ItemsSource = await phongHocController.GetNha(cbxCoSo.SelectedItem.ToString());
            cbxNha.SelectedIndex = 1;
            try
            {
                listPhs = await phongHocController.GetByCoSo(cbxCoSo.SelectedItem.ToString(), cbxNha.SelectedItem.ToString());
                gvPhongHoc.ItemsSource = listPhs;
                gvPhongHoc.Columns[0].Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                
            }
        }

        private async void CbxCoSo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbxNha.ItemsSource = await phongHocController.GetNha(cbxCoSo.SelectedItem.ToString());
                cbxNha.SelectedIndex = 0;
                listPhs = await phongHocController.GetByCoSo(cbxCoSo.SelectedItem.ToString(), cbxNha.SelectedItem.ToString());
                gvPhongHoc.ItemsSource = listPhs;
                gvPhongHoc.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {

            }
        }

        private async void CbxNha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listPhs = await phongHocController.GetByCoSo(cbxCoSo.SelectedItem.ToString(), cbxNha.SelectedItem.ToString());
                gvPhongHoc.ItemsSource = listPhs;
                gvPhongHoc.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {

            }
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            AddPhongHocWindow addPhongHocWindow = new AddPhongHocWindow(cbxNha.SelectedItem.ToString());
            addPhongHocWindow.Closed += AddPhongHocWindow_Closed;
            addPhongHocWindow.Show();
        }

        private async void AddPhongHocWindow_Closed(object sender, EventArgs e)
        {
            listPhs = await phongHocController.GetByCoSo(cbxCoSo.SelectedItem.ToString(), cbxNha.SelectedItem.ToString());
            gvPhongHoc.ItemsSource = listPhs;
            gvPhongHoc.Columns[0].Visibility = Visibility.Hidden;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PhongHocDto phongHoc = gvPhongHoc.SelectedItem as PhongHocDto;
                UpdatePhongHocWindow window = new UpdatePhongHocWindow(phongHoc);
                window.Closed += Window_Closed;
                window.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            listPhs = await phongHocController.GetByCoSo(cbxCoSo.SelectedItem.ToString(), cbxNha.SelectedItem.ToString());
            gvPhongHoc.ItemsSource = listPhs;
            gvPhongHoc.Columns[0].Visibility = Visibility.Hidden;
        }

        private void GvPhongHoc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PhongHocDto currentItem = gvPhongHoc.SelectedItem as PhongHocDto;
                QLPhongHocWindow window = new QLPhongHocWindow(currentItem.TenPhong);
                window.Show();
            }
            catch (Exception)
            {

            }
            
        }

        private void MenuItemQLTB_Click(object sender, RoutedEventArgs e)
        {
            QLThietBiWindow window = new QLThietBiWindow();
            window.Show();
        }

        private void QuanTrimenuItem_Click(object sender, RoutedEventArgs e)
        {
            QLNguoiDungWindow window = new QLNguoiDungWindow();
            window.Show();
        }
    }
}
