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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Auth",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        bool Auth(string id, string password);

        [OperationContract]
        [WebGet(
            UriTemplate = "/User",
            ResponseFormat = WebMessageFormat.Json)]
        List<UserDto> GetAll();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/User",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool AddUser(UserDto user);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/User",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        bool Update(UserDto user);
    }
}
