using ShoesShopWebApp.Common.Req;
using System;
using System.Collections.Generic;
using System.Text;
using ShoesShopWebApp.DAL.Model;
using System.Linq;

namespace ShoesShopWebApp.DAL.Rep
{
    public class OrderDetailsRep
    {
        private Context context;


        public OrderDetailsRep()
        {
            context = new Context();
        }


        public object Create(List<OrderDetails> orderDetails)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.OrderDetails.AddRange(orderDetails);
                    context.SaveChanges();
                    tran.Commit();
                    return orderDetails;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }
        }

    }
}
