using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomManager.DbManager.Models;

namespace ClassroomManager.DbManager.Manager
{
    public class ThietBiManager : IThietBiManager
    {
        private readonly ClassroomManagerEntities entities = new ClassroomManagerEntities();
        public bool Add(ThietBi thietBi)
        {
            try
            {
                entities.ThietBis.Add(thietBi);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                ThietBi thietBi = entities.ThietBis.SingleOrDefault(tb => tb.MaThietBi == id);
                entities.ThietBis.Remove(thietBi);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ThietBi> GetAll()
        {
            return entities.ThietBis.ToList();
        }

        public List<ThietBi> GetByFilter(string group, string name)
        {
            List<ThietBi> thietBis = GetAll();
            if(group != "")
            {
                thietBis = thietBis.Where(tb => tb.NhomThietBi.TenNhomThietBi.Contains(group)).ToList();
            }
            if(name != "")
            {
                thietBis = thietBis.Where(tb => tb.TenThietBi.Contains(name)).ToList();
            }
            return thietBis;
        }

        public bool Update(ThietBi thietBi)
        {
            try
            {
                ThietBi temp = entities.ThietBis.SingleOrDefault(tb => tb.MaThietBi == thietBi.MaThietBi);
                temp.MaNhomThietBi = thietBi.MaNhomThietBi;
                temp.TenThietBi = thietBi.TenThietBi;
                entities.Entry(thietBi).State = System.Data.Entity.EntityState.Modified;
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
