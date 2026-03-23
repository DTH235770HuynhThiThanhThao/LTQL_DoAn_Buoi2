using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class HoaDon_ChiTiet
    {
        public int ID { get; set; }

        public int HoaDonID { get; set; }
        public int HoaID { get; set; }

        public short SoLuongBan { get; set; }
        public decimal DonGiaBan { get; set; }

        // Navigation
        public HoaDon HoaDon { get; set; }
        public Hoa Hoa { get; set; }
    }

    public class DanhSachHoaDon_ChiTiet
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int HoaID { get; set; }
        public string TenHoa { get; set; } // Thêm 
        public short SoLuongBan { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal ThanhTien { get; set; } // Thêm 
    }
}
