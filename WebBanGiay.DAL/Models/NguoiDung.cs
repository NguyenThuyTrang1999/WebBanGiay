using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            BinhLuan = new HashSet<BinhLuan>();
            DonHang = new HashSet<DonHang>();
            LienHe = new HashSet<LienHe>();
        }

        public string IdNguoiDung { get; set; }
        public string TenUser { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public byte? Quyen { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }
        public virtual ICollection<LienHe> LienHe { get; set; }
    }
}
