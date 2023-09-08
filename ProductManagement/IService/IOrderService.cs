using ProductManagement.Models;
using ProductManagement.Pag;

namespace ProductManagement.IService
{
    public interface IOrderService
    {
        public string AddOrder(Order order);
        public Order UpdateOrderForSeller(int id, Order order);
        public Order UpdateOrderForShip(int id, Order order);
        public String DeleteOrder(int id);
        public Order GetOrderById(int id);
        public PageResult<Order> GetAllOrder(Pagination pagination);

    }
}
