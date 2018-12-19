using ClassroomManager.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.App.Controller
{
    public class ThietBiPhongHocController
    {
        private string baseUrl;
        public ThietBiPhongHocController(string ip, string port)
        {
            baseUrl = $"http://{ip}:{port}/ClassroomManager.Services/ThietBiPhongHocService";
        }

        public async Task<List<ThietBiPhongHocDto>> GetByClass(string name)
        {
            RequestController<List<ThietBiPhongHocDto>> controller = 
                new RequestController<List<ThietBiPhongHocDto>>();
            controller.Url = baseUrl + $"/ThietBiPhongHoc?name={name}";
            List<ThietBiPhongHocDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<bool> AddThietBi(ThietBiPhongHocDto thietBiPhongHocDto)
        {
            RequestController<bool> controller =
                new RequestController<bool>();
            controller.Url = baseUrl + "/ThietBiPhongHoc";
            bool respond = 
                await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(thietBiPhongHocDto));
            return respond;
        }

        public async Task<bool> UpdateThietBi(ThietBiPhongHocDto thietBiPhongHocDto)
        {
            RequestController<bool> controller =
                new RequestController<bool>();
            controller.Url = baseUrl + "/ThietBiPhongHoc";
            bool respond =
                await controller.SubmitDataJson(RestSharp.Method.PUT, JsonConvert.SerializeObject(thietBiPhongHocDto));
            return respond;
        }
    }
}
