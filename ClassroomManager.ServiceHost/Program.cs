using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting services...");
            System.ServiceModel.ServiceHost phongHocService = 
                new System.ServiceModel.ServiceHost(typeof(ClassroomManager.Services.PhongHocService));
            System.ServiceModel.ServiceHost thietBiPhongHocService =
                new System.ServiceModel.ServiceHost(typeof(ClassroomManager.Services.ThietBiPhongHocService));
            System.ServiceModel.ServiceHost thietBiService =
                new System.ServiceModel.ServiceHost(typeof(ClassroomManager.Services.ThietBiService));
            System.ServiceModel.ServiceHost thongtinBanGiaoService =
                new System.ServiceModel.ServiceHost(typeof(ClassroomManager.Services.ThongTinBanGiaoService));
            System.ServiceModel.ServiceHost userService =
                new System.ServiceModel.ServiceHost(typeof(ClassroomManager.Services.UserService));

            try
            {
                phongHocService.Open();
                thietBiPhongHocService.Open();
                thietBiService.Open();
                thongtinBanGiaoService.Open();
                userService.Open();

                Console.WriteLine("All Services started");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: \n" + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
