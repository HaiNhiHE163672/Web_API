using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using ProductManagement.IService;
using Microsoft.AspNetCore.Authorization;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenController : ControllerBase
    {
        private readonly IAccountService _accountService;
        //private readonly IConfiguration _configuration;
        //private readonly AppDbContext _appDbContext;
        public TokenController(IAccountService accountService/*, IConfiguration configuration, AppDbContext appDbContext*/)
        {
            _accountService = accountService;
            //_configuration = configuration;
            //_appDbContext = appDbContext;
        }
        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login(Account account)
        //{
        //    var token = _accountService.Login(account);
        //    if (token == null)
        //    {
        //        return Ok(new { Message = "Unauthorized" });
        //    }
        //    return Ok(token);
        //}


    }
}
