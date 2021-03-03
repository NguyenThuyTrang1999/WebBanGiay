using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;


namespace ShoesShopWebApp.BLL.Svc
{
    public class UserVerifySvc
    {
        private readonly UserVerifyRep userVerifyRep;
        public UserVerifySvc()
        {
            userVerifyRep = new UserVerifyRep();
        }

        public object SearchUser (String account, String pass)
        {
            return userVerifyRep.SearchUser(account, pass);
        }
    }
}
