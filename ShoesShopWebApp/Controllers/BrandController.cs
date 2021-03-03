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
    public class BrandController : ControllerBase
    {
        private readonly BrandSvc brandSvc;
        public BrandController()
        {
            brandSvc = new BrandSvc();
        }

        [HttpPost("Create_Brand")]
        public IActionResult CreateBrand(BrandReq req)
        {
            var result = brandSvc.CreateBrand(req);
            return Ok(result);
        }


        [HttpGet("Search_Brand/{size},{page}")]
        public IActionResult SearchBrand(int size, int page, String keyword)
        {
            var result = brandSvc.SearchBrand(size, page, keyword);
            return Ok(result);
        }


        [HttpPut("Update_Brand/{id}")]
        public IActionResult UpdateBrand(String id, BrandReq req)
        {
            var result = brandSvc.UpdateBrand(id, req);
            return Ok(result);
        }


        [HttpDelete("Delete_Brand/{id}")]
        public IActionResult DeleteBrand(String id)
        {
            var result = brandSvc.DeleteBrand(id);
            return Ok(result);
        }
    }
}
