using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class OrderDetailsReq
    {
        public int OrderID { get; set; }
        public String ProductID { get; set; }
        public int Amounts { get; set; }
        public String Note { get; set; }
    }
}
