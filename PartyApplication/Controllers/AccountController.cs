using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyApplication.IDbServices;
using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountDbService _accountDbService;

        public AccountController(IAccountDbService accountDbService)
        {
            _accountDbService = accountDbService;
        }

        [HttpGet]
        [Route("account/{username}")]
        public async Task<ActionResult> GetAccount(string username)
        {
            Account result = await _accountDbService.GetAccountAsync(username);
            return Ok(result);
        }

        [HttpPost]
        [Route("account/new")]
        public ActionResult NewAccount([FromBody] Account account)
        {
            account.Id = account.Username;
            if (account != null)
             {
                _accountDbService.AddAccountAsync(account);
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<ActionResult> Login([FromForm] Account account)
        {
            if(account!= null)
            {
                try
                {
                    Account user = await _accountDbService.GetAccountAsync(account.Username.ToString());
                    if(user !=null)
                    {
                        if (account.Username == user.Username &&
                                            account.Passcode == user.Passcode)
                        {
                            return View("GetAccount", user);
                        }
                    }
                    return View("LoginPage");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet]
        [Route("account/loginpage")]
        
        public IActionResult LoginPage()
        {
            return View();
        }


    }
}
