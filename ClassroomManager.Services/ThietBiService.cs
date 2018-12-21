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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ThietBiService" in both code and config file together.
    public class ThietBiService : IThietBiService
    {
        readonly ThietBiAdaptor thietBiAdaptor = new ThietBiAdaptor();
        ThietBiManager thietBiManager;
        ThietBiManager ThietBiManager => thietBiManager ?? (thietBiManager = new ThietBiManager());

        public bool Add(ThietBiDto thietBiDto)
        {
            return ThietBiManager.Add(thietBiAdaptor.ToThietBiEntity(thietBiDto));
        }

        public bool Delete(int id)
        {
            return ThietBiManager.Delete(id);
        }

        public List<ThietBiDto> GetAll()
        {
            return thietBiAdaptor.GetListThietBiDto(ThietBiManager.GetAll());
        }

        public List<ThietBiDto> GetByFilter(string group, string name)
        {
            return thietBiAdaptor.GetListThietBiDto(ThietBiManager.GetByFilter(group, name));
        }

        public List<string> GetNhomTB()
        {
            return ThietBiManager.GetNhomTB();
        }

        public bool Update(ThietBiDto thietBiDto)
        {
            return ThietBiManager.Update(thietBiAdaptor.ToThietBiEntity(thietBiDto));
        }
    }
}
