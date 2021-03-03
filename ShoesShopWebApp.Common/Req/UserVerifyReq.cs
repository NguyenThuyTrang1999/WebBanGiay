using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class UserVerifyReq
    {
        public String Account { get; set; }
        public String Pass { get; set; }
        public String AccountTypeID { get; set; }
    }
}
