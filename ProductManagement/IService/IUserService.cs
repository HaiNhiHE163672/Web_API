using ProductManagement.Models;

namespace ProductManagement.IService
{
    public interface IUserService
    {
        public User AddUser(User user);
        public User UpdateUser(int id, User user);
        public User GetUserById(int id);
        public string DeleteUser(int id);
        public List<User> GetAllUsers();
    }
}
