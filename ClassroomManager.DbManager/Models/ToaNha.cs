namespace ClassroomManager.DbManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ToaNha")]
    public partial class ToaNha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToaNha()
        {
            PhongHocs = new HashSet<PhongHoc>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaToaNha { get; set; }

        public int MaCoSo { get; set; }

        [Required]
        [StringLength(20)]
        public string TenToaNha { get; set; }

        public virtual CoSo CoSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongHoc> PhongHocs { get; set; }
    }
}
