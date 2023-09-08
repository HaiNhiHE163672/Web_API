using ProductManagement.Models;

namespace ProductManagement.IService
{
    public interface IPaymentService
    {
        public Payment AddPayment(Payment payment);
        public Payment UpdatePayment(int id, Payment payment);
        public Payment GetPaymentById(int id);
        public string DeletePayment(int id);
        public List<Payment> GetAllPayments();
    }
}
