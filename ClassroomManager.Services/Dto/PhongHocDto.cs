using System;
using System.Collections.Generic;
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
        public int MaPhong { get; set; }

        [DataMember(Name = "CoSo", Order = 1)]
        public string CoSo { get; set; }

        [DataMember(Name = "ToaNha", Order = 2)]
        public string ToaNha { get; set; }

        [DataMember(Name = "TenPhong", Order = 3)]
        public string TenPhong { get; set; }

        [DataMember(Name = "LoaiPhong", Order = 4)]
        public string LoaiPhong { get; set; }

        [DataMember(Name = "GhiChu", Order = 5)]
        public string GhiChu { get; set; }
    }
}
