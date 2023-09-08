using ProductManagement.IService;
using ProductManagement.Models;

namespace ProductManagement.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext DbContext;
        public PaymentService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public Payment AddPayment(Payment payment)
        {
            payment.Created_at = DateTime.Now;
            DbContext.Add(payment);
            DbContext.SaveChanges();
            return payment;
        }

        public string DeletePayment(int id)
        {
            if(DbContext.payment.Any(x => x.PaymentId== id))
            {
                var payment = DbContext.payment.Find(id);
                DbContext.Remove(payment);
                DbContext.SaveChanges();
                var Orderlist = DbContext.orders.Where(x => x.PaymentId == id);
                List<Order_detail> details = new List<Order_detail>();
                foreach(var detail in Orderlist)
                {
                    var ds = DbContext.orders_detail.Where(x => x.OrderId == detail.OrderId).ToList();
                    details.AddRange(ds);
                }
                DbContext.RemoveRange(details);
                DbContext.SaveChanges();
                DbContext.RemoveRange(Orderlist);
                DbContext.SaveChanges();
                return "Delete 1 Payment successful";
            }
            else
            {
                return "Payment not exist!";
            }
        }

        public List<Payment> GetAllPayments()
        {
            return DbContext.payment.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            if(DbContext.payment.Any(x => x.PaymentId == id))
            {
                var payment = DbContext.payment.Find(id);
                return payment;
            }
            else
            {
                throw new Exception("Payment not exist!");
            }
        }

        public Payment UpdatePayment(int id, Payment payment)
        {
            if (DbContext.payment.Any(x => x.PaymentId == id))
            {
                var pay = DbContext.payment.Find(id);
                pay.Payment_method = payment.Payment_method;
                pay.Status = payment.Status;
                pay.Updated_at = DateTime.Now;
                DbContext.Update(pay);
                DbContext.SaveChanges() ;
                return pay;
            }
            else
            {
                throw new Exception("Payment not exist!");
            }
        }
    }
}
