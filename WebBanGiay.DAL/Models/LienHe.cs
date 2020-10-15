using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class LienHe
    {
        public int MaLienHe { get; set; }
        public int? MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string NoiDung { get; set; }

        public virtual NguoiDung MaNguoiDungNavigation { get; set; }
    }
}
