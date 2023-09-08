using ProductManagement.IService;
using ProductManagement.Models;

namespace ProductManagement.Service
{
    public class DecentralizationService : IDecentrlizationService
    {
        private readonly AppDbContext DbContext;
        public DecentralizationService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public Decentralization AddDecentralization(Decentralization decentralization)
        {
            decentralization.Create_at = DateTime.Now;
            DbContext.decentralizations.Add(decentralization);
            DbContext.SaveChanges();
            return decentralization;
        }

        public string DeleteDecentralization(int decentralizationId)
        {
            if(DbContext.decentralizations.Any(x => x.DecentralizationId == decentralizationId))
            {
                var dec = DbContext.decentralizations.Find(decentralizationId);
                DbContext.decentralizations.Remove(dec);
                DbContext.SaveChanges();
                var list = DbContext.accounts.Where(x => x.DecentralizationId == decentralizationId).ToList();
                List<User> dsUsers = new List<User>();
                foreach(var ds in list)
                {
                    var user = DbContext.users.Where(x => x.AccountId == ds.AccountId).ToList();
                    dsUsers.AddRange(user);
                }
                List<Product_review> product_Reviews = new List<Product_review>();
                foreach(var productReview in dsUsers)
                {
                    var reviews = DbContext.product_Reviews.Where(x => x.UserId == productReview.UserId).ToList();
                    product_Reviews.AddRange(reviews);
                }
                DbContext.RemoveRange(product_Reviews);
                DbContext.SaveChanges();
                List<Order> orders = new List<Order>();
                foreach(var order in dsUsers)
                {
                    var ds = DbContext.orders.Where(x => x.UserId == order.UserId).ToList();
                    orders.AddRange(ds);
                }
                List<Order_detail> order_Details = new List<Order_detail>();
                foreach(var detail in orders)
                {
                    var ds = DbContext.orders_detail.Where(x => x.OrderId == detail.OrderId).ToList();
                    order_Details.AddRange(ds);
                }
                DbContext.RemoveRange(order_Details);
                DbContext.SaveChanges();

                DbContext.RemoveRange(orders);
                DbContext.SaveChanges();

                DbContext.RemoveRange(dsUsers);
                DbContext.SaveChanges();

                DbContext.RemoveRange(list);
                DbContext.SaveChanges();

                return "Delete 1 decentralization successful";
            }
            else
            {
                return "Decentralization not exist";
            }
        }

        public Decentralization GetDecentralizationById(int id)
        {
            if (DbContext.decentralizations.Any(x => x.DecentralizationId == id))
            {
                var dec = DbContext.decentralizations.Find(id);
                return dec;
            }
            else
            {
                throw new Exception("Decentralization not exist!");
            }
        }

        public List<Decentralization> GetDecentralizations()
        {
            var list = DbContext.decentralizations.ToList();
            return list;
        }

        public Decentralization UpdateDecentralization(int id, Decentralization decentralization)
        {
            if(DbContext.decentralizations.Any(x => x.DecentralizationId == id))
            {
                var dec = DbContext.decentralizations.Find(id);
                //decentralization.DecentralizationId = id;
                //decentralization.Create_at = decentralization.Create_at;
                dec.Authorrity_name = decentralization.Authorrity_name;
                dec.Update_at = DateTime.Now;
                dec.Accounts = null;
                DbContext.decentralizations.Update(dec);
                DbContext.SaveChanges();
                return dec;
            }
            else
            {
                throw new Exception("Decentralization not exist!");
            }
        }

    }
}
