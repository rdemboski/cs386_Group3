using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyApplication.DbServices;
using PartyApplication.IDbServices;

namespace PartyApplication.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyDbService _partyDbService;
        public PartyController(IPartyDbService partyDbService)
        {
            _partyDbService = partyDbService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("party/{id}")]
        public ActionResult GetParty([FromRoute]string id)
        {
            Task<Party> party = _partyDbService.GetPartyAsync(id);
            return Ok(party);
        }
        //TESTING OEN TWO

            
        [HttpPost]
        [Route("newparty")]
        public ActionResult NewParty([FromBody] Party party)
        {
            if(party !=null)
            {
                 _partyDbService.AddPartyAsync(party);
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);


        }

    }
}
