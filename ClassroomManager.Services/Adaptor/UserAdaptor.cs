using ClassroomManager.DbManager.Models;
using ClassroomManager.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.Services.Adaptor
{
    public class UserAdaptor
    {
        public UserDto GetUserDto(User user)
        {
            UserDto userDto = new UserDto();
            userDto.Id = user.UserId;
            userDto.Username = user.Username;
            userDto.Role = user.Role;
            userDto.Password = user.Password;
            return userDto;
        }

        public List<UserDto> GetListUserDto(List<User> users)
        {
            List<UserDto> userDtos = new List<UserDto>();
            foreach(User u in users)
            {
                userDtos.Add(GetUserDto(u));
            }
            return userDtos;
        }

        public User ToUserEntity(UserDto userDto)
        {
            User user = new User();
            user.UserId = userDto.Id;
            user.Username = userDto.Username;
            user.Role = userDto.Role;
            user.Password = userDto.Password;
            return user;
        }
    }
}
