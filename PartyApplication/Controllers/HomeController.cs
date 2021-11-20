using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("")]
        [Route("home")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
