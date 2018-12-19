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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ThongTinBanGiaoService" in both code and config file together.
    public class ThongTinBanGiaoService : IThongTinBanGiaoService
    {
        readonly ThongTinBanGiaoAdaptor thongTinBanGiaoAdaptor = new ThongTinBanGiaoAdaptor();
        ThongTinBanGiaoManager thongTinBanGiaoManager;
        ThongTinBanGiaoManager ThongTinBanGiaoManager => thongTinBanGiaoManager ?? (thongTinBanGiaoManager = new ThongTinBanGiaoManager());
        public bool Add(ThongTinBanGiaoDto thongTinBanGiaoDto)
        {
            return ThongTinBanGiaoManager.Add(thongTinBanGiaoAdaptor.ToThongTinBanGiaoEntity(thongTinBanGiaoDto));
        }

        public List<ThongTinBanGiaoDto> GetByMonth(string month, string year)
        {
            int intyear = Convert.ToInt32(year);
            int intmonth = Convert.ToInt32(month);
            return thongTinBanGiaoAdaptor.GetListThongTinBanGiaoDto(ThongTinBanGiaoManager.GetByMonth(intmonth, intyear));
        }

        public List<ThongTinBanGiaoDto> GetByTime(string from, string to)
        {
            return thongTinBanGiaoAdaptor.GetListThongTinBanGiaoDto(ThongTinBanGiaoManager.GetByTime(from, to));
        }

        public List<ThongTinBanGiaoDto> GetByYear(string year)
        {
            int intyear = Convert.ToInt32(year);
            return thongTinBanGiaoAdaptor.GetListThongTinBanGiaoDto(ThongTinBanGiaoManager.GetByYear(intyear));
        }
    }
}
