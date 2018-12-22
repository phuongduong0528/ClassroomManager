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
    public class ThietBiPhongHocDto
    {
        [DataMember(Name = "Id", Order = 0)]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DataMember(Name = "Phong", Order = 1)]
        [DisplayName("Phòng")]
        public string Phong { get; set; }

        [DataMember(Name = "ThietBi", Order = 2)]
        [DisplayName("Thiết bị")]
        public string ThietBi { get; set; }

        [DataMember(Name = "SoLuong", Order = 3)]
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }
    }
}
