using ClassroomManager.DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.DbManager.Manager
{
    interface IThongTinBanGiaoManager
    {
        List<ThongTinBanGiao> GetByYear(int year);
        List<ThongTinBanGiao> GetByMonth(int month, int year);
        List<ThongTinBanGiao> GetByTime(string from, string to);
        bool Add(ThongTinBanGiao thongTinBanGiao);
    }
}
