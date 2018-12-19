using System;
using System.Collections.Generic;
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
        public int MaThietBi { get; set; }

        [DataMember(Name = "TenThietBi", Order = 1)]
        public string TenThietBi { get; set; }

        [DataMember(Name = "NhomThietBi", Order = 2)]
        public string NhomThietBi { get; set; }
    }
}
