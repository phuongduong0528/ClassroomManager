using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomManager.DbManager.Models;

namespace ClassroomManager.DbManager.Manager
{
    public class PhongHocManager : IPhongHocManager
    {
        private readonly ClassroomManagerEntities entities = new ClassroomManagerEntities();
        public bool Add(PhongHoc ph)
        {
            try
            {
                entities.PhongHocs.Add(ph);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PhongHoc> GetByCoSo(string cs, string nha)
        {
            List<PhongHoc> phongHoc = entities.PhongHocs.ToList();
            if(cs != "")
            {
                phongHoc = phongHoc.Where(ph => ph.ToaNha.CoSo.TenCoSo.Equals(cs)).ToList();
            }
            if(nha != "")
            {
                phongHoc = phongHoc.Where(ph => ph.ToaNha.TenToaNha.Equals(nha)).ToList();
            }
            return phongHoc;
        }

        public bool Update(PhongHoc ph)
        {
            try
            {
                PhongHoc temp = entities.PhongHocs.SingleOrDefault(ph1 => ph1.MaPhong == ph.MaPhong);
                temp.MaLoaiPhong = ph.MaLoaiPhong;
                temp.MaToaNha = ph.MaToaNha;
                temp.TenPhong = ph.TenPhong;
                temp.GhiChu = ph.GhiChu;
                entities.Entry(temp).State = System.Data.Entity.EntityState.Modified;
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
