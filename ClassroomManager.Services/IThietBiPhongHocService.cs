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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IThietBiPhongHocService" in both code and config file together.
    [ServiceContract]
    public interface IThietBiPhongHocService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/ThietBiPhongHoc?name={name}",
            ResponseFormat = WebMessageFormat.Json)]
        List<ThietBiPhongHocDto> GetByClass(string name);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/ThietBiPhongHoc",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool AddThietBi(ThietBiPhongHocDto thietBiPhongHocDto);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/ThietBiPhonghoc",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        bool UpdateThietBi(ThietBiPhongHocDto thietBiPhongHocDto);
    }
}
