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
using System.Net;

namespace ShoesShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerSvc customerSvc;
        public CustomerController()
        {
            customerSvc = new CustomerSvc();
        }


        [HttpPost("Create_Customer")]
        public IActionResult CreateCustomer(CustomerReq req)
        {
            var result = customerSvc.CreateCustomer(req);
            return Ok(result);
        }


        [HttpGet("Search_Customer/{size},{page}")]
        public IActionResult SearchCustomer(int size, int page, String keyword)
        {
            var result = customerSvc.SearchCustomer(size, page, keyword);
            return Ok(result);
        }


        [HttpGet("GetCustomerByAccount/{account}")]
        public IActionResult GetCustomerByAccount(String account)
        {
            var result = customerSvc.GetCustomerByAccount(account);
            return Ok(result);
        }


        [HttpPut("Update_Customer/{account}")]
        public IActionResult UpdateAccount(String account, CustomerReq req)
        {
            var result = customerSvc.UpdateCustomer(account, req);
            return Ok(result);
        }


        [HttpDelete("Delete_Customer/{account}")]
        public IActionResult DeleteCustomer(String account)
        {
            var result = customerSvc.DeleteCustomer(account);
            return Ok(result);
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginReq req)
        {
            IActionResult response = Unauthorized();
            var user = customerSvc.ValidateCustomer(req);
            if (user != null)
            {
                response = Ok(new
                {
                    account = user.Account,
                    status = user.AccountStatus
                });
            }
            else
            {
                response = Ok(new
                {
                    account = "",
                    pass = ""
                });
            }
            return response;
        }
    }
}
