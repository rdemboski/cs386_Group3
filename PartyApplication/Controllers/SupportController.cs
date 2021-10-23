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
    public class SupportController : Controller
    {
        private readonly ISupportDbService _supportDbService;
        public SupportController(ISupportDbService supportDbService)
        {
            _supportDbService = supportDbService;
        }

        [HttpGet]
        [Route("SubmitTicket")]
        public IActionResult SubmitTicket()
        {
            return View();
        }

        [HttpPost]
        [Route("Submitted")]
        public ActionResult NewTicket([FromForm] Support ticket)
        {
            if(ticket != null)
            {
                _supportDbService.AddSupportAsync(ticket);
                return View("SubmitTicket");
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
