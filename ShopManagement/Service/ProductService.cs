using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopManagement.Interface;
using ShopManagement.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ShopManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext DbContext;
        public ProductService()
        {
            DbContext = new AppDbContext();
        }

        public string CapNhatSoLuong(int id, int sl, int tt1, int? tt2 = null, int? tt3 = null)
        {
            if (DbContext.Products.Any(x => x.ProductId == id))
            {
                //var thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailCode.Contains(tt1) || x.PropertyDetailCode.Contains(tt2) || x.PropertyDetailCode.Contains(tt3)).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                var thuoctinh = DbContext.PropertyDetails.Select(x => x.PropertyDetailDetail).ToList();
                if (tt2 == null && tt3 == null)
                {

                    if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt1))
                    {
                        return $"Không tồn tại thuộc tính id {tt1}";
                    }
                    else
                    {
                        thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailId == tt1).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                    }
                }
                else if (tt3 == null)
                {

                    if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt1))
                    {
                        return $"Không tồn tại thuộc tính id {tt1}";
                    }
                    else if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt2))
                    {
                        return $"Không tồn tại thuộc tính id {tt2}";
                    }
                    else
                    {
                        thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailId == tt1 || x.PropertyDetailId == tt2).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                    }
                }
                else
                {

                    if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt1))
                    {
                        return $"Không tồn tại thuộc tính id {tt1}";
                    }
                    else if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt2))
                    {
                        return $"Không tồn tại thuộc tính id {tt2}";
                    }
                    else if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt3))
                    {
                        return $"Không tồn tại thuộc tính id {tt3}";
                    }
                    else
                    {
                        thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailId == tt1 || x.PropertyDetailId == tt2 || x.PropertyDetailId == tt3).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                    }
                }

                string a = "";
                for (int i = thuoctinh.Count - 1; i >= 0; i--)
                {
                    if (i != 0)
                    {
                        a += thuoctinh[i] + " ";
                    }
                    else
                    {
                        a += thuoctinh[i];
                    }

                }
                var sp = DbContext.ProductDetails.FirstOrDefault(x => x.ProductDetailName.Contains(a) && x.ProductDetailPropertyDetails.Any(x => x.ProductId == id && (x.PropertyDetail.PropertyDetailId == tt1 || x.PropertyDetail.PropertyDetailId == tt2 || x.PropertyDetail.PropertyDetailId == tt3)));
                if (!DbContext.ProductDetails.Include(x => x.ProductDetailPropertyDetails).Any(x => x.ProductDetailPropertyDetails.Any(x => x.ProductId == id && (x.PropertyDetail.PropertyDetailId == tt1 || x.PropertyDetail.PropertyDetailId == tt2 || x.PropertyDetail.PropertyDetailId == tt3))))
                {
                    return "Sản phẩm không tồn tại. Vui lòng kiểm tra lại thuộc tính!";
                }
                else
                {
                    var DoiThuocTinh = DbContext.ProductDetails.ToList();
                        int cn = sl - sp.Quantity;
                        sp.Quantity = sl;
                        DoiThuocTinh.Add(sp);
                        if (sp.ParentId != null)
                        {
                            var cha1 = DbContext.ProductDetails.Find(sp.ParentId);
                            cha1.Quantity += cn;
                            DoiThuocTinh.Add(cha1);
                            if (cha1.ParentId != null)
                            {
                                var cha2 = DbContext.ProductDetails.Find(cha1.ParentId);
                                cha2.Quantity -= cn;
                                DoiThuocTinh.Add(cha2);
                            }
                        }
                        DbContext.UpdateRange(DoiThuocTinh);
                        DbContext.SaveChanges();
                        return $"Cập nhật {sl} {sp.ProductDetailName} thành công!";
                }


            }
            else
            {
                return "Sản phẩm không tồn tại. Vui lòng kiểm tra lại tên sản phẩm!";
            }
            return null;
        }
        public PageResult<ProductDetail> DsSanPham(Pagination pagination)
        {
            var list = DbContext.ProductDetailPropertyDetails.Select(x => x.ProductDetailId).Distinct().ToList();
            var ChiTiet = new List<ProductDetail>();
            foreach(var item in list)
            {
               var ct =  DbContext.ProductDetails.FirstOrDefault(x => x.ProductDetailId == item);
                ChiTiet.Add(ct);
            }
            var res = PageResult<ProductDetail>.ToPageResult(pagination, ChiTiet);
            pagination.TotalCount = ChiTiet.Count();
            return new PageResult<ProductDetail>(pagination, res);

        }

        public string MuaSanPham(int id, int sl, int tt1, int? tt2 = null, int? tt3 = null)
        {

            if (DbContext.Products.Any(x => x.ProductId == id))
            {
                //var thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailCode.Contains(tt1) || x.PropertyDetailCode.Contains(tt2) || x.PropertyDetailCode.Contains(tt3)).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                var thuoctinh = DbContext.PropertyDetails.Select(x => x.PropertyDetailDetail).ToList();
                if (tt2 == null && tt3 == null)
                {

                    if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt1))
                    {
                        return $"Không tồn tại thuộc tính id {tt1}";
                    }
                    else
                    {
                        thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailId == tt1).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                    }
                }
                else if (tt3 == null)
                {

                    if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt1))
                    {
                        return $"Không tồn tại thuộc tính id {tt1}";
                    }
                    else if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt2))
                    {
                        return $"Không tồn tại thuộc tính id {tt2}";
                    }
                    else
                    {
                        thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailId == tt1 || x.PropertyDetailId == tt2).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                    }
                }
                else
                {

                    if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt1))
                    {
                        return $"Không tồn tại thuộc tính id {tt1}";
                    }
                    else if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt2))
                    {
                        return $"Không tồn tại thuộc tính id {tt2}";
                    }
                    else if (!DbContext.PropertyDetails.Any(x => x.PropertyDetailId == tt3))
                    {
                        return $"Không tồn tại thuộc tính id {tt3}";
                    }
                    else
                    {
                        thuoctinh = DbContext.PropertyDetails.Where(x => x.PropertyDetailId == tt1 || x.PropertyDetailId == tt2 || x.PropertyDetailId == tt3).Select(x => x.PropertyDetailDetail).Distinct().ToList();
                    }
                }

                string a = "";
                for (int i = thuoctinh.Count - 1; i >= 0; i--)
                {
                    if (i != 0)
                    {
                        a += thuoctinh[i] + " ";
                    }
                    else
                    {
                        a += thuoctinh[i];
                    }

                }
                var sp = DbContext.ProductDetails.FirstOrDefault(x => x.ProductDetailName.Contains(a) && x.ProductDetailPropertyDetails.Any(x => x.ProductId == id && (x.PropertyDetail.PropertyDetailId == tt1 || x.PropertyDetail.PropertyDetailId == tt2 || x.PropertyDetail.PropertyDetailId == tt3)));
                if(!DbContext.ProductDetails.Include(x => x.ProductDetailPropertyDetails).Any(x => x.ProductDetailPropertyDetails.Any(x => x.ProductId == id && (x.PropertyDetail.PropertyDetailId == tt1 || x.PropertyDetail.PropertyDetailId == tt2 || x.PropertyDetail.PropertyDetailId == tt3))))
                {
                    return "Sản phẩm không tồn tại. Vui lòng kiểm tra lại thuộc tính!";
                }
                else
                {
                    var DoiThuocTinh = DbContext.ProductDetails.ToList();
                    if (sp.Quantity == 0)
                    {
                        return $"{sp.ProductDetailName} hết hàng\n";
                    }
                    else if (sl <= 0)
                    {
                        return $"Nhập số lượng {sp.ProductDetailName} cần mua phải lớn hơn 0\n";
                    }
                    else if (sp.Quantity < sl)
                    {
                        return $"{sp.ProductDetailName} không đủ số lượng\n";
                    }
                    else
                    {
                        sp.Quantity -= sl;
                        DoiThuocTinh.Add(sp);
                        if(sp.ParentId != null)
                        {
                            var cha1 = DbContext.ProductDetails.Find(sp.ParentId);
                            cha1.Quantity -= sl;
                            DoiThuocTinh.Add(cha1);
                            if(cha1.ParentId != null)
                            {
                                var cha2 = DbContext.ProductDetails.Find(cha1.ParentId);
                                cha2.Quantity -= sl;
                                DoiThuocTinh.Add(cha2);
                            }
                        }
                        DbContext.UpdateRange(DoiThuocTinh);
                        DbContext.SaveChanges();
                        double gia = sl * sp.Price;
                        return $"Mua {sl} {sp.ProductDetailName} thành công! Vui lòng trả {gia} khi nhận hàng\n";


                    }
                }
                

            }
            else
            {
                return "Sản phẩm không tồn tại. Vui lòng kiểm tra lại tên sản phẩm!";
            }
            return null;
        }


    }
}
