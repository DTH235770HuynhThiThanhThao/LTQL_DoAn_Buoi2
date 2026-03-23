using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }

        // Navigation
        public ICollection<HoaDon> HoaDon { get; set; } = new List<HoaDon>();
    }
}
