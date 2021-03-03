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
    public class ProductController : ControllerBase
    {
        private readonly ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        [HttpPost("Create_Product")]
        public IActionResult CreateProduct(ProductReq req)
        {
            var result = productSvc.CreateProduct(req);
            return Ok(result);
        }


        [HttpGet("Search_Product/{size},{page}")]
        public IActionResult SearchProduct(int size, int page, String keyword)
        {
            var result = productSvc.SearchProduct(size, page, keyword);
            return Ok(result);
        }


        [HttpGet("Get_Product_By_Brand/{size},{page}")]
        public IActionResult GetProductByBrand(int size, int page, String brandID)
        {
            var result = productSvc.GetProductByBrand(size, page, brandID);
            return Ok(result);
        }


        [HttpGet("Get_Product_By_Category/{size},{page}")]
        public IActionResult GetProductByCategory(int size, int page, String categoryID)
        {
            var result = productSvc.GetProductByCategory(size, page, categoryID);
            return Ok(result);
        }


        [HttpGet("Filter_Product/{size},{page}")]
        public IActionResult FilterProduct(int size, int page, int price, String brand, String category)
        {
            var result = productSvc.FilterProduct(size, page, price, brand, category);
            return Ok(result);
        }


        [HttpPut("Update_Product/{id}")]
        public IActionResult UpdateProduct(String id, ProductReq req)
        {
            var result = productSvc.UpdateProduct(id, req);
            return Ok(result);
        }


        [HttpPut("Update_Unit_In_Stock/{id}")]
        public IActionResult UpdateUnitInStock(String id, UpdateUnitInStockReq req)
        {
            var result = productSvc.UpdateUnitInStock(id, req);
            return Ok(result);
        }


        [HttpDelete("Delete_Product/{id}")]
        public IActionResult DeleteProduct(String id)
        {
            var result = productSvc.DeleteProduct(id);
            return Ok(result);
        }
    }
}
