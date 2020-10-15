using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class Hinh
    {
        public int MaHinh { get; set; }
        public int? MaSp { get; set; }
        public DateTime? NgDang { get; set; }
        public string DuongDanHinh { get; set; }
        public int? LoaiHinh { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
    }
}
