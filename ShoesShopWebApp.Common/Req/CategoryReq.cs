using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class CategoryReq
    {
        public String CategoryID { get; set; }
        public String CategoryName { get; set; }
        public DateTime CreateDay { get; set; }
        public String Description { get; set; }
        public String Note { get; set; }
    }
}
