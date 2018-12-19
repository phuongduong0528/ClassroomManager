namespace ClassroomManager.DbManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinBanGiao")]
    public partial class ThongTinBanGiao
    {
        public int Id { get; set; }

        public int MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        [Required]
        public string TinhTrang { get; set; }

        [Required]
        [StringLength(10)]
        public string UserId { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }

        public virtual User User { get; set; }
    }
}
