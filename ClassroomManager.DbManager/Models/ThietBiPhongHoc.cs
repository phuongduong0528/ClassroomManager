namespace ClassroomManager.DbManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThietBiPhongHoc")]
    public partial class ThietBiPhongHoc
    {
        public int Id { get; set; }

        public int MaPhong { get; set; }

        public int MaThietBi { get; set; }

        public int SoLuong { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }

        public virtual ThietBi ThietBi { get; set; }
    }
}
