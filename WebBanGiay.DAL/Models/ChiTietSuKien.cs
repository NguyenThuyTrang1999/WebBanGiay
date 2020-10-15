using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class ChiTietSuKien
    {
        public int MaSuKien { get; set; }
        public int MaSp { get; set; }
        public DateTime? NgayDang { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
        public virtual SuKien MaSuKienNavigation { get; set; }
    }
}
