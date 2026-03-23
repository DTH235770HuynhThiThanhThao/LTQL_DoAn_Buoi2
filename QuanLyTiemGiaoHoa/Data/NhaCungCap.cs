using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemGiaoHoa.Data
{
    public class NhaCungCap
    {
        public int ID { get; set; }
        public string TenNhaCungCap { get; set; }

        public ICollection<Hoa> Hoa { get; set; } = new List<Hoa>();
    }
}
