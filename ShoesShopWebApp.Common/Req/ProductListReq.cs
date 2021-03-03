using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class ProductListReq
    {
        public String Account { get; set; }
        public String[] ProductIdList { get; set; }
        public int[] Amount { get; set; }
    }
}
