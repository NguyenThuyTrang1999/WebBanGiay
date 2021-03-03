using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;
using System.Dynamic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ShoesShopWebApp.DAL.Rep
{
    public class CartRep
    {
        private Context context;


        public CartRep()
        {
            context = new Context();
        }


        public object Create(Cart cart)
        {
            try
            {
                context.Cart.Add(cart);
                context.SaveChanges();
                return cart;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Update(String account, String id, ProductListReq req)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                List<Cart> resultList = new List<Cart>();
                int index = 0;
                foreach (String ProductID in req.ProductIdList)
                {
                    var result = context.Cart.FirstOrDefault(c => c.Account == req.Account && c.ProductID == ProductID);
                    result.Amounts = req.Amount[index];
                    resultList.Add(result);
                    index++;
                }
                try
                {
                    context.Cart.UpdateRange(resultList);
                    context.SaveChanges();
                    transaction.Commit();
                    return resultList;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.StackTrace;
                }
            }       
        }


        public object Delete(String account, String id)
        {
            using (var transaction = context.Database.BeginTransaction()) //Sử Dụng transaction để xử lý tuần tự
            {
                try
                {
                    var result = context.Cart.FirstOrDefault(value => value.ProductID == id && value.Account == account);
                    if (result != null)
                    {
                        context.Cart.Remove(result);
                        context.SaveChanges();
                        transaction.Commit(); //Nếu transaction được thực hiện thành công thì mới lưu vào CSDL
                        return result;
                    }
                    else
                    {
                        return "Unable to delete: not found.";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); //Nếu xảy ra lỗi thì dữ liệu được khôi phục về trạng thái trước khi thực hiện transaction
                    return ex.StackTrace;
                }
            }
        }
       

        public object DeleteRange(String account)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var result = context.Cart.Where(c => c.Account == account);
                try
                {
                    context.Cart.RemoveRange(result);
                    context.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }


        public object GetCartByCustomer(String account)
        {
            var result = context.Cart
            .Where(c => c.Account == account)
            .Join(context.Product, c => c.ProductID, p => p.ProductID, (c, p) => new
               {
                   p.ProductName,
                   p.Unit,
                   p.Price,
                   p.UnitsInStock,
                   p.Picture,
                   c.Amounts,
                   priceTotal = p.Price * c.Amounts,
                   c.Account,
                   c.ProductID
               }).ToArray();
            try
            {
                if (result != null)
                {
                    var data = new
                    {
                        CartList = result
                    };
                    return data;
                }
                else
                {
                    return "Unable to get: not found.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
