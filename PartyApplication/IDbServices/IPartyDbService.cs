using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.IDbServices
{
    public interface IPartyDbService
    {
        Task<IEnumerable<Party>> GetPartiesAsync(string query);
        Task<Party> GetPartyAsync(string id);
        Task AddPartyAsync(Party item);
        Task DeletePartyAsync(string id);
    }
}
