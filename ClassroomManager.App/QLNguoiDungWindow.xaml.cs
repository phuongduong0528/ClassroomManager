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
    /// Interaction logic for QLNguoiDungWindow.xaml
    /// </summary>
    public partial class QLNguoiDungWindow : Window
    {
        private UserController controller;
        public QLNguoiDungWindow()
        {
            InitializeComponent();
            controller = new UserController(Ultilities.ip, Ultilities.port);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gvUser.ItemsSource = await controller.GetAll();
            gvUser.Columns[3].Visibility = Visibility.Hidden;
        }

        private void GvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UserDto user = gvUser.SelectedItem as UserDto;
                txtbTen.Text = user.Username;
                txtbMK.Password = "123456";
                if (user.Role == "Admin")
                    cbxRole.SelectedIndex = 0;
                else
                    cbxRole.SelectedIndex = 1;
            }
            catch (Exception)
            {

            }
        }

        private async void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            UserDto temp = new UserDto();
            temp.Password = Ultilities.ToHashString(txtbMK.Password);
            temp.Role = cbxRole.SelectedIndex == 0 ? "Admin" : "Guest";
            temp.Username = txtbTen.Text.Trim();
            bool re = await controller.AddUser(temp);
            if (!re)
            {
                MessageBox.Show("Không thể thêm", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            gvUser.ItemsSource = await controller.GetAll();
            gvUser.Columns[3].Visibility = Visibility.Hidden;
        }

        private async void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserDto temp = gvUser.SelectedItem as UserDto;
                temp.Password = Ultilities.ToHashString(txtbMK.Password);
                temp.Role = cbxRole.SelectedIndex == 0 ? "Admin" : "Guest";
                temp.Username = txtbTen.Text.Trim();
                bool re = await controller.Update(temp);
                if (!re)
                {
                    MessageBox.Show("Không thể sửa", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                gvUser.ItemsSource = await controller.GetAll();
                gvUser.Columns[3].Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {

            }
        }
    }
}
