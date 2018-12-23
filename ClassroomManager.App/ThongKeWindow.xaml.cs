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
    /// Interaction logic for ThongKeWindow.xaml
    /// </summary>
    public partial class ThongKeWindow : Window
    {
        PhongHocController phongHocController;
        ThongTinBanGiaoController thongTinBanGiaoController;
        public ThongKeWindow()
        {
            InitializeComponent();
            phongHocController = new PhongHocController(Ultilities.ip, Ultilities.port);
            thongTinBanGiaoController = new ThongTinBanGiaoController(Ultilities.ip, Ultilities.port);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Services.Dto.PhongHocDto> phongs = 
                await phongHocController.GetByCoSo("", "");
            gvPH.ItemsSource = phongs.Where(p => p.GhiChu != null)
                                     .Where(p2 => p2.GhiChu != "").ToList();
            List<Services.Dto.ThongTinBanGiaoDto> banGiaos = 
                await thongTinBanGiaoController.GetByYear(DateTime.Now.Year.ToString());
            gvBG.ItemsSource = banGiaos.Where(bg => bg.TinhTrang != null)
                                       .Where(bg2=>bg2.TinhTrang.Trim() != "OK");
        }
    }
}
