using ClassroomManager.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.App.Controller
{
    public class UserController
    {
        private string baseUrl;
        public UserController(string ip, string port)
        {
            baseUrl = $"http://{ip}:{port}/ClassroomManager.Services/UserService";
        }

        public async Task<bool> Auth(string pid, string ppassword)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + "/Auth";
            object obj = new
            {
                id = pid,
                password = ppassword
            };
            bool respond = await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(obj));
            return respond;
        }

        public async Task<List<UserDto>> GetAll()
        {
            RequestController<List<UserDto>> controller = new RequestController<List<UserDto>>();
            controller.Url = baseUrl + "/User";
            List<UserDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<bool> AddUser(UserDto userDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + "/User";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(userDto));
            return respond;
        }

        public async Task<bool> Update(UserDto userDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + "/User";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.PUT, JsonConvert.SerializeObject(userDto));
            return respond;
        }
    }
}
