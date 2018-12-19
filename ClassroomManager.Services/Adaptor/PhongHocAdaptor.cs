using ClassroomManager.DbManager.Models;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Adaptor
{
    public class PhongHocAdaptor
    {
        public PhongHocDto GetPhongHocDto(PhongHoc phongHoc)
        {
            PhongHocDto phongHocDto = new PhongHocDto();
            phongHocDto.MaPhong = phongHoc.MaPhong;
            phongHocDto.CoSo = phongHoc.ToaNha.CoSo.TenCoSo;
            phongHocDto.ToaNha = phongHoc.ToaNha.TenToaNha;
            phongHocDto.TenPhong = phongHoc.TenPhong;
            phongHocDto.LoaiPhong = phongHoc.LoaiPhong.TenLoaiPhong;
            phongHocDto.GhiChu = phongHoc.GhiChu;
            return phongHocDto;
        }

        public List<PhongHocDto> GetListPhongHocDto(List<PhongHoc> phongHocs)
        {
            List<PhongHocDto> phongHocDtos = new List<PhongHocDto>();
            foreach(PhongHoc ph in phongHocs)
            {
                phongHocDtos.Add(GetPhongHocDto(ph));
            }
            return phongHocDtos;
        }

        public PhongHoc ToPhongHocEntity(PhongHocDto phongHocDto)
        {
            PhongHoc ph = new PhongHoc();
            ph.MaPhong = phongHocDto.MaPhong;
            using(ClassroomManagerEntities entities = new ClassroomManagerEntities())
            {
                ph.MaLoaiPhong = entities.LoaiPhongs
                    .FirstOrDefault(lp => lp.TenLoaiPhong.Equals(phongHocDto.LoaiPhong))
                    .MaLoaiPhong;

                ph.MaToaNha = entities.ToaNhas
                    .FirstOrDefault(tn => tn.TenToaNha.Equals(phongHocDto.ToaNha))
                    .MaToaNha;
            }
            ph.TenPhong = phongHocDto.TenPhong;
            ph.GhiChu = phongHocDto.GhiChu;
            return ph;
        }
    }
}
