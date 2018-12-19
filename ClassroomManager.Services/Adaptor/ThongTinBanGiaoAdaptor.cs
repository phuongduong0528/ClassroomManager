using ClassroomManager.DbManager.Models;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Adaptor
{
    public class ThongTinBanGiaoAdaptor
    {
        public ThongTinBanGiaoDto GetThongTinBanGiaoDto(ThongTinBanGiao ttbg)
        {
            ThongTinBanGiaoDto ttbgDto = new ThongTinBanGiaoDto();
            ttbgDto.Id = ttbg.Id;
            ttbgDto.Phong = ttbg.PhongHoc.TenPhong;
            ttbgDto.Ngay = ttbg.Ngay.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ttbgDto.TinhTrang = ttbg.TinhTrang;
            ttbgDto.NguoiDung = ttbg.User.Username;
            return ttbgDto;
        }

        public List<ThongTinBanGiaoDto> GetListThongTinBanGiaoDto(List<ThongTinBanGiao> ttbgs)
        {
            List<ThongTinBanGiaoDto> ttbgDtos = new List<ThongTinBanGiaoDto>();
            foreach(ThongTinBanGiao tt in ttbgs)
            {
                ttbgDtos.Add(GetThongTinBanGiaoDto(tt));
            }
            return ttbgDtos;
        }

        public ThongTinBanGiao ToThongTinBanGiaoEntity(ThongTinBanGiaoDto ttbgDto)
        {
            ThongTinBanGiao ttbg = new ThongTinBanGiao();
            ttbg.Id = ttbgDto.Id;
            using(ClassroomManagerEntities entities = new ClassroomManagerEntities())
            {
                ttbg.MaPhong = entities.PhongHocs
                    .FirstOrDefault(ph => ph.TenPhong.Equals(ttbgDto.Phong))
                    .MaPhong;

                ttbg.UserId = entities.Users
                    .FirstOrDefault(u => u.Username.Equals(ttbgDto.NguoiDung))
                    .UserId;
            }
            ttbg.Ngay = DateTime.ParseExact(ttbgDto.Ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ttbg.TinhTrang = ttbgDto.TinhTrang;
            return ttbg;
        }
    }
}
