using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class BinhLuan
    {
        public string MaBl { get; set; }
        public string TieuDe { get; set; }
        public int? SoLuotKhongThich { get; set; }
        public DateTime? NgayGio { get; set; }
        public int? SoLuotThich { get; set; }
        public string NoiDung { get; set; }
        public string IdNguoiDung { get; set; }
        public string MaSp { get; set; }

        public virtual NguoiDung IdNguoiDungNavigation { get; set; }
    }
}
