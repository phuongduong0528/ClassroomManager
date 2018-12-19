using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClassroomManager.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IThongTinBanGiaoService" in both code and config file together.
    [ServiceContract]
    public interface IThongTinBanGiaoService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/ThongTinBanGiao/{year}",
            ResponseFormat = WebMessageFormat.Json)]
        List<ThongTinBanGiaoDto> GetByYear(string year);

        [OperationContract]
        [WebGet(
            UriTemplate = "/ThongTinBanGiao/{year}/{month}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<ThongTinBanGiaoDto> GetByMonth(string month, string year);

        [OperationContract]
        [WebGet(
            UriTemplate = "/ThongTinBanGiao?f={from}&t={to}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<ThongTinBanGiaoDto> GetByTime(string from, string to);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/ThongTinBanGiao",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool Add(ThongTinBanGiaoDto thongTinBanGiaoDto);
    }
}
