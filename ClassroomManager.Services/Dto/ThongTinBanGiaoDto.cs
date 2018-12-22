using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Id")]
        public int Id { get; set; }

        [DataMember(Name = "Phong", Order = 1)]
        [DisplayName("Phòng")]
        public string Phong { get; set; }

        [DataMember(Name = "Ngay", Order = 2)]
        [DisplayName("Ngày")]
        public string Ngay { get; set; }

        [DataMember(Name = "TinhTrang", Order = 3)]
        [DisplayName("Tình trạng")]
        public string TinhTrang { get; set; }

        [DataMember(Name = "NguoiDung", Order = 4)]
        [DisplayName("Người dùng")]
        public string NguoiDung { get; set; }
    }
}
