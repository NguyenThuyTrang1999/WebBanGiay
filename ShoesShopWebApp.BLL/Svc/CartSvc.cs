using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;
namespace ShoesShopWebApp.BLL.Svc
{
    public class CartSvc
    {
        private readonly CartRep cartRep;
        public CartSvc()
        {
            cartRep = new CartRep();
        }


        public object CreateCart(CartReq req)
        {
            Cart cart = new Cart();
            cart.Account = req.Account;
            cart.ProductID = req.ProductID;
            cart.Amounts = req.Amounts;
            cart.Note = req.Note;
            return cartRep.Create(cart);
        }


        public object UpdateCart(String account, String id, ProductListReq req)
        {
            return cartRep.Update(account, id, req);
        }


        public object DeleteProductInCart(String account, String id)
        {
            return cartRep.Delete(account, id);
        }


        public object DeleteCart(String account)
        {
            return cartRep.DeleteRange(account);
        }


        public object GetCartByCustomer(String account)
        {
            return cartRep.GetCartByCustomer(account);
        }
    }
}
