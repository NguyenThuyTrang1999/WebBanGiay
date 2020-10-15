using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBanGiay.DAL.Models
{
    public partial class QLBanGiayContext : DbContext
    {
        public QLBanGiayContext()
        {
        }

        public QLBanGiayContext(DbContextOptions<QLBanGiayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<ChiTietSuKien> ChiTietSuKien { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<Hinh> Hinh { get; set; }
        public virtual DbSet<LienHe> LienHe { get; set; }
        public virtual DbSet<MenuCha> MenuCha { get; set; }
        public virtual DbSet<MenuCon> MenuCon { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<SuKien> SuKien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=CHANGXINHGAI;Initial Catalog=QLBanGiay;Persist Security Info=True;User ID=sa;Password=1;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.MaBl);

                entity.Property(e => e.MaBl)
                    .HasColumnName("MaBL")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.NgayGio).HasColumnType("datetime");

                entity.Property(e => e.TieuDe)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_BinhLuan_NguoiDung");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_BinhLuan_SanPham");
            });

            modelBuilder.Entity<ChiTietSuKien>(entity =>
            {
                entity.HasKey(e => new { e.MaSuKien, e.MaSp });

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.NgayDang).HasColumnType("datetime");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietSuKien)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSuKien_SanPham");

                entity.HasOne(d => d.MaSuKienNavigation)
                    .WithMany(p => p.ChiTietSuKien)
                    .HasForeignKey(d => d.MaSuKien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSuKien_SuKien");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang);

                entity.Property(e => e.MaDonHang).ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.TenKh)
                    .HasColumnName("TenKH")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.DonHang)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_DonHang_NguoiDung");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDonHang, e.MaSp });

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.GioHang)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_SanPham");
            });

            modelBuilder.Entity<Hinh>(entity =>
            {
                entity.HasKey(e => e.MaHinh);

                entity.Property(e => e.MaHinh).ValueGeneratedNever();

                entity.Property(e => e.DuongDanHinh)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.NgDang).HasColumnType("date");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Hinh)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_Hinh_SanPham");
            });

            modelBuilder.Entity<LienHe>(entity =>
            {
                entity.HasKey(e => e.MaLienHe);

                entity.Property(e => e.MaLienHe).ValueGeneratedNever();

                entity.Property(e => e.HoTen)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.LienHe)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_LienHe_NguoiDung");
            });

            modelBuilder.Entity<MenuCha>(entity =>
            {
                entity.HasKey(e => e.MaCha);

                entity.Property(e => e.MaCha).ValueGeneratedNever();

                entity.Property(e => e.TenMenuCha)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MenuCon>(entity =>
            {
                entity.HasKey(e => e.MaCon);

                entity.Property(e => e.MaCon).ValueGeneratedNever();

                entity.Property(e => e.TenMenuCon)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.MaChaNavigation)
                    .WithMany(p => p.MenuCon)
                    .HasForeignKey(d => d.MaCha)
                    .HasConstraintName("FK_MenuCon_MenuCha");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung);

                entity.Property(e => e.MaNguoiDung).ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.HoVaTen)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.TenUser)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnhSp)
                    .HasColumnName("AnhSP")
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.GiaBd).HasColumnName("GiaBD");

                entity.Property(e => e.GiaHt).HasColumnName("GiaHT");

                entity.Property(e => e.NgayDang).HasColumnType("date");

                entity.Property(e => e.Sphot).HasColumnName("SPHot");

                entity.Property(e => e.Spkm).HasColumnName("SPKM");

                entity.Property(e => e.TenSp)
                    .HasColumnName("TenSP")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.MaConNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.MaCon)
                    .HasConstraintName("FK_SanPham_MenuCon");
            });

            modelBuilder.Entity<SuKien>(entity =>
            {
                entity.HasKey(e => e.MaSuKien);

                entity.Property(e => e.MaSuKien).ValueGeneratedNever();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.NgayDang).HasColumnType("date");

                entity.Property(e => e.TieuDe)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
