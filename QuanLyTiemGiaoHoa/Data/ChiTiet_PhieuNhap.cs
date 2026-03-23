using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class ChiTiet_PhieuNhap
    {
        public int ID { get; set; }

        public int PhieuNhapID { get; set; }
        public int HoaID { get; set; }

        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal ThanhTien { get; set; }

        // Navigation
        public PhieuNhap PhieuNhap { get; set; }
        public Hoa Hoa { get; set; }
    }
}
