using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesShopWebApp.BLL.Svc;
using ShoesShopWebApp.Common.Req;
using Newtonsoft.Json;

namespace ShoesShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartSvc cartSvc;
        public CartController()
        {
            cartSvc = new CartSvc();
        }


        [HttpPost("Create_Cart")]
        public IActionResult CreateCart(CartReq req)
        {
            var result = cartSvc.CreateCart(req);
            return Ok(result);
        }


        [HttpGet("Get_Cart_By_Customer/{account}")]
        public IActionResult SearchBrand(String account)
        {
            var result = cartSvc.GetCartByCustomer(account);
            return Ok(result);
        }


        [HttpPut("Update_Cart/{account},{id}")]
        public IActionResult UpdateCart(String account, String id, ProductListReq req)
        {
            var result = cartSvc.UpdateCart(account, id, req);
            return Ok(result);
        }


        [HttpDelete("Delete_Product_In_Cart/{account},{id}")]
        public IActionResult DeleteProductInCart(String account, String id)
        {
            var result = cartSvc.DeleteProductInCart(account, id);
            return Ok(result);
        }


        [HttpDelete("Delete_Cart/{account}")]
        public IActionResult DeleteCart(String account)
        {
            var result = cartSvc.DeleteCart(account);
            return Ok(result);
        }
    }
}
