using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.DAL.Rep
{
    public class BrandRep
    {
        private Context context;


        public BrandRep()
        {
            context = new Context();
        }


        public object Create(Brand brand)
        {
            try
            {
                context.Brand.Add(brand);
                context.SaveChanges();
                return brand;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Update(String id, BrandReq req)
        {
            try
            {
                var result = context.Brand.FirstOrDefault(value => value.BrandID == id);
                if (result != null)
                {
                    result.BrandID = req.BrandID;
                    result.BrandName = req.BrandName;
                    result.CreateDay = req.CreateDay;
                    result.Description = req.Description;
                    result.Picture = req.Picture;
                    result.Note = req.Note;
                    context.Brand.Update(result);
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
            var result = context.Brand.FirstOrDefault(value => value.BrandID == id);
            try
            {
                if (result != null)
                {
                    context.Brand.Remove(result);
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


        public IQueryable<Brand> All
        {
            get
            {
                IQueryable<Brand> result = context.Brand;
                return result;
            }
        }
    }
}
