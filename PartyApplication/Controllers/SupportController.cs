using Microsoft.AspNetCore.Mvc;
using PartyApplication.IDbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.Controllers
{
    public class SupportController : Controller
    {
        private readonly IEventDbService _partyDbService;
        public SupportController(IEventDbService partyDbService)
        {
            _partyDbService = partyDbService;
        }

        [HttpGet]
        [Route("Support/SubmitTicket")]
        public IActionResult SubmitTicket()
        {
            return View();
        }
    }
}
