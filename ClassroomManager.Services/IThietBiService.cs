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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IThietBiService" in both code and config file together.
    [ServiceContract]
    public interface IThietBiService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/ThietBi",
            ResponseFormat = WebMessageFormat.Json)]
        List<ThietBiDto> GetAll();

        [OperationContract]
        [WebGet(
            UriTemplate = "/ThietBi?g={group}&n={name}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<ThietBiDto> GetByFilter(string group, string name);

        [OperationContract]
        [WebGet(
            UriTemplate = "/NTB",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<string> GetNhomTB();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/ThietBi",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool Add(ThietBiDto thietBiDto);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/ThietBi",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        bool Update(ThietBiDto thietBiDto);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/ThietBi/Del",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool Delete(int id);
    }
}
