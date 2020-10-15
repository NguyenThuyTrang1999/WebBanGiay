using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class GioHang
    {
        public int MaDonHang { get; set; }
        public int MaSp { get; set; }
        public byte? Sl { get; set; }
        public double? DonGia { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
    }
}
