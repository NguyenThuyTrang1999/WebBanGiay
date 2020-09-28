using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class SanPham
    {
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string AnhSp { get; set; }
        public string ThongTinChiTiet { get; set; }
        public bool? Spkm { get; set; }
        public bool? Sphot { get; set; }
        public bool? Active { get; set; }
        public double? GiaBd { get; set; }
        public double? GiaHt { get; set; }
        public DateTime? NgayDang { get; set; }
        public string IdCon { get; set; }
    }
}
