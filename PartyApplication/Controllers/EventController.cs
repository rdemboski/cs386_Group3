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
    public class EventController : Controller
    {
        private readonly IEventDbService _partyDbService;

        private readonly IAccountDbService _accountDbService;
        public EventController(IEventDbService partyDbService, IAccountDbService accountDbService)
        {
            _partyDbService = partyDbService;
            _accountDbService = accountDbService;
        }

        [HttpPost]
        [Route("parties")]
        public async Task<IActionResult> GetPartiesByZipcode([FromForm] string zipcode)
        {

            List<Event> events = await _partyDbService.GetPartiesAsync($"SELECT * FROM c WHERE c.zipcode = '{zipcode}'");
            if (events != null)
            {
                return View("GetParties", events);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}")]
        [Route("party/{id}")]

        public async Task<ActionResult> GetParty([FromRoute] string id)
        {
            Event result = await _partyDbService.GetPartyAsync(id);
            return View(result);
        }


        [HttpPost]
        [Route("newparty")]
        public ActionResult NewParty([FromForm] Event party)
        {
            Guid guid = Guid.NewGuid();
            party.Id = guid.ToString();
            if (party != null)
            {

                _partyDbService.AddPartyAsync(party);

                party.TimeCreated = DateTime.UtcNow;

                // TODO: once a party is found look up user by the name of the person who added it
                // this will allow the object to be a account object
                return View("GetParty", party);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public ActionResult DeleteParty([FromRoute] string id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _partyDbService.DeletePartyAsync(id);
            return Ok($"Party {id} was deleted successfully");
        }



        [HttpGet]
        [Route("parties/createevent")]
        public IActionResult CreateEvent()
        {
            return View();
        }



        //
        //
        //
        //
        //
        //
        // THESE METHODS ONLY RETURN HTML
        // NOTHING ELSE
        [HttpGet]
        [Route("events")]
        public ActionResult Events()
        {
            return View();
        }
        //
        //
        //
        //
        //
        //
        ///
        //
        //
        //
        //
        //
        //
        //
        //
        //  this method is for testing ALL parties in DB

        [HttpGet]
        [Route("allparties")]
        public async Task<IActionResult> GetParties()
        {
            List<Event> events = await _partyDbService.GetPartiesAsync($"SELECT * FROM c");
            return Ok(events);
        }

    }
}
