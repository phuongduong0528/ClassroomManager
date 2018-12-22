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
    public class PhongHocDto
    {
        [DataMember(Name = "MaPhong", Order = 0)]
        [DisplayName("Mã phòng")]
        public int MaPhong { get; set; }

        [DataMember(Name = "CoSo", Order = 1)]
        [DisplayName("Cơ sở")]
        public string CoSo { get; set; }

        [DataMember(Name = "ToaNha", Order = 2)]
        [DisplayName("Nhà")]
        public string ToaNha { get; set; }

        [DataMember(Name = "TenPhong", Order = 3)]
        [DisplayName("Phòng")]
        public string TenPhong { get; set; }

        [DataMember(Name = "LoaiPhong", Order = 4)]
        [DisplayName("Loại phòng")]
        public string LoaiPhong { get; set; }

        [DataMember(Name = "GhiChu", Order = 5)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }
    }
}
