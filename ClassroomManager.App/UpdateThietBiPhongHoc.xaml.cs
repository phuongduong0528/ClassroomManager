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
    /// Interaction logic for UpdateThietBiPhongHoc.xaml
    /// </summary>
    public partial class UpdateThietBiPhongHoc : Window
    {
        private string phongHoc;
        private ThietBiPhongHocController controller;
        private ThietBiController thietBi;
        public UpdateThietBiPhongHoc()
        {
            InitializeComponent();
        }
        public UpdateThietBiPhongHoc(string phong)
        {
            InitializeComponent();
            phongHoc = phong;
            controller = new ThietBiPhongHocController(Ultilities.ip, Ultilities.port);
            thietBi = new ThietBiController(Ultilities.ip, Ultilities.port);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxThietBi.ItemsSource = (await thietBi.GetAll()).Select(tb=>tb.TenThietBi).ToList();
            cbxThietBi.SelectedIndex = 0;
        }
    }
}
