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

        public string IdCon { get; set; }
        public string IdCha { get; set; }
        public string TenMenuCon { get; set; }

        public virtual MenuCha IdChaNavigation { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
