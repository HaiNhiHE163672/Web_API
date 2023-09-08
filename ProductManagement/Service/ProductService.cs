//using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
//using MimeKit;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using System.Net;
using System.Net.Mail;

namespace ProductManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext DbContext;
        public ProductService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public Product AddProduct(Product product)
        {
            product.Create_at = DateTime.Now;    
            var images = product.Product_Images;
            product.Product_Images = null;
            var reviews = product.Product_Reviews;
            product.Product_Reviews = null;
            DbContext.Add(product);
            DbContext.SaveChanges();
            foreach(var image in images)
            {
                image.ProductId = product.ProductId;
                image.Created_at = DateTime.Now;
                DbContext.Add(image);
                DbContext.SaveChanges();
            }
            return product;
        }

        public string DeleteProduct(int id)
        {
            
            if(DbContext.products.Any(x => x.ProductId == id))
            {
                var product = DbContext.products.Find(id);
                DbContext.Remove(product);
                DbContext.SaveChanges();
                var reviews = DbContext.product_Reviews.Where(x => x.ProductId == id);
                DbContext.RemoveRange(reviews);
                DbContext.SaveChanges() ;
                var images = DbContext.product_Images.Where(x => x.ProductId == id);
                DbContext.RemoveRange(images);
                DbContext.SaveChanges();
                //var orderdetails = DbContext.orders_detail.Where(x => x.ProductId == id);
                //DbContext.RemoveRange(orderdetails);
                //DbContext.SaveChanges();
                //var orders = DbContext.orders.Include(x => x.Order_Details).ToList();
                //foreach(var order in orders)
                //{
                //    double actual = 0;
                //    foreach (var detail in order.Order_Details)
                //    {
                //        if (DbContext.products.Any(x => x.ProductId == detail.ProductId))
                //        {
                //            detail.OrderId = order.OrderId;
                //            var p = DbContext.products.FirstOrDefault(x => x.ProductId == detail.ProductId);
                //            actual += detail.Price_total - detail.Price_total * p.Discount / 100;
                //        }
                //        else
                //        {
                //            throw new Exception("Product not exist!");
                //        }
                //    }
                //    order.Orginal_Price = DbContext.orders_detail.Where(x => x.OrderId == order.OrderId).Sum(x => x.Price_total);
                //    order.Actual_Price = actual;
                //    DbContext.Update(order);
                //    DbContext.SaveChanges();
                //}
                return "Delete 1 product successfull";
            }
            else
            {
                return "Product not exist!";
            }
        }

        public PageResult<Product> GetAll(Pagination pagination)
        {
            var list =  DbContext.products.Include(x => x.Product_Images).ToList();
            var res = PageResult<Product>.ToPageResult(pagination, list);
            pagination.TotalCount = list.Count();
            return new PageResult<Product>(pagination, res);
        }

        public Product GetProductById(int id)
        {
            if(DbContext.products.Any(x => x.ProductId == id))
            {
                var product = DbContext.products.Include(x => x.Product_Images).Include(x => x.Product_Reviews).FirstOrDefault(x => x.ProductId == id);
                product.number_of_views += 1;
                DbContext.Update(product);
                DbContext.SaveChanges();
                return product;
            }
            else
            {
                throw new Exception("Product not exist!");
            }
        }


        public Product UpdateProduct(int id, Product product)
        {
            if (DbContext.products.Any(x => x.ProductId == id))
            {
                var prod = DbContext.product_Images.Where(x => x.ProductId == id).ToList();
                if (prod == null || prod.Count() == 0)
                {
                    var image = DbContext.products.Where(x => x.ProductId == id).ToList();
                    DbContext.RemoveRange(image);
                    DbContext.SaveChanges();
                }
                else
                {
                    var listHT = DbContext.product_Images.Where(x => x.ProductId == id).ToList();
                    var listDel = new List<Product_image>();
                    foreach(var image in listHT)
                    {
                        if(!product.Product_Images.Any(x => x.Product_ImageId == image.Product_ImageId))
                        {

                            listDel.Add(image);
                        }
                        else
                        {
                            var NewImage = product.Product_Images.FirstOrDefault(x => x.Product_ImageId == image.Product_ImageId);
                            image.Title = NewImage.Title;
                            image.Image_product = NewImage.Image_product;
                            image.Status = NewImage.Status;
                            image.ProductId = id;
                            image.Updated_at = DateTime.Now;
                            DbContext.Update(image);
                            DbContext.SaveChanges();
                        }
                    }
                    DbContext.RemoveRange(listDel); 
                    DbContext.SaveChanges();
                    foreach(var image in product.Product_Images)
                    {
                        if(!listHT.Any(x => x.Product_ImageId == image.Product_ImageId))
                        {
                            image.ProductId = id;
                            image.Created_at = DateTime.Now;
                            DbContext.Add(image);
                            DbContext.SaveChanges();
                        }
                    }
                }
                //var details = DbContext.orders_detail.Where(x => x.ProductId == id).ToList();
                //double actual = 0;
                //foreach (var detail in details)
                //{
                //    detail.Price_total = detail.Quantity * product.Price;
                //    actual += detail.Price_total - detail.Price_total * product.Discount / 100;
                //    DbContext.Update(detail);
                //    DbContext.SaveChanges();
                //}
                //var orders = details.Select(x => x.OrderId).ToList();
                //foreach (var o in orders)
                //{
                //    var order = DbContext.orders.Find(o);
                //    order.Orginal_Price = DbContext.orders_detail.Where(x => x.OrderId == o).Sum(x => x.Price_total);
                //    order.Actual_Price = actual;
                //    order.Updated_at = DateTime.Now;
                //    DbContext.Update(order);
                //    DbContext.SaveChanges();
                //}
                var p = DbContext.products.Include(x => x.Product_Images).FirstOrDefault(x => x.ProductId == id);
                p.Name_product = product.Name_product;
                p.Price = product.Price;
                p.Quantity = product.Quantity;
                p.Avartar_image_product = product.Avartar_image_product;
                p.Discount = product.Discount;
                p.Title = product.Title;
                p.Status = product.Status;
                p.Update_at = DateTime.Now;
                DbContext.products.Update(p);
                DbContext.SaveChanges();
                return p;
            }
            else
            {
                throw new Exception("Product not exist!");
            }
        }
    }
}
