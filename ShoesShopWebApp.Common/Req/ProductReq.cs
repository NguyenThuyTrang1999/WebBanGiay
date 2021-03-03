using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class ProductReq
    {
        public String ProductID { get; set; }
        public String ProductName { get; set; }
        public int Price { get; set; }
        public String BrandID { get; set; }
        public String CategoryID { get; set; }
        public DateTime CreateDate { get; set; }
        public String Unit { get; set; }
        public int UnitsInStock { get; set; }
        public float Discount { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
        public String Note { get; set; }
    }
}
