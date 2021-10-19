using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.IDbServices
{
    public interface IEventDbService
    {
        Task<List<Event>> GetPartiesAsync(string query);
        Task<Event> GetPartyAsync(string id);
        Task AddPartyAsync(Event item);
        Task DeletePartyAsync(string id);
    }
}
