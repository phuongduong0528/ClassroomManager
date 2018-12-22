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
    public class ThietBiDto
    {
        [DataMember(Name = "MaThietBi", Order = 0)]
        [DisplayName("Mã TB")]
        public int MaThietBi { get; set; }

        [DataMember(Name = "TenThietBi", Order = 1)]
        [DisplayName("Tên TB")]
        public string TenThietBi { get; set; }

        [DataMember(Name = "NhomThietBi", Order = 2)]
        [DisplayName("Loại TB")]
        public string NhomThietBi { get; set; }

        [DataMember(Name = "TongSoLuong", Order = 3)]
        [DisplayName("Tổng số")]
        public int TongSoLuong { get; set; }
    }
}
