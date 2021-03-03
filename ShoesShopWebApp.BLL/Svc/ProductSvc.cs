using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoesShopWebApp.BLL.Svc
{
    public class ProductSvc
    {
        private readonly ProductRep productRep;
        public ProductSvc()
        {
            productRep = new ProductRep();
        }


        public object CreateProduct(ProductReq req)
        {
            Product product = new Product();
            product.ProductID = req.ProductID;
            product.ProductName = req.ProductName;
            product.Price = req.Price;
            product.BrandID = req.BrandID;
            product.CategoryID = req.CategoryID;
            product.CreateDate = req.CreateDate;
            product.Unit = req.Unit;
            product.UnitsInStock = req.UnitsInStock;
            product.Discount = req.Discount;
            product.Description = req.Description;
            product.Picture = req.Picture;
            product.Description = req.Note;
            return productRep.Create(product);
        }


        public object UpdateProduct(String id, ProductReq req)
        {
            return productRep.Update(id ,req);
        }


        public object UpdateUnitInStock(String id, UpdateUnitInStockReq req)
        {
            return productRep.UpdateUnitInStock(id, req);
        }


        public object SearchProduct(int size, int page, String keyword)
        {
            var result = productRep.SearchAllProduct(size, page, keyword);
            return result;
        }


        public object GetProductByBrand(int size, int page, String brandID)
        {
            var result = productRep.GetProductByBrand(size, page, brandID);
            return result;
        }


        public object GetProductByCategory(int size, int page, String categoruID)
        {
            var result = productRep.GetProductByCategory(size, page, categoruID);
            return result;
        }


        public object FilterProduct(int size, int page, int price, String brand, String category)
        {
            var result = productRep.FilterProduct(size, page, price, brand, category);
            return result;
        }


        public object DeleteProduct(String id)
        {
            return productRep.Delete(id);
        }
    }
}
