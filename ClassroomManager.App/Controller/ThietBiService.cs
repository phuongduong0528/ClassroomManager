using ClassroomManager.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.App.Controller
{
    public class ThietBiService
    {
        private string baseUrl;
        public ThietBiService(string ip, string port)
        {
            baseUrl = $"http://{ip}:{port}/ClassroomManager.Services/ThietBiService";
        }

        public async Task<List<ThietBiDto>> GetAll()
        {
            RequestController<List<ThietBiDto>> controller = new RequestController<List<ThietBiDto>>();
            controller.Url = baseUrl + "/ThietBi";
            List<ThietBiDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<List<ThietBiDto>> GetByFilter(string group, string name)
        {
            RequestController<List<ThietBiDto>> controller = new RequestController<List<ThietBiDto>>();
            controller.Url = baseUrl + $"/ThietBi?g={group}&n={name}";
            List<ThietBiDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<bool> Add(ThietBiDto thietBiDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + $"/ThietBi";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(thietBiDto));
            return respond;
        }

        public async Task<bool> Update(ThietBiDto thietBiDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + $"/ThietBi";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.PUT, JsonConvert.SerializeObject(thietBiDto));
            return respond;
        }

        public async Task<bool> Delete(int pid)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + $"/ThietBi/Del";
            object obj = new
            {
                id = pid
            };
            bool respond = await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(obj));
            return respond;
        }
    }
}
