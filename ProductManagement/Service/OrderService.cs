using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Helper;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using ProductManagement.PaymentOnline.MoMo;

namespace ProductManagement.Service
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext DbContext;
        public OrderService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public string AddOrder(Order order)
        {
            double actual = 0;
            int sum = 0;
            order.Created_at = DateTime.Now;
            var user = DbContext.users.FirstOrDefault(x => x.UserId == order.UserId);
            order.Full_name = user.User_name;
            order.Address = user.Address;
            order.Phone = user.Phone;
            order.Email = user.Email;
            order.PaymentId = order.PaymentId == 1 ? order.Order_StatusId = 1 : order.Order_StatusId = 2;
            var details = order.Order_Details;
            order.Order_Details = null;
            DbContext.orders.Add(order);
            DbContext.SaveChanges();
            foreach(var detail in details)
            {
                if (DbContext.products.Any(x => x.ProductId == detail.ProductId))
                {
                    detail.OrderId = order.OrderId;
                    var product = DbContext.products.FirstOrDefault(x => x.ProductId == detail.ProductId);
                    detail.Price_total = product.Price * detail.Quantity;
                    detail.Created_at = DateTime.Now;
                    DbContext.orders_detail.Add(detail);
                    DbContext.SaveChanges();
                    actual += detail.Price_total - detail.Price_total * product.Discount / 100;
                    product.Quantity -= detail.Quantity;
                    DbContext.Update(product);
                    DbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Product not exist!");
                }
            }
            

            order.Orginal_Price = details.Sum(x => x.Price_total);
            order.Actual_Price = actual;
            DbContext.Update(order);
            DbContext.SaveChanges();

            // gui mail cho khach hang
            //SendMail.Address = "nguyenthihainhi512@gmail.com";
            //SendMail.Password = "nhinguyen125";
            //SendMail email = new SendMail();
            if (order.PaymentId == 1)
            {
                string contentCustomer = "Đơn hàng của bạn đã được tạo. Vui lòng chờ người bán xác nhận!";
                SendMail(contentCustomer, order.Email);
                return "Đặt hàng thành công";
            }
            else
            {
                string contentCustomer = "Đơn hàng của bạn đã được tạo. Vui lòng chờ người bán chuẩn bị hàng!";
                SendMail(contentCustomer, order.Email);
                return PayMomo(order.OrderId);
            }

            
            
        }
        private bool SendMail(string body, string to)
        {
            string from = "youremail"; // Email của người gửi
            string pw = "yourapppassword"; // App password của người gửi
            MailMessage email = new MailMessage();
            email.From = new MailAddress(from);
            email.Subject = "Cảm ơn bạn đã đặt sản phẩm";
            email.Body = body;
            email.To.Add(new MailAddress(to));
            email.IsBodyHtml = true;
            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(from, pw),
                EnableSsl = true,
            };
            smtp.Send(email);
            return true;

        }
        private string PayMomo(int id)
        {
            var bill = DbContext.orders.FirstOrDefault(x => x.OrderId == id);
            var mon = bill.Actual_Price;



            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOV2NN20220607";
            string accessKey = "zanxjP13gFbJCX2t";
            string serectkey = "slOO415FigGnrQzZQkk02qWcdCUFkbH2";
            string orderInfo = "test";
            string returnUrl = $"https://localhost:7225/api/addorder";
            string notifyurl = "https://momo.vn/notify";// notifyurl không được sử dụng localhost
            string amount = mon + "";
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet"},
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return jmessage.GetValue("payUrl").ToString();
        }

        public string DeleteOrder(int id)
        {
            if(DbContext.orders.Any(x => x.OrderId == id))
            {
                var order = DbContext.orders.Find(id);
                DbContext.Remove(order);
                DbContext.SaveChanges();
                var detail = DbContext.orders_detail.Where(x => x.OrderId == id);
                DbContext.RemoveRange(detail);
                DbContext.SaveChanges();
                return "Delete 1 Order successfull";
            }
            else
            {
                return "Order not exist!";
            }
        }

        public PageResult<Order> GetAllOrder(Pagination pagination)
        {
            var list =  DbContext.orders.Include(x => x.Order_Details).ToList();
            var res = PageResult<Order>.ToPageResult(pagination, list);
            pagination.TotalCount = list.Count();
            return new PageResult<Order>(pagination, res);
        }

        public Order GetOrderById(int id)
        {
            if(DbContext.orders.Any(x => x.OrderId == id))
            {
                var order = DbContext.orders.Include(x => x.Order_Details).Include(x => x.Payment).Include(x => x.Order_Status).FirstOrDefault(x => x.OrderId == id);
                return order;
            }
            else
            {
                throw new Exception("Order not exist!");
            }
        }

        public Order UpdateOrderForSeller(int id, Order order)
        {
            if (DbContext.orders.Any(x => x.OrderId == id && x.Order_StatusId <= 2))
            {
                var ord = DbContext.orders.Include(x => x.User).Include(x => x.Payment).Include(x => x.Order_Status).Include(x => x.Order_Details).SingleOrDefault(x => x.OrderId == id && x.Order_StatusId <= 2);
                ord.Order_StatusId = order.Order_StatusId;
                ord.Updated_at = DateTime.Now;
                DbContext.Update(ord);
                DbContext.SaveChanges();
                if(order.Order_StatusId != 3 || order.Order_StatusId != 2)
                {
                    throw new Exception("Seller not allowed update this status!");
                }
                else
                {
                    if(order.Order_StatusId == 2)
                    {
                        string contentCustomer = "Đơn hàng của bạn đã được người bán xác nhận. Vui lòng chờ người bán chuẩn bị hàng!";
                        SendMail(contentCustomer, order.Email);
                    }
                    else
                    {
                        string contentCustomer = "Đơn hàng của bạn đã được giao cho bên vận chuyển!";
                        SendMail(contentCustomer, order.Email);
                    }
                    return ord;
                }
                
            }
            else
            {
                throw new Exception($"Order not exist or Seller not allow order {id}!");
            }
        }

        public Order UpdateOrderForShip(int id, Order order)
        {
            if (DbContext.orders.Any(x => x.OrderId == id && x.Order_StatusId >= 2 && x.Order_StatusId >= 4))
            {
                var ord = DbContext.orders.Include(x => x.User).Include(x => x.Payment).Include(x => x.Order_Status).Include(x => x.Order_Details).SingleOrDefault(x => x.OrderId == id && x.Order_StatusId <= 2 && x.Order_StatusId >= 4);
                ord.Order_StatusId = order.Order_StatusId;
                ord.Updated_at = DateTime.Now;
                DbContext.Update(ord);
                DbContext.SaveChanges();
                if (order.Order_StatusId != 4 || order.Order_StatusId != 5 || order.Order_StatusId != 8)
                {
                    throw new Exception("Shipping unit not allowed update this status!");
                }
                else
                {
                    if (order.Order_StatusId == 4)
                    {
                            string contentCustomer = "Đơn hàng của bạn đang trên đường giao đến bạn!";
                            SendMail(contentCustomer, order.Email);                       
                    }
                    else if(order.Order_StatusId == 5)
                    {
                        string contentCustomer = $"Đơn hàng của bạn đã được giao và bạn đã trả {order.Actual_Price} cho shipper! Vui lòng xác nhận!";
                        SendMail(contentCustomer, order.Email);
                    }
                    else
                    {
                        string contentCustomer = "Đơn hàng của bạn giao thất bại!";
                        SendMail(contentCustomer, order.Email);
                    }
                    return ord;
                }

            }
            else
            {
                throw new Exception($"Order not exist or shipping unit not allow order {id}!");
            }
        }
    }
}
