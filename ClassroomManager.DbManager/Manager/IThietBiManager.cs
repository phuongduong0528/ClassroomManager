using ClassroomManager.DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.DbManager.Manager
{
    interface IThietBiManager
    {
        List<ThietBi> GetAll();
        List<ThietBi> GetByFilter(string group, string name);
        bool Add(ThietBi thietBi);
        bool Update(ThietBi thietBi);
        bool Delete(int id);
    }
}
