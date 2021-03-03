using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.DAL.Rep
{
    public class OrderRep
    {
        private Context context;


        public OrderRep()
        {
            context = new Context();
        }


        public object Create(Orders orders)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Orders.Add(orders);
                    context.SaveChanges();
                    tran.Commit();
                    return orders;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }  
        }


        public object Update(int id, OrderReq req)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    var result = context.Orders.FirstOrDefault(value => value.OrderID == id);
                    if (result != null)
                    {
                        result.Name = req.Name;
                        result.CreatedDate = req.CreatedDate;
                        result.PhoneNumberOfOrder = req.PhoneNumberOfOrder;
                        result.Address = req.Address;
                        result.Status = req.Status;
                        result.Note = req.Note;
                        result.EmpId = req.EmpId;
                        result.CusId = req.CusId;
                        context.Orders.Update(result);
                        context.SaveChanges();
                        tran.Commit();
                        return result;
                    }
                    else
                    {
                        return "Unable to update: not found ID.";
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }       
        }


        public object UpdateStatus(int id, UpdateStatusReq status)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    var result = context.Orders.FirstOrDefault(value => value.OrderID == id);
                    if (result != null)
                    {
                        result.Status = status.Status;
                        context.Orders.Update(result);
                        context.SaveChanges();
                        tran.Commit();
                        return result;
                    }
                    else
                    {
                        return "Unable to update: not found ID.";
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }
        }


        public object Delete(int id)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                var result = context.Orders.FirstOrDefault(value => value.OrderID == id);
                try
                {
                    if (result != null)
                    {
                        context.Orders.Remove(result);
                        context.SaveChanges();
                        tran.Commit();
                        return result;
                    }
                    else
                    {
                        return "Unable to delete: not found ID.";
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }        
        }




        public object GetOrderDetail(int id)
        {
            var data = context.Orders.Where(o => o.OrderID == id)
            .Join(context.OrderDetails, o => o.OrderID, od => od.OrderID, (o, od) => new
            {
                o.OrderID,
                od.ProductID,
                od.Amounts
            })
            .Join(context.Product, o => o.ProductID, p => p.ProductID, (o, p) => new
            {
                p.ProductName,
                p.Price,
                o.Amounts,
                p.Discount,
                TotalPrice = (p.Price - (p.Price * (p.Discount / 100))) * o.Amounts,
                p.Picture

            }).ToArray();
            var result = new {
                Data = data
            };
            return result;
        }


        public IQueryable<Orders> All
        {
            get
            {
                IQueryable<Orders> result = context.Orders;
                return result;
            }
        }
    }
}
