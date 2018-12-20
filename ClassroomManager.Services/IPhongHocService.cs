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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPhongHocService" in both code and config file together.
    [ServiceContract]
    public interface IPhongHocService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/PhongHoc?cs={cs}&nha={nha}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<PhongHocDto> GetByCoSo(string cs, string nha);

        [OperationContract]
        [WebGet(
            UriTemplate = "/CoSo",
            ResponseFormat = WebMessageFormat.Json)]
        List<string> GetCoSo();

        [OperationContract]
        [WebGet(
            UriTemplate = "/Nha?cs={cs}",
            ResponseFormat =  WebMessageFormat.Json)]
        List<string> GetNha(string cs);

        [OperationContract]
        [WebGet(
            UriTemplate = "/LoaiPhong",
            ResponseFormat = WebMessageFormat.Json)]
        List<string> GetLoaiPhong();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/PhongHoc",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool Add(PhongHocDto phongHocDto);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/PhongHoc",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        bool Update(PhongHocDto phongHocDto);
    }
}
