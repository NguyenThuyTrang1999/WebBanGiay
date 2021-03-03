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
    public class CategoryController : ControllerBase
    {
        private readonly CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }

        [HttpPost("Create_Category")]
        public IActionResult CreateCategory(CategoryReq req)
        {
            var result = categorySvc.CreateCategory(req);
            return Ok(result);
        }


        [HttpGet("Search_Category/{size},{page}")]
        public IActionResult SearchCategory(int size, int page, String keyword)
        {
            var result = categorySvc.SearchCategory(size, page, keyword);
            return Ok(result);
        }


        [HttpPut("Update_Category/{id}")]
        public IActionResult UpdateCategory(String id, CategoryReq req)
        {
            var result = categorySvc.UpdateCategory(id, req);
            return Ok(result);
        }


        [HttpDelete("Delete_Category/{id}")]
        public IActionResult DeleteCategory(String id)
        {
            var result = categorySvc.DeleteCategory(id);
            return Ok(result);
        }
    }
}
