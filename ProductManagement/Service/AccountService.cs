using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProductManagement.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext DbContext;
        private readonly IConfiguration _configuration;
        public AccountService(AppDbContext appDbContext, IConfiguration configuration)
        {
            DbContext = appDbContext;
            _configuration = configuration;
        }

        public Account AccountGetAccountById(int id)
        {
            if (DbContext.accounts.Any(x => x.AccountId == id))
            {
                var account = DbContext.accounts.Include(x => x.User).FirstOrDefault(x => x.AccountId == id);
                return account;
            }
            else
            {
                throw new Exception("Account not exist!");
            }
        }

        public Account SignIn(Account account)
        {
            if(DbContext.accounts.Include(x => x.User).Any(x => x.User_name.Equals(account.User_name) || x.User.Email.Equals(account.User.Email)))
            {
                throw new Exception("User name already exist! Please choose other user name!");
            }
            else
            {
                account.Created_at = DateTime.Now;
                account.DecentralizationId = 2;
                var user = account.User;
                DbContext.accounts.Add(account);
                user.AccountId = account.AccountId;
                //user.User_name = account.User_name;
                user.Created_at = DateTime.Now;
                DbContext.Add(user);
                DbContext.SaveChanges();
                DbContext.SaveChanges();
                

                return account;
            }
            
        }

        public string DeleteAccount(int AccountId)
        {
            if (DbContext.accounts.Any(x => x.AccountId == AccountId))
            {
                var account = DbContext.accounts.Include(x => x.User).FirstOrDefault(x => x.AccountId == AccountId);
                DbContext.Remove(account);
                DbContext.SaveChanges();
                var dsReview = DbContext.product_Reviews.Where(x => x.UserId == account.User.UserId).ToList();
                DbContext.RemoveRange(dsReview);
                DbContext.SaveChanges();
                var dsOrder = DbContext.orders.Where(x => x.UserId == account.User.UserId).ToList();
                List<Order_detail> details = new List<Order_detail>();
                foreach (var detail in dsOrder)
                {
                    var ds = DbContext.orders_detail.Where(x => x.OrderId == detail.OrderId).ToList();
                    details.AddRange(ds);
                }
                DbContext.RemoveRange(details);
                DbContext.SaveChanges();
                DbContext.RemoveRange(dsOrder);
                DbContext.SaveChanges();

                return "Delete 1 Account successful";
            }
            else
            {
                return "Account not exist";
            }
        }

        public PageResult<Account> GetAccounts(Pagination pagination)
        {
            var list = DbContext.accounts.Include(x => x.User).ToList();
            var res = PageResult<Account>.ToPageResult(pagination, list);
            pagination.TotalCount = list.Count();
            return new PageResult<Account>(pagination, list);
        }

        public Account UpdateAccount(int id, Account account)
        {
            if (DbContext.accounts.Any(x => x.AccountId == id))
            {
                var acc = DbContext.accounts.Find(id);
                //acc.AccountId = id;
                acc.User_name = account.User_name;
                acc.Avartar = account.Avartar;
                acc.Status = account.Status;
                acc.ResetPasswordToken = account.ResetPasswordToken;
                //acc.DecentralizationId = account.DecentralizationId;
                acc.Updated_at = DateTime.Now;
                //var user = acc.User;
                DbContext.Update(acc);
                DbContext.SaveChanges();
                if(DbContext.users.Any(x => x.AccountId == acc.AccountId))
                {
                    var u = DbContext.users.FirstOrDefault(x => x.AccountId == acc.AccountId);
                    u.AccountId = acc.AccountId;
                    u.User_name = acc.User_name;
                    u.Phone = account.User.Phone;
                    u.Email = account.User.Email;
                    u.Address = account.User.Address;
                    u.Updated_at = DateTime.Now;
                    DbContext.Update(u);
                    DbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User not exist!");
                }
                return acc;
            }
            else
            {
                throw new Exception("Account not exist!");
            }
        }

        public string Login(Login login)
        {

            if (DbContext.accounts.Any(x => x.User_name.Equals(login.UserName) && x.Password.Equals(login.Password)))
            {
                var account = DbContext.accounts.FirstOrDefault(x => x.User_name.Equals(login.UserName) && x.Password.Equals(login.Password));
                return GenerateToken(account);
            }
            else
            {
                if (DbContext.accounts.Any(x => x.User_name.Equals(login.UserName)))
                {
                    return "Login failed! Password is wrong";
                }
                else if(DbContext.accounts.Any(x => x.Password.Equals(login.Password)))
                {
                    return "Login failed! Username is wrong";
                }
                else
                {
                    return "Login failed! username and password are wrong";
                }
            }
        }
        private string GenerateToken(Account acc)
        {
            var role = DbContext.decentralizations.FirstOrDefault(x => x.DecentralizationId == acc.DecentralizationId);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("User_name", acc.User_name),
                new Claim("AccountId", acc.AccountId.ToString()),
                new Claim(ClaimTypes.Role, role?.Authorrity_name??"")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn
                );

            string Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;

        }

        public string ChangePasssword(string username, string oldpassword, string newpassword)
        {
            if (DbContext.accounts.Any(x => x.User_name.Equals(username)))
            {
                var acc = DbContext.accounts.SingleOrDefault(x => x.User_name.Equals(username));
                if(oldpassword == acc.Password)
                {
                    acc.Password = newpassword;
                    DbContext.Update(acc);
                    DbContext.SaveChanges();
                    return "Change password successful";
                }
                else
                {
                    return "Old Password is wrong!";
                }
            }
            else
            {
                return "User not found";
            }
        }


        public string ForgotPassword(string username, string email)
        {
            var user =  DbContext.accounts.Include(x => x.User).FirstOrDefault(x => x.User_name == username && x.User.Email == email);
            if(user == null)
            {
                return "Account not found";
            }

            user.ResetPasswordToken = CreateRandomToken();
            user.ResetPasswordTokenExpiry = DateTime.Now.AddDays(1);
            DbContext.Update(user);
            DbContext.SaveChanges();
            return user.ResetPasswordToken;
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        public string ResetPassword(string username, string token, string password, string confirmpassword)
        {
            var acc = DbContext.accounts.SingleOrDefault(x => x.ResetPasswordToken == token);
            if(acc == null || acc.ResetPasswordTokenExpiry < DateTime.Now)
            {
                return "Invalid Token";
            }

            acc.Password = password;
            if (confirmpassword == password)
            {
                DbContext.Update(acc);
                DbContext.SaveChanges();
                return "Reset password successful!";
            }
            else
            {
                return "Confirm Password is wrong";
            }
            return null;
        }
    }
}
