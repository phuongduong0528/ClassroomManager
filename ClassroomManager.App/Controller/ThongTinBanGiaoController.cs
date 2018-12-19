using ClassroomManager.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.App.Controller
{
    public class ThongTinBanGiaoController
    {
        private string baseUrl;
        public ThongTinBanGiaoController(string ip, string port)
        {
            baseUrl = $"http://{ip}:{port}/ClassroomManager.Services/ThongTinBanGiaoService";
        }

        public async Task<List<ThongTinBanGiaoDto>> GetByYear(string year)
        {
            RequestController<List<ThongTinBanGiaoDto>> controller = new RequestController<List<ThongTinBanGiaoDto>>();
            controller.Url = baseUrl + $"/ThongTinBanGiao/{year}";
            List<ThongTinBanGiaoDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<List<ThongTinBanGiaoDto>> GetByMonth(string month, string year)
        {
            RequestController<List<ThongTinBanGiaoDto>> controller = new RequestController<List<ThongTinBanGiaoDto>>();
            controller.Url = baseUrl + $"/ThongTinBanGiao/{year}/{month}";
            List<ThongTinBanGiaoDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<List<ThongTinBanGiaoDto>> GetByTime(string from, string to)
        {
            RequestController<List<ThongTinBanGiaoDto>> controller = new RequestController<List<ThongTinBanGiaoDto>>();
            controller.Url = baseUrl + $"/ThongTinBanGiao?f={from}&t={to}";
            List<ThongTinBanGiaoDto> respond = await controller.GetData();
            return respond;
        }

        public async Task<bool> Add(ThongTinBanGiaoDto thongTinBanGiaoDto)
        {
            RequestController<bool> controller = new RequestController<bool>();
            controller.Url = baseUrl + "/ThongTinBanGiao";
            bool respond = await controller.SubmitDataJson(RestSharp.Method.POST, JsonConvert.SerializeObject(thongTinBanGiaoDto));
            return respond;
        }
    }
}
