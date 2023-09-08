using Microsoft.EntityFrameworkCore;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;

namespace ProductManagement.Service
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly AppDbContext DbContext;
        public OrderStatusService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public Order_status AddOrderStatus(Order_status status)
        {
            DbContext.order_Statuses.Add(status);
            DbContext.SaveChanges();
            return status;
        }

        public string DeleteOrderStatus(int id)
        {
            if(DbContext.order_Statuses.Any(x => x.Order_StatusId == id))
            {
                var status = DbContext.order_Statuses.Find(id);
                DbContext.Remove(status);
                DbContext.SaveChanges();
                var list = DbContext.orders.Where(x => x.Order_StatusId == id);
                DbContext.RemoveRange(list);
                DbContext.SaveChanges();
                var listdetail = new List<Order_detail>();
                foreach(var item in list)
                {
                    var ds = DbContext.orders_detail.Where(x => x.OrderId == item.OrderId).ToList();
                    listdetail.AddRange(ds);
                }
                DbContext.RemoveRange(listdetail);
                DbContext.SaveChanges();
                return "Delete 1 Order_Status successful";
            }
            else
            {
                return "Order_Status not exist!";
            }
        }

        public PageResult<Order_status> GetAllOrderStatus(Pagination pagination)
        {
           var list =  DbContext.order_Statuses.Include(x => x.Orders).ToList();
            var res = PageResult<Order_status>.ToPageResult(pagination, list);
            pagination.TotalCount = list.Count();
            return new PageResult<Order_status>(pagination, res);
        }

        public Order_status GetOrderStatusById(int id)
        {
            if(DbContext.order_Statuses.Include(x => x.Orders).Any(x => x.Orders.Any(x => x.OrderId == id)))
            {
                var status = DbContext.order_Statuses.Include(x => x.Orders).FirstOrDefault(x => x.Orders.Any(x => x.OrderId == id));
                return status;
            }
            else
            {
                throw new Exception("Order status not exist!");
            }
        }

        public Order_status UpdateOrderStatus(int id, Order_status status)
        {
            if (DbContext.order_Statuses.Any(x => x.Order_StatusId == id))
            {
                var st = DbContext.order_Statuses.Find(id);
                st.Status_name = status.Status_name;
                DbContext.Update(st);
                DbContext.SaveChanges() ;
                return st;
            }
            else
            {
                throw new Exception("Order status not exist!");
            }
        }
    }
}
