using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomManager.DbManager.Models;

namespace ClassroomManager.DbManager.Manager
{
    public class ThongTinBanGiaoManager : IThongTinBanGiaoManager
    {
        private readonly ClassroomManagerEntities entities = new ClassroomManagerEntities();
        public bool Add(ThongTinBanGiao thongTinBanGiao)
        {
            try
            {
                entities.ThongTinBanGiaos.Add(thongTinBanGiao);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ThongTinBanGiao> GetByMonth(int month, int year)
        {
            return entities.ThongTinBanGiaos
                .Where(tt => tt.Ngay.Year == year && tt.Ngay.Month == month).ToList();
        }

        public List<ThongTinBanGiao> GetByTime(string from, string to)
        {
            try
            {
                DateTime fromD = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime toD = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return entities.ThongTinBanGiaos
                    .Where(tt => tt.Ngay <= toD && tt.Ngay >= fromD).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ThongTinBanGiao> GetByYear(int year)
        {
            return entities.ThongTinBanGiaos.Where(tt => tt.Ngay.Year == year).ToList();
        }
    }
}
