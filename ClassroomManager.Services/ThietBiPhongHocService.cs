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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ThietBiPhongHocService" in both code and config file together.
    public class ThietBiPhongHocService : IThietBiPhongHocService
    {
        readonly ThietBiPhongHocAdaptor thietBiPhongHocAdaptor = new ThietBiPhongHocAdaptor();
        ThietBiPhongHocManager thietBiPhongHocManager;
        ThietBiPhongHocManager ThietBiPhongHocManager => thietBiPhongHocManager ?? (thietBiPhongHocManager = new ThietBiPhongHocManager());
        public bool AddThietBi(ThietBiPhongHocDto thietBiPhongHocDto)
        {
            return ThietBiPhongHocManager.AddThietBi(thietBiPhongHocAdaptor.ToThietBiPhongHocentity(thietBiPhongHocDto));
        }

        public List<ThietBiPhongHocDto> GetByClass(string name)
        {
            return thietBiPhongHocAdaptor.GetListThietBiPhongHocDto(ThietBiPhongHocManager.GetByClass(name));
        }

        public bool UpdateThietBi(ThietBiPhongHocDto thietBiPhongHocDto)
        {
            return ThietBiPhongHocManager.UpdateThietBi(thietBiPhongHocAdaptor.ToThietBiPhongHocentity(thietBiPhongHocDto));
        }
    }
}
