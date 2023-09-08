using Microsoft.EntityFrameworkCore;
using ProductManagement.IService;
using ProductManagement.Models;

namespace ProductManagement.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext DbContext;
        public UserService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public User AddUser(User user)
        {
            user.Created_at = DateTime.Now;
            var account = user.Account;
            user.Account = null;
            DbContext.users.Add(user);
            DbContext.SaveChanges();
            if(DbContext.decentralizations.Any(x => x.DecentralizationId == account.DecentralizationId))
            {
                user.AccountId = account.AccountId;
                account.User_name = user.User_name;
                account.Created_at = DateTime.Now;
                DbContext.Add(account);
                DbContext.SaveChanges();
                return user;
            }
            else
            {
                throw new Exception("Decentralization not exist!");
            }
            
        }

        public string DeleteUser(int id)
        {
            if(DbContext.users.Any(x => x.UserId == id))
            {
                var user = DbContext.users.Find(id);
                DbContext.users.Remove(user);
                DbContext.SaveChanges();
                var dsOrders = DbContext.orders.Where(x => x.UserId == id).ToList();
                List<Order_detail> details = new List<Order_detail>();
                foreach(var detail in dsOrders)
                {
                    var ds = DbContext.orders_detail.Where(x => x.OrderId == detail.OrderId).ToList();
                    details.AddRange(ds);
                }
                DbContext.RemoveRange(details);
                DbContext.SaveChanges();

                DbContext.RemoveRange(dsOrders);
                DbContext.SaveChanges();

                var dsProductReviews = DbContext.product_Reviews.Where(x => x.UserId == id).ToList();
                DbContext.RemoveRange(dsProductReviews);
                DbContext.SaveChanges();
                return "Delete 1 user successfull";
            }
            else
            {
                return "User not exist!";
            }
        }

        public List<User> GetAllUsers()
        {
            return DbContext.users.Include(x => x.Orders).ToList();
        }

        public User GetUserById(int id)
        {
            if(DbContext.users.Any(x => x.UserId == id))
            {
                var user = DbContext.users.Find(id);
                return user;
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }

        public User UpdateUser(int id, User user)
        {
            if(DbContext.users.Any(x => x.UserId == id))
            {
                user = DbContext.users.Find(id);
                user.Updated_at = DateTime.Now;
                user.Account.Updated_at = DateTime.Now;
                DbContext.users.Update(user);
                DbContext.SaveChanges();
                return user;
            }
            else
            {
                throw new Exception("User not exist!");
            }
        }
    }
}
