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
    public class OrderController : ControllerBase
    {
        private readonly OrderSvc orderSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
        }

        [HttpPost("Create_Order")]
        public IActionResult CreateOrder(OrderReq req)
        {
            var result = orderSvc.CreateOrder(req);
            return Ok(result);
        }


        [HttpGet("Search_Order/{size},{page}")]
        public IActionResult SearchOrder(int size, int page, int keyword, String cusid)
        {
            var result = orderSvc.SearchOrder(size, page, keyword, cusid);
            return Ok(result);
        }


        [HttpGet("Get_Order_By_Customer/")]
        public IActionResult GetOrderByCustomer(int keyword, String cusid)
        {
            var result = orderSvc.GetOrderByCustomer(keyword, cusid);
            return Ok(result);
        }


        [HttpGet("Get_OrderDetail/{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            var result = orderSvc.GetOrderDetail(id);
            return Ok(result);
        }


        [HttpPut("Update_Order/{id}")]
        public IActionResult UpdateOrder(int id, OrderReq req)
        {
            var result = orderSvc.UpdateOrder(id, req);
            return Ok(result);
        }


        [HttpPut("Update_Order_Status/{id}")]
        public IActionResult UpdateStatus(int id, UpdateStatusReq status)
        {
            var result = orderSvc.UpdateStatus(id, status);
            return Ok(result);
        }


        [HttpDelete("Delete_Order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = orderSvc.DeleteOrder(id);
            return Ok(result);
        }
    }
}
