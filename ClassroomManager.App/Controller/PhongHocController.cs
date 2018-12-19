using ClassroomManager.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.App.Controller
{
    public class PhongHocController
    {
        private string baseUrl;
        public PhongHocController(string ip, string port)
        {
            baseUrl = $"http://{ip}:{port}/ClassroomManager.Services/PhongHocService";
        }

        public async Task<List<PhongHocDto>> GetByCoSo(string cs, string nha)
        {
            RequestController<List<PhongHocDto>> controller = new RequestController<List<PhongHocDto>>();
            controller.Url = baseUrl + $"/PhongHoc?cs={cs}&nha={nha}";
            List<PhongHocDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<bool> Add(PhongHocDto phongHocDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + "/PhongHoc";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(phongHocDto));
            return respond;
        }

        public async Task<bool> Update(PhongHocDto phongHocDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + "/PhongHoc";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.PUT, JsonConvert.SerializeObject(phongHocDto));
            return respond;
        }
    }
}
