using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class BinhLuan
    {
        public int MaBl { get; set; }
        public string TieuDe { get; set; }
        public int? SoLuotKhongThich { get; set; }
        public DateTime? NgayGio { get; set; }
        public int? SoLuotThich { get; set; }
        public string NoiDung { get; set; }
        public int? MaNguoiDung { get; set; }
        public int? MaSp { get; set; }

        public virtual NguoiDung MaNguoiDungNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
