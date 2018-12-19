namespace ClassroomManager.DbManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongHoc")]
    public partial class PhongHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongHoc()
        {
            ThietBiPhongHocs = new HashSet<ThietBiPhongHoc>();
            ThongTinBanGiaos = new HashSet<ThongTinBanGiao>();
        }

        [Key]
        public int MaPhong { get; set; }

        public int MaLoaiPhong { get; set; }

        public int MaToaNha { get; set; }

        [Required]
        [StringLength(14)]
        public string TenPhong { get; set; }

        public string GhiChu { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        public virtual ToaNha ToaNha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThietBiPhongHoc> ThietBiPhongHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBanGiao> ThongTinBanGiaos { get; set; }
    }
}
