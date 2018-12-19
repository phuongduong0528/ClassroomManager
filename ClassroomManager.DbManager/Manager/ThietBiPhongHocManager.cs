using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomManager.DbManager.Models;

namespace ClassroomManager.DbManager.Manager
{
    public class ThietBiPhongHocManager : IThietBiPhongHocManager
    {
        private readonly ClassroomManagerEntities entities = new ClassroomManagerEntities();

        public bool AddThietBi(ThietBiPhongHoc thietBiPhongHoc)
        {
            try
            {
                entities.ThietBiPhongHocs.Add(thietBiPhongHoc);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ThietBiPhongHoc> GetByClass(string name)
        {
            return entities.ThietBiPhongHocs.Where(tbph => tbph.PhongHoc.TenPhong.Equals(name)).ToList();
        }

        public bool UpdateThietBi(ThietBiPhongHoc thietBiPhongHoc)
        {
            try
            {
                ThietBiPhongHoc tbPhongHoc = entities.ThietBiPhongHocs.SingleOrDefault(tb => tb.Id.Equals(thietBiPhongHoc.Id));
                tbPhongHoc.MaPhong = thietBiPhongHoc.MaPhong;
                tbPhongHoc.MaThietBi = thietBiPhongHoc.MaThietBi;
                tbPhongHoc.SoLuong = thietBiPhongHoc.SoLuong;
                entities.Entry(tbPhongHoc).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
