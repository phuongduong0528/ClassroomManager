using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassroomManager.DbManager.Manager;
using ClassroomManager.Services.Adaptor;
using ClassroomManager.Services.Dto;

namespace ClassroomManager.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        readonly UserAdaptor userAdaptor = new UserAdaptor();
        UserManager userManager;
        UserManager UserManager => userManager ?? (userManager = new UserManager());
        public bool AddUser(UserDto user)
        {
            return UserManager.AddUser(userAdaptor.ToUserEntity(user));
        }

        public bool Auth(string id, string password)
        {
            return UserManager.Auth(id, password);
        }

        public List<UserDto> GetAll()
        {
            return userAdaptor.GetListUserDto(UserManager.GetAll());
        }

        public bool Update(UserDto user)
        {
            return UserManager.Update(userAdaptor.ToUserEntity(user));
        }
    }
}
