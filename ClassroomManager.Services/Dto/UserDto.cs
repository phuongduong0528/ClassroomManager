using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember(Name = "Id", Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "Username", Order = 1)]
        public string Username { get; set; }

        [DataMember(Name = "Role", Order = 2)]
        public string Role { get; set; }

        [DataMember(Name = "Password", Order = 3)]
        public string Password { get; set; }        
    }
}
