using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class BrandReq
    {
        public String BrandID { get; set; }
        public String BrandName { get; set; }
        public DateTime CreateDay { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
        public String Note { get; set; }
    }
}
