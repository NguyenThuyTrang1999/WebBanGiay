using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.DAL.Rep
{
    public class CategoryRep
    {
        private Context context;


        public CategoryRep()
        {
            context = new Context();
        }


        public object Create(Category category)
        {
            try
            {
                context.Category.Add(category);
                context.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Update(String id, CategoryReq req)
        {
            try
            {
                var result = context.Category.FirstOrDefault(value => value.CategoryID == id);
                if (result != null)
                {
                    result.CategoryID = req.CategoryID;
                    result.CategoryName = req.CategoryName;
                    result.CreateDay = req.CreateDay;
                    result.Description = req.Description;
                    result.Note = req.Note;
                    context.Category.Update(result);
                    context.SaveChanges();
                    return result;
                }
                else
                {
                    return "Unable to update: not found ID.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Delete(String id)
        {
            var result = context.Category.FirstOrDefault(value => value.CategoryID == id);
            try
            {
                if (result != null)
                {
                    context.Category.Remove(result);
                    context.SaveChanges();
                    return result;
                }
                else
                {
                    return "Unable to delete: not found ID.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public IQueryable<Category> All
        {
            get
            {
                IQueryable<Category> result = context.Category;
                return result;
            }
        }
    }
}
