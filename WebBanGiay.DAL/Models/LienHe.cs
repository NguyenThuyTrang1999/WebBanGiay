using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class LienHe
    {
        public string IdLienHe { get; set; }
        public string IdNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string NoiDung { get; set; }

        public virtual NguoiDung IdNguoiDungNavigation { get; set; }
    }
}
