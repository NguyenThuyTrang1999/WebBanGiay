using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class GioHang
    {
        public string IdDonHang { get; set; }
        public string MaSp { get; set; }
        public byte? Sl { get; set; }
        public double? DonGia { get; set; }
    }
}
