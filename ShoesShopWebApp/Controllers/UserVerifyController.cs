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
    public class UserVerifyController : ControllerBase
    {
        private readonly UserVerifySvc userVerifySvc;
        public UserVerifyController()
        {
            userVerifySvc = new UserVerifySvc();
        }

        [HttpGet("Search_User/{account},{pass}")]
        public IActionResult SearchUser(String account, String pass)
        {
            var result = userVerifySvc.SearchUser(account, pass);
            return Ok(result);
        }
    }
}
