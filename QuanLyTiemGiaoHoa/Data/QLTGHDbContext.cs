using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // Thêm dòng này vào đầu file

namespace QuanLyTiemGiaoHoa.Data
{
    public class QLTGHDbContext : DbContext
    {
        public DbSet<LoaiHoa> LoaiHoa { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }
        public DbSet<Hoa> Hoa { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public DbSet<PhieuNhap> PhieuNhap { get; set; }
        public DbSet<ChiTiet_PhieuNhap> ChiTiet_PhieuNhap { get; set; }
        public DbSet<GiaoHang> GiaoHang { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLTGHConnection"].ConnectionString);
        }
        // dùng hàm này để tạo csdl 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model
                     .GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
