using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class LoaiHoa
    {
        public int ID { get; set; }
        public string TenLoai { get; set; }

        public ICollection<Hoa> Hoa { get; set; } = new List<Hoa>();
    }
}
