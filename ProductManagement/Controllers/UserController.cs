using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using ProductManagement.Service;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IDecentrlizationService _decentrlizationService;
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService, IDecentrlizationService decentralizationService)
        {
            _accountService = accountService;
            _decentrlizationService = decentralizationService;
        }
        //Account
        [HttpPost("SignIn")]
        public IActionResult AddAccount(Account account)
        {
            var res = _accountService.SignIn(account);
            return Ok(res);
        }
        [Authorize]
        [HttpPut("UpdateAccount/{id}")]
        public IActionResult UpdateAccount(int id, Account account)
        {
            var res = _accountService.UpdateAccount(id, account);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("ListAccount")]
        public IActionResult ListAccount([FromQuery] Pagination pagination)
        {
            var res = _accountService.GetAccounts(pagination);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAccount/{id}")]
        public IActionResult GetAccount(int id)
        {
            var res = _accountService.AccountGetAccountById(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteAccount/{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var res = _accountService.DeleteAccount(id);
            return Ok(res);
        }

        //Login

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            var token = _accountService.Login(login);
            if (token == null)
            {
                return Ok(new { Message = "Unauthorized" });
            }
            return Ok(token);
        }

        //ChangePassword
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(string UserName, string OldPassword, string NewPassword)
        {
            var res = _accountService.ChangePasssword(UserName, OldPassword, NewPassword);
            return Ok(res);
        }
        //Forgot Password
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string username, string email)
        {
            var res = _accountService.ForgotPassword(username, email);
            return Ok(res);
        }

        //ResetPassword
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string username, string token, string password, string confirmpassword)
        {
            var res = _accountService.ResetPassword(username, token, password, confirmpassword);
            return Ok(res);
        }
        //Decentralization
        [HttpPost("AddDecentralization")]
        public IActionResult AddDecentralization(Decentralization decentralization)
        {
            var res = _decentrlizationService.AddDecentralization(decentralization);
            return Ok(res);
        }
        [HttpPut("UpdateDecentralization/{id}")]
        public IActionResult UpdateDecentralization(int id, Decentralization decentralization)
        {
            var res = _decentrlizationService.UpdateDecentralization(id, decentralization);
            return Ok(res);
        }

    }
}
