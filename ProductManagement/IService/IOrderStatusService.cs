using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Models;
using ProductManagement.Pag;

namespace ProductManagement.IService
{
    public interface IOrderStatusService
    {
        public Order_status AddOrderStatus(Order_status status);
        public Order_status UpdateOrderStatus(int id, Order_status status);
        public string DeleteOrderStatus (int id);
        public Order_status GetOrderStatusById (int id);
        public PageResult<Order_status> GetAllOrderStatus (Pagination pagination);

    }
}
