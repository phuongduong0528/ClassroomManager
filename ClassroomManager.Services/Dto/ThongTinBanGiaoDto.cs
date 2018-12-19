using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Dto
{
    [DataContract]
    public class ThongTinBanGiaoDto
    {
        [DataMember(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Phong", Order = 1)]
        public string Phong { get; set; }

        [DataMember(Name = "Ngay", Order = 2)]
        public string Ngay { get; set; }

        [DataMember(Name = "TinhTrang", Order = 3)]
        public string TinhTrang { get; set; }

        [DataMember(Name = "NguoiDung", Order = 4)]
        public string NguoiDung { get; set; }
    }
}
