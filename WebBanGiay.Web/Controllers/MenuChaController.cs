using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using WebBanGiay.BLL;

namespace WebBanGiay.Web.Controllers
{
    using BLL;
    [Route("api/[controller]")]
    [ApiController]
    public class MenuChaController : ControllerBase
    {
       
        public MenuChaController()
        {
            _svc = new MenuChaSvc();
        }
    }
}