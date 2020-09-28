using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class SuKien
    {
        public string IdSuKien { get; set; }
        public string TieuDe { get; set; }
        public string AnhDaiDien { get; set; }
        public string ChiTiet { get; set; }
        public DateTime? NgayDang { get; set; }
        public bool? Active { get; set; }
    }
}
