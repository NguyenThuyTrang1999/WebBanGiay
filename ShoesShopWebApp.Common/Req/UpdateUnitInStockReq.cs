using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class UpdateUnitInStockReq
    {
        public String ProductID { get; set; }
        public int UnitsInStock { get; set; }
    }
}
