using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class ChiTietSuKien
    {
        public string IdSuKien { get; set; }
        public string MaSp { get; set; }
        public DateTime? NgayDang { get; set; }

        public virtual SuKien IdSuKienNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
