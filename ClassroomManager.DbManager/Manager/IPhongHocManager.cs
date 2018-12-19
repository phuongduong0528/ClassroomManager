using ClassroomManager.DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.DbManager.Manager
{
    interface IPhongHocManager
    {
        List<PhongHoc> GetByCoSo(string cs, string nha);
        bool Add(PhongHoc ph);
        bool Update(PhongHoc ph);
    }
}
