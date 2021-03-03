using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesShopWebApp.BLL.Svc;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsSvc svc;
        public OrderDetailsController()
        {
            svc = new OrderDetailsSvc();
        }
        [HttpPost("createOrderDetails")]
        public IActionResult CreateOrderDetail(OrderDetailsReq[] reqList)
        {
            var result = svc.CreateOrderDetail(reqList);
            return Ok(result);
        }
    }
}
