﻿using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietSuKien = new HashSet<ChiTietSuKien>();
            GioHang = new HashSet<GioHang>();
            Hinh = new HashSet<Hinh>();
        }

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

        public virtual MenuCon IdConNavigation { get; set; }
        public virtual ICollection<ChiTietSuKien> ChiTietSuKien { get; set; }
        public virtual ICollection<GioHang> GioHang { get; set; }
        public virtual ICollection<Hinh> Hinh { get; set; }
    }
}
