using ClassroomManager.DbManager.Models;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Adaptor
{
    public class ThietBiPhongHocAdaptor
    {
        public ThietBiPhongHocDto GetThietBiPhongHocDto(ThietBiPhongHoc tbph)
        {
            ThietBiPhongHocDto tbphDto = new ThietBiPhongHocDto();
            tbphDto.Id = tbph.Id;
            tbphDto.Phong = tbph.PhongHoc.TenPhong;
            tbphDto.ThietBi = tbph.ThietBi.TenThietBi;
            tbphDto.SoLuong = tbph.SoLuong;
            return tbphDto;
        }

        public List<ThietBiPhongHocDto> GetListThietBiPhongHocDto(List<ThietBiPhongHoc> tbphs)
        {
            List<ThietBiPhongHocDto> tbphDtos = new List<ThietBiPhongHocDto>();
            foreach(ThietBiPhongHoc tb in tbphs)
            {
                tbphDtos.Add(GetThietBiPhongHocDto(tb));
            }
            return tbphDtos;
        }

        public ThietBiPhongHoc ToThietBiPhongHocentity(ThietBiPhongHocDto tbphDto)
        {
            ThietBiPhongHoc tbph = new ThietBiPhongHoc();
            tbph.Id = tbphDto.Id;
            using (ClassroomManagerEntities entities = new ClassroomManagerEntities())
            {
                tbph.MaPhong = entities.PhongHocs
                    .FirstOrDefault(ph => ph.TenPhong.Equals(tbphDto.Phong))
                    .MaPhong;

                tbph.MaThietBi = entities.ThietBis
                    .FirstOrDefault(tb => tb.TenThietBi.Equals(tbphDto.ThietBi))
                    .MaThietBi;
            }
            return tbph;
        }
    }
}
