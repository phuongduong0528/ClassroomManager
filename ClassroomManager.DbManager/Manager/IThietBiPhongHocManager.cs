using ClassroomManager.DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManager.DbManager.Manager
{
    interface IThietBiPhongHocManager
    {
        List<ThietBiPhongHoc> GetByClass(string name);
        bool AddThietBi(ThietBiPhongHoc thietBiPhongHoc);
        bool UpdateThietBi(ThietBiPhongHoc thietBiPhongHoc);
    }
}
