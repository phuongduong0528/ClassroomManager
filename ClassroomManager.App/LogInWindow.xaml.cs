using ClassroomManager.App.Controller;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        UserController userController;
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ultilities.ip = txtbIp.Text;
            Ultilities.port = txtbPort.Text;
            userController = new UserController(Ultilities.ip, Ultilities.port);
        }

        private void TxtbIp_TextChanged(object sender, TextChangedEventArgs e)
        {
            Ultilities.ip = txtbIp.Text;
            userController = new UserController(Ultilities.ip, Ultilities.port);
        }

        private void TxtbPort_TextChanged(object sender, TextChangedEventArgs e)
        {
            Ultilities.port = txtbPort.Text;
            userController = new UserController(Ultilities.ip, Ultilities.port);
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool res = await userController.Auth(txtbID.Text, Ultilities.ToHashString(txtbPass.Password));
            if (res)
            {
                try
                {
                    List<Services.Dto.UserDto> users = await userController.GetAll();
                    var a = users.SingleOrDefault(u => u.Id.Trim().Equals(txtbID.Text));
                    Ultilities.userName = a.Username;
                    Ultilities.userRole = a.Role;
                }
                catch (Exception)
                {

                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Closed += MainWindow_Closed;
                mainWindow.Show();
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Sai Id hoặc mật khẩu", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
