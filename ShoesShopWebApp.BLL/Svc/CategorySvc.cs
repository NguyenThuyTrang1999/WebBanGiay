using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;

namespace ShoesShopWebApp.BLL.Svc
{
    public class CategorySvc
    {
        private readonly CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }


        public object CreateCategory(CategoryReq req)
        {
            Category category = new Category();
            category.CategoryID = req.CategoryID;
            category.CategoryName = req.CategoryName;
            category.CreateDay = req.CreateDay;
            category.Description = req.Description;
            category.Note = req.Note;
            return categoryRep.Create(category);
        }


        public object UpdateCategory(String id, CategoryReq req)
        {
            return categoryRep.Update(id, req);
        }


        public object SearchCategory(int size, int page, String keyword)
        {
            var allValues = categoryRep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                allValues = categoryRep.All.Where(value => value.CategoryID.Contains(keyword) || value.CategoryName.Contains(keyword));
            }
            int offset = (page - 1) * size;
            int total = allValues.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = allValues.Skip(offset).Take(size).ToList();
            var result = new
            {
                Data = data,
                totalRecord = total,
                Page = page,
                Size = size,
                TotalPage = totalPage
            };
            return result;
        }


        public object DeleteCategory(String id)
        {
            return categoryRep.Delete(id);
        }
    }
}
