using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.App.Controller
{
    public class Ultilities
    {
        public static string ip;
        public static string port;
        public static string userName;
        public static string userRole;

        public static string ToHashString(string str)
        {
            byte[] inputByte = Encoding.UTF8.GetBytes(str);
            SHA256 sha256Hash = SHA256.Create();
            byte[] outputByte = sha256Hash.ComputeHash(inputByte);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in outputByte)
            {
                sb.Append(b.ToString("X2").ToLower());
            }
            return sb.ToString();
        }

        public static string GetDefaultGateway()
        {
            NetworkInterface netInterface = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up
                        && n.NetworkInterfaceType != NetworkInterfaceType.Loopback
                        && (n.Name.ToLower().Contains("wi")
                            || n.Name.ToLower().Contains("ether")
                            || n.Name.ToLower().Contains("local")
                            )).FirstOrDefault();

            return netInterface.GetIPProperties().GatewayAddresses.FirstOrDefault().Address.ToString();
        }
    }
}
