using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class Hinh
    {
        public string IdHinh { get; set; }
        public string MaSp { get; set; }
        public DateTime? NgayDang { get; set; }
        public string DuongDanHinh { get; set; }
        public int? LoaiHinh { get; set; }
    }
}
