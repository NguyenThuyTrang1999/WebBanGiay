using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.DAL.Rep
{
    public class UserVerifyRep
    {
        private Context context;


        public UserVerifyRep()
        {
            context = new Context();
        }
        public object SearchUser (String account, String pass)
        {
            //Tìm kiếm tài khoản từ 2 bảng Customer và Employee
            try
            { 
                var resultEmployee = context.Employee.FirstOrDefault(value => value.Account == account && value.Pass == pass);
                if (resultEmployee != null)
                {
                    var res = new
                    {
                        account = resultEmployee.Account,
                        password = resultEmployee.Pass,
                    };
                    return res;
                }
                else
                {
                    var resultCustomer = context.Customer.FirstOrDefault(value => value.Account == account && value.Pass == pass);
                    if (resultCustomer != null)
                    {
                        var res = new
                        {
                            account = resultCustomer.Account,
                            password = resultCustomer.Pass,
                        };
                        return res;
                    }
                    else
                    {
                        return "Not found Account.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
