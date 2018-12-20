using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassroomManager.DbManager.Manager;
using ClassroomManager.Services.Adaptor;
using ClassroomManager.Services.Dto;

namespace ClassroomManager.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PhongHocService" in both code and config file together.
    public class PhongHocService : IPhongHocService
    {
        readonly PhongHocAdaptor phongHocAdaptor = new PhongHocAdaptor();
        PhongHocManager phongHocManager;
        PhongHocManager PhongHocManager => phongHocManager ?? (phongHocManager = new PhongHocManager());
        public bool Add(PhongHocDto phongHocDto)
        {
            return PhongHocManager.Add(phongHocAdaptor.ToPhongHocEntity(phongHocDto));
        }

        public List<PhongHocDto> GetByCoSo(string cs, string nha)
        {
            return phongHocAdaptor.GetListPhongHocDto(PhongHocManager.GetByCoSo(cs, nha));
        }

        public List<string> GetCoSo()
        {
            return PhongHocManager.GetCoSo();
        }

        public List<string> GetLoaiPhong()
        {
            return PhongHocManager.GetLoaiPhong();
        }

        public List<string> GetNha(string cs)
        {
            return PhongHocManager.GetNha(cs);
        }

        public bool Update(PhongHocDto phongHocDto)
        {
            return PhongHocManager.Update(phongHocAdaptor.ToPhongHocEntity(phongHocDto));
        }
    }
}
