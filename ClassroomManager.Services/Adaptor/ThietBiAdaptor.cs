using ClassroomManager.DbManager.Models;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Adaptor
{
    public class ThietBiAdaptor
    {
        public ThietBiDto GetThietBiDto(ThietBi thietBi)
        {
            ThietBiDto thietBiDto = new ThietBiDto();
            thietBiDto.MaThietBi = thietBi.MaThietBi;
            thietBiDto.TenThietBi = thietBi.TenThietBi;
            thietBiDto.NhomThietBi = thietBi.NhomThietBi.TenNhomThietBi;
            return thietBiDto;
        }

        public List<ThietBiDto> GetListThietBiDto(List<ThietBi> thietBis)
        {
            List<ThietBiDto> thietBiDtos = new List<ThietBiDto>();
            foreach(ThietBi tb in thietBis)
            {
                thietBiDtos.Add(GetThietBiDto(tb));
            }
            return thietBiDtos;
        }

        public ThietBi ToThietBiEntity(ThietBiDto thietBiDto)
        {
            ThietBi thietBi = new ThietBi();
            thietBi.MaThietBi = thietBiDto.MaThietBi;
            thietBi.TenThietBi = thietBiDto.TenThietBi;
            using (ClassroomManagerEntities entities = new ClassroomManagerEntities())
            {
                thietBi.MaNhomThietBi = entities.NhomThietBis
                    .FirstOrDefault(ntb => ntb.TenNhomThietBi.Equals(thietBiDto.NhomThietBi))
                    .MaNhomThietBi;
            }
            return thietBi;
        }
    }
}
