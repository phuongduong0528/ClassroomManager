namespace ClassroomManager.DbManager.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClassroomManagerEntities : DbContext
    {
        public ClassroomManagerEntities()
            : base("name=ClassroomManagerEntities")
        {
        }

        public virtual DbSet<CoSo> CoSoes { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhomThietBi> NhomThietBis { get; set; }
        public virtual DbSet<PhongHoc> PhongHocs { get; set; }
        public virtual DbSet<ThietBi> ThietBis { get; set; }
        public virtual DbSet<ThietBiPhongHoc> ThietBiPhongHocs { get; set; }
        public virtual DbSet<ThongTinBanGiao> ThongTinBanGiaos { get; set; }
        public virtual DbSet<ToaNha> ToaNhas { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoSo>()
                .HasMany(e => e.ToaNhas)
                .WithRequired(e => e.CoSo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.PhongHocs)
                .WithRequired(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomThietBi>()
                .HasMany(e => e.ThietBis)
                .WithRequired(e => e.NhomThietBi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.ThietBiPhongHocs)
                .WithRequired(e => e.PhongHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.ThongTinBanGiaos)
                .WithRequired(e => e.PhongHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThietBi>()
                .HasMany(e => e.ThietBiPhongHocs)
                .WithRequired(e => e.ThietBi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinBanGiao>()
                .Property(e => e.UserId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ToaNha>()
                .HasMany(e => e.PhongHocs)
                .WithRequired(e => e.ToaNha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ThongTinBanGiaos)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
