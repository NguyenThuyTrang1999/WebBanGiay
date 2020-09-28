﻿using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class DonHang
    {
        public string IdDonHang { get; set; }
        public string IdNguoiDung { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }
        public double? TongTien { get; set; }
        public bool? TrangThai { get; set; }
    }
}