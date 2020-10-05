using System;
using System.Collections.Generic;

namespace WebBanGiay.DAL.Models
{
    public partial class MenuCha
    {
        public MenuCha()
        {
            MenuCon = new HashSet<MenuCon>();
        }

        public string IdCha { get; set; }
        public string TenMenuCha { get; set; }

        public virtual ICollection<MenuCon> MenuCon { get; set; }
    }
}
