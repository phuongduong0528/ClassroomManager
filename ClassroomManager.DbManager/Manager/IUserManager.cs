using ClassroomManager.DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.DbManager.Manager
{
    interface IUserManager
    {
        bool Auth(string id, string pass);
        List<User> GetAll();
        bool AddUser(User user);
        bool Update(User user);
    }
}
