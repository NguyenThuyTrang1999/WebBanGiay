using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesShopWebApp.BLL.Svc;
using ShoesShopWebApp.Common.Req;
using Newtonsoft.Json;

namespace ShoesShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeSvc employeeSvc;
        public EmployeeController()
        {
            employeeSvc = new EmployeeSvc();
        }

            

        [HttpPost("Create_Employee")]
        public IActionResult CreateEmployee(EmployeeReq req)
        {
            var result = employeeSvc.CreateEmployee(req);
            return Ok(result);
        }


        [HttpGet("Search_Employee/{size},{page}")]
        public IActionResult SearchEmployee(int size, int page, String keyword)
        {
            var result = employeeSvc.SearchEmployee(size, page, keyword);
            return Ok(result);
        }


        [HttpGet("GetEmployeeByAccount/{account}")]
        public IActionResult GetEmployeeByAccount(String account)
        {
            var result = employeeSvc.GetEmployeeByAccount(account);
            return Ok(result);
        }


        [HttpPut("Update_Employee/{account}")]
        public IActionResult UpdateEmployee(String account, EmployeeReq req)
        {
            var result = employeeSvc.UpdateEmployee(account, req);
            return Ok(result);
        }


        [HttpDelete("Delete_Employee/{account}")]
        public IActionResult DeleteEmployee(String account)
        {
            var result = employeeSvc.DeleteEmployee(account);
            return Ok(result);
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginReq req)
        {
            IActionResult response = Unauthorized();
            var user = employeeSvc.ValidateEmployee(req);
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
                    pass = "",
                });
            }
            return response;
        }
    }
}
