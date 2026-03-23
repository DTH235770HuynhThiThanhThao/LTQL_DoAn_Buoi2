using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class GiaoHang
    {
        public int ID { get; set; }

        public int HoaDonID { get; set; }
        public int NhanVienID { get; set; } // nhân viên giao

        public string DiaChiGiao { get; set; }
        public DateTime NgayGiao { get; set; }

        //public string TrangThai { get; set; }
        // VD: "Chờ giao", "Đang giao", "Đã giao", "Hủy"
        // DÙNG ENUM (thay cho string)
        public TrangThaiGiaoHang TrangThai { get; set; } = TrangThaiGiaoHang.ChoGiao;

        public string? GhiChu { get; set; }

        // Navigation
        public HoaDon HoaDon { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
