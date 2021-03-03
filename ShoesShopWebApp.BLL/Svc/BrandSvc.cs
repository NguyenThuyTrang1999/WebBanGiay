using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;

namespace ShoesShopWebApp.BLL.Svc
{
    public class BrandSvc
    {
        private readonly BrandRep brandRep;
        public BrandSvc()
        {
            brandRep = new BrandRep();
        }


        public object CreateBrand(BrandReq req)
        {
            Brand brand = new Brand();
            brand.BrandID = req.BrandID;
            brand.BrandName = req.BrandName;
            brand.CreateDay = req.CreateDay;
            brand.Description = req.Description;
            brand.Picture = req.Picture;
            brand.Note = req.Note;
            return brandRep.Create(brand);
        }


        public object UpdateBrand(String id, BrandReq req)
        {
            return brandRep.Update(id, req);
        }


        public object SearchBrand(int size, int page, String keyword)
        {
            var allValues = brandRep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                allValues = brandRep.All.Where(value => value.BrandID == keyword || value.BrandName == keyword);
                if (allValues.Count() == 0)
                {
                    allValues = brandRep.All.Where(value => value.BrandID.Contains(keyword) || value.BrandName.Contains(keyword));
                }
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


        public object DeleteBrand(String id)
        {
            return brandRep.Delete(id);
        }
    }
}
