namespace ClassroomManager.DbManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThietBi")]
    public partial class ThietBi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThietBi()
        {
            ThietBiPhongHocs = new HashSet<ThietBiPhongHoc>();
        }

        [Key]
        public int MaThietBi { get; set; }

        public int MaNhomThietBi { get; set; }

        [Required]
        [StringLength(50)]
        public string TenThietBi { get; set; }

        public virtual NhomThietBi NhomThietBi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThietBiPhongHoc> ThietBiPhongHocs { get; set; }
    }
}
