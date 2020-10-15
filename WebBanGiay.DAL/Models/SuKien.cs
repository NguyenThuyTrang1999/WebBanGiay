using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class SuKien
    {
        public SuKien()
        {
            ChiTietSuKien = new HashSet<ChiTietSuKien>();
        }

        public int MaSuKien { get; set; }
        public string TieuDe { get; set; }
        public string AnhDaiDien { get; set; }
        public string ChiTiet { get; set; }
        public DateTime? NgayDang { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<ChiTietSuKien> ChiTietSuKien { get; set; }
    }
}
