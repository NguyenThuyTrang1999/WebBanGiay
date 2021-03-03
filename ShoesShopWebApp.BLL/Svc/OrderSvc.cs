using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;

namespace ShoesShopWebApp.BLL.Svc
{
    public class OrderSvc
    {
        private readonly OrderRep orderRep;
        public OrderSvc()
        {
            orderRep = new OrderRep();
        }


        public object CreateOrder(OrderReq req)
        {
            Orders orders = new Orders();
            orders.Name = req.Name;
            orders.CreatedDate = req.CreatedDate;
            orders.PhoneNumberOfOrder = req.PhoneNumberOfOrder;
            orders.Address = req.Address;
            orders.TotalPrice = req.TotalPrice;
            orders.Status = req.Status;
            orders.Note = req.Note;
            orders.EmpId = req.EmpId;
            orders.CusId = req.CusId;
            return orderRep.Create(orders);
        }


        public object UpdateOrder(int id, OrderReq req)
        {
            return orderRep.Update(id, req);
        }


        public object UpdateStatus(int id, UpdateStatusReq status)
        {
            return orderRep.UpdateStatus(id, status);
        }


        public object SearchOrder(int size, int page, int keyword, String cusid)
        {
            var allValues = orderRep.All;
            if (keyword != 0 || !string.IsNullOrEmpty(cusid))
            {
                allValues = orderRep.All.Where(value => value.OrderID == keyword || value.CusId == cusid);
            }
            int offset = (page - 1) * size;
            int total = allValues.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = allValues.Skip(offset).Take(size).ToList();
            var result = new
            {
                Data = data,
                totalRecord = total,
                Page = page,
                Size = size,
                TotalPage = totalPage
            };
            return result;
        }


        public object GetOrderByCustomer(int keyword, String cusid)
        {
            var allValues = orderRep.All;
            if (keyword != 0 || !string.IsNullOrEmpty(cusid))
            {
                allValues = orderRep.All.Where(value => value.OrderID == keyword || value.CusId == cusid);
            }
            var data = allValues.ToList();
            var result = new
            {
                Data = data
            };
            return result;
        }


        public object GetOrderDetail(int id)
        {
            return orderRep.GetOrderDetail(id);
        }

        public object DeleteOrder(int id)
        {
            return orderRep.Delete(id);
        }
    }
}
