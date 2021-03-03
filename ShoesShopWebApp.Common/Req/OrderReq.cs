using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class OrderReq
    {
        public String Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public String PhoneNumberOfOrder { get; set; }
        public String Address { get; set; }
        public int TotalPrice { get; set; }
        public String Status { get; set; }
        public String Note { get; set; }
        public String EmpId { get; set; }
        public String CusId { get; set; }
    }
}
