using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class Hoa
    {
        public int ID { get; set; }

        public int NhaCungCapID { get; set; }

        public int LoaiHoaID { get; set; }



        public string TenHoa { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }

        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }

        // Navigation
        public LoaiHoa LoaiHoa { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
    }

    public class DanhSachHoa
    {
        public int ID { get; set; }

        public int NhaCungCapID { get; set; }
        public string TenNhaCungCap { get; set; }  //Thêm
        public int LoaiHoaID { get; set; }
        public string TenLoai { get; set; }   //Thêm


        public string TenHoa { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }

        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }

        // Navigation
        public LoaiHoa LoaiHoa { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
    }
}
