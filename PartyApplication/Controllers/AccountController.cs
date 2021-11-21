using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyApplication.IDbServices;
using PartyApplication.Model;
using System;
using System.Web;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

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
        [Route("account/{id}")]
        public async Task<ActionResult> GetAccount([FromRoute] String id)
        {
            try
            {
                Account result = await _accountDbService.GetAccountAsync(id);
                return View(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

        [HttpGet]
        [Route("account/manage/{id}")]
        public async Task<ActionResult> ManageAccount([FromRoute] String id)
        {

            if (User.Identity.Name.Equals(id))
            {
                try
                {
                    Account result = await _accountDbService.GetAccountAsync(id);
                    return View(result);
                }

                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
            
            }

            else
            {
                return Redirect("/home");
            }
            
        }

        [HttpPost]
        [Route("account/new")]
        public ActionResult NewAccount([FromForm] Account account)
        { 
            account.Id = account.Username;
            if (account != null)
             {
                _accountDbService.AddAccountAsync(account);
                return View("ManageAccount", account);
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
                            var role = "Attendee";

                            if( user.Host )
                            {
                                role = "Host";
                            }

                            var claims = new List<Claim>
                            {
                                new Claim("name", user.Id),
                                new Claim("role", role)
                            };

                            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "name", "role")));

                            return Redirect("/");
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

        [HttpGet]
        [Route("account/createaccount")]

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet]
        [Route("account/logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }










        //
        //
        //
        ////
        //////
        //////
        ///////
        /////
        ///
        [HttpGet]
        [Route("allaccounts")]

        public async Task<IActionResult> GetAccount()
        {
            List<Account> accounts= await _accountDbService.GetAccountsAsync($"SELECT * FROM c");
            return Ok(accounts);
        }

        [HttpDelete]
        [Route("accounts/delete/{id}")]

        public ActionResult DeleteAccount([FromRoute] string id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _accountDbService.DeleteAccountAsync(id);
            return Ok($"Account {id} was deleted successfully");
        }
        

    }

}
