using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomManager.DbManager.Models;

namespace ClassroomManager.DbManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly ClassroomManagerEntities entities = new ClassroomManagerEntities();
        public bool AddUser(User user)
        {
            try
            {
                entities.Users.Add(user);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Auth(string id, string pass)
        {
            try
            {
                return entities.Users.Any(u => u.UserId.Equals(id) && u.Password.Equals(pass));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            return entities.Users.ToList();
        }

        public bool Update(User user)
        {
            try
            {
                User temp = entities.Users.SingleOrDefault(u => u.UserId.Equals(user.UserId));
                temp.Username = user.Username;
                temp.Role = user.Role;
                temp.Password = user.Password;
                entities.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
