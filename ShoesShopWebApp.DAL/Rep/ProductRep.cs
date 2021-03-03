using ShoesShopWebApp.Common.Req;
using System;
using System.Collections.Generic;
using System.Text;
using ShoesShopWebApp.DAL.Model;
using System.Linq;

namespace ShoesShopWebApp.DAL.Rep
{
    public class ProductRep
    {
        private Context context;


        public ProductRep()
        {
            context = new Context();
        }


        public object Create(Product product)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Product.Add(product);
                    context.SaveChanges();
                    tran.Commit();
                    return product;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }
        }


        public object Update(String id, ProductReq req)
        {
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    var result = context.Product.FirstOrDefault(value => value.ProductID == id);
                    if (result != null)
                    {
                        result.ProductName = req.ProductName;
                        result.Price = req.Price;
                        result.BrandID = req.BrandID;
                        result.CategoryID = req.CategoryID;
                        result.CreateDate = req.CreateDate;
                        result.Unit = req.Unit;
                        result.UnitsInStock = req.UnitsInStock;
                        result.Discount = req.Discount;
                        result.Description = req.Description;
                        result.Picture = req.Picture;
                        result.Description = req.Note;
                        context.Product.Update(result);
                        context.SaveChanges();
                        tran.Commit();
                        return result;
                    }
                    else
                    {
                        return "Unable to update: not found ID.";
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace;
                }
            }
        }


        public object UpdateUnitInStock(String id, UpdateUnitInStockReq req)
        {
            try
            {
                var result = context.Product.FirstOrDefault(value => value.ProductID == id);
                if (result != null)
                {
                    result.UnitsInStock = req.UnitsInStock;
                    context.Product.Update(result);
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


        public object Delete (String id)
        {
            var result = context.Product.FirstOrDefault(value => value.ProductID == id);
            try
            {
                if (result != null)
                {
                    context.Product.Remove(result);
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


        public object GetProductByBrand(int size, int page, String brandID)
        {
            var products = context.Product.Where(p => p.BrandID == brandID)
               .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
               {
                   p.ProductID,
                   p.ProductName,
                   p.Price,
                   p.BrandID,
                   p.CategoryID,
                   p.CreateDate,
                   p.Unit,
                   p.UnitsInStock,
                   p.Discount,
                   p.Description,
                   p.Picture,
                   p.Note,
                   b.BrandName
               }).ToArray();
            int offset = (page - 1) * size;
            int total = products.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = products.Skip(offset).Take(size).ToList();
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


        public object GetProductByCategory(int size, int page, String categoryID)
        {
            var products = context.Product.Where(p => p.CategoryID == categoryID)
               .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
               {
                   p.ProductID,
                   p.ProductName,
                   p.Price,
                   p.BrandID,
                   p.CategoryID,
                   p.CreateDate,
                   p.Unit,
                   p.UnitsInStock,
                   p.Discount,
                   p.Description,
                   p.Picture,
                   p.Note,
                   b.BrandName
               }).Join(context.Category, p => p.CategoryID, c => c.CategoryID, (p, c) => new
               {
                   p.ProductID,
                   p.ProductName,
                   p.Price,
                   p.BrandID,
                   p.CategoryID,
                   p.CreateDate,
                   p.Unit,
                   p.UnitsInStock,
                   p.Discount,
                   p.Description,
                   p.Picture,
                   p.Note,
                   p.BrandName,
                   c.CategoryName
               }).ToArray();
            int offset = (page - 1) * size;
            int total = products.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = products.Skip(offset).Take(size).ToList();
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


        public object SearchAllProduct(int size, int page, String keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                var products = context.Product.Where(p => p.ProductID == keyword || p.ProductName == keyword)
                .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                    {
                        p.ProductID,
                        p.ProductName,
                        p.Price,
                        p.BrandID,
                        p.CategoryID,
                        p.CreateDate,
                        p.Unit,
                        p.UnitsInStock,
                        p.Discount,
                        p.Description,
                        p.Picture,
                        p.Note,
                        b.BrandName
                    }).ToArray();
                if (products.Count() == 0)
                {
                    products = context.Product.Where(p => p.ProductID.Contains(keyword) || p.ProductName.Contains(keyword))
                    .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                       {
                           p.ProductID,
                           p.ProductName,
                           p.Price,
                           p.BrandID,
                           p.CategoryID,
                           p.CreateDate,
                           p.Unit,
                           p.UnitsInStock,
                           p.Discount,
                           p.Description,
                           p.Picture,
                           p.Note,
                           b.BrandName
                       }).ToArray();
                }
                int offset = (page - 1) * size;
                int total = products.Count();
                int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                var data = products.Skip(offset).Take(size).ToList();
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
            else
            {
                var products = context.Product.Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.Price,
                    p.BrandID,
                    p.CategoryID,
                    p.CreateDate,
                    p.Unit,
                    p.UnitsInStock,
                    p.Discount,
                    p.Description,
                    p.Picture,
                    p.Note,
                    b.BrandName
                }).ToArray();
                int offset = (page - 1) * size;
                int total = products.Count();
                int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                var data = products.Skip(offset).Take(size).ToList();
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
        }


        public object FilterProduct(int size, int page, int price, String brand, String category)
        {
            if (price != 0)
            {
                if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(category))
                {
                    var products = context.Product.Where(p => p.Price <= price && p.BrandID == brand && p.CategoryID == category)
                        .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Price,
                            p.BrandID,
                            p.CategoryID,
                            p.CreateDate,
                            p.Unit,
                            p.UnitsInStock,
                            p.Discount,
                            p.Description,
                            p.Picture,
                            p.Note,
                            b.BrandName
                        }).ToArray();
                    int offset = (page - 1) * size;
                    int total = products.Count();
                    int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                    var data = products.Skip(offset).Take(size).ToList();
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
                else
                {
                    if (string.IsNullOrEmpty(brand) && string.IsNullOrEmpty(category))
                    {
                        var products = context.Product.Where(p => p.Price <= price)
                        .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Price,
                            p.BrandID,
                            p.CategoryID,
                            p.CreateDate,
                            p.Unit,
                            p.UnitsInStock,
                            p.Discount,
                            p.Description,
                            p.Picture,
                            p.Note,
                            b.BrandName
                        }).ToArray();
                        int offset = (page - 1) * size;
                        int total = products.Count();
                        int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                        var data = products.Skip(offset).Take(size).ToList();
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
                    else
                    {
                        if (!string.IsNullOrEmpty(brand) && string.IsNullOrEmpty(category))
                        {
                            var products = context.Product.Where(p => p.Price <= price && p.BrandID == brand)
                            .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Price,
                                p.BrandID,
                                p.CategoryID,
                                p.CreateDate,
                                p.Unit,
                                p.UnitsInStock,
                                p.Discount,
                                p.Description,
                                p.Picture,
                                p.Note,
                                b.BrandName
                            }).ToArray();
                            int offset = (page - 1) * size;
                            int total = products.Count();
                            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                            var data = products.Skip(offset).Take(size).ToList();
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
                        else
                        {
                            var products = context.Product.Where(p => p.Price <= price && p.CategoryID == category)
                            .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Price,
                                p.BrandID,
                                p.CategoryID,
                                p.CreateDate,
                                p.Unit,
                                p.UnitsInStock,
                                p.Discount,
                                p.Description,
                                p.Picture,
                                p.Note,
                                b.BrandName
                            }).ToArray();
                            int offset = (page - 1) * size;
                            int total = products.Count();
                            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                            var data = products.Skip(offset).Take(size).ToList();
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
                    }
                    
                }
            }
            else
            {
                if (string.IsNullOrEmpty(brand) && string.IsNullOrEmpty(category))
                {
                    var products = context.Product
                    .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                    {
                        p.ProductID,
                        p.ProductName,
                        p.Price,
                        p.BrandID,
                        p.CategoryID,
                        p.CreateDate,
                        p.Unit,
                        p.UnitsInStock,
                        p.Discount,
                        p.Description,
                        p.Picture,
                        p.Note,
                        b.BrandName
                    }).ToArray();
                    int offset = (page - 1) * size;
                    int total = products.Count();
                    int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                    var data = products.Skip(offset).Take(size).ToList();
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
                else
                {
                    if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(category))
                    {
                        var products = context.Product.Where(p => p.BrandID == brand && p.CategoryID == category)
                        .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Price,
                            p.BrandID,
                            p.CategoryID,
                            p.CreateDate,
                            p.Unit,
                            p.UnitsInStock,
                            p.Discount,
                            p.Description,
                            p.Picture,
                            p.Note,
                            b.BrandName
                        }).ToArray();
                        int offset = (page - 1) * size;
                        int total = products.Count();
                        int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                        var data = products.Skip(offset).Take(size).ToList();
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
                    else
                    {
                        if (!string.IsNullOrEmpty(brand) && string.IsNullOrEmpty(category))
                        {
                            var products = context.Product.Where(p => p.BrandID == brand)
                            .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Price,
                                p.BrandID,
                                p.CategoryID,
                                p.CreateDate,
                                p.Unit,
                                p.UnitsInStock,
                                p.Discount,
                                p.Description,
                                p.Picture,
                                p.Note,
                                b.BrandName
                            }).ToArray();
                            int offset = (page - 1) * size;
                            int total = products.Count();
                            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                            var data = products.Skip(offset).Take(size).ToList();
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
                        else
                        {
                            var products = context.Product.Where(p => p.CategoryID == category)
                            .Join(context.Brand, p => p.BrandID, b => b.BrandID, (p, b) => new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Price,
                                p.BrandID,
                                p.CategoryID,
                                p.CreateDate,
                                p.Unit,
                                p.UnitsInStock,
                                p.Discount,
                                p.Description,
                                p.Picture,
                                p.Note,
                                b.BrandName
                            }).ToArray();
                            int offset = (page - 1) * size;
                            int total = products.Count();
                            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
                            var data = products.Skip(offset).Take(size).ToList();
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
                    }
                }
            }
        }
    }
}
