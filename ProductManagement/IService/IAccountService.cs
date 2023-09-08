using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Models;
using ProductManagement.Pag;

namespace ProductManagement.IService
{
    public interface IAccountService
    {
        
        public Account SignIn(Account account);
        public PageResult<Account> GetAccounts(Pagination pagination);
        public Account AccountGetAccountById(int id);
        public Account UpdateAccount(int id, Account account);
        public string DeleteAccount(int AccountId);
        public string Login(Login login);
        public string ChangePasssword(string username, string oldpassword, string newpassword);
        public string ForgotPassword(string username, string email);
        public string ResetPassword(string username, string token ,string password, string confirmpassword);
        
    }
}
