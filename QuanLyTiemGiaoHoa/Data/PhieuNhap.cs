using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class PhieuNhap
    {
        public int ID { get; set; }

        public int NhanVienID { get; set; }
        public int NhaCungCapID { get; set; }

        public DateTime NgayNhap { get; set; }
        public decimal? TongTien { get; set; }

        public string? GhiChu { get; set; }

        // Navigation
        public NhanVien NhanVien { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public ICollection<ChiTiet_PhieuNhap> ChiTiet_PhieuNhap { get; set; } = new List<ChiTiet_PhieuNhap>();
    }
}
