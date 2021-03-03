using System;
using System.Collections.Generic;
using System.Text;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.BLL.Svc
{
    public class OrderDetailsSvc
    { 
        private readonly OrderDetailsRep rep;

        public OrderDetailsSvc()
        {
            rep = new OrderDetailsRep();
        }

        public object CreateOrderDetail(OrderDetailsReq[] reqList)
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            foreach (OrderDetailsReq req in reqList)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderID = req.OrderID;
                orderDetails.ProductID = req.ProductID;
                orderDetails.Amounts = req.Amounts;
                orderDetails.Note = req.Note;
                orderDetailsList.Add(orderDetails);
            }
            return rep.Create(orderDetailsList);
        }
    }
}
