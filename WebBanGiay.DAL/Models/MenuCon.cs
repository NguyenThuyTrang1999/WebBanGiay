using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class MenuCon
    {
        public MenuCon()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int MaCon { get; set; }
        public int? MaCha { get; set; }
        public string TenMenuCon { get; set; }

        public virtual MenuCha MaChaNavigation { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
