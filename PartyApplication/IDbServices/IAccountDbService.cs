using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.IDbServices
{
    public interface IAccountDbService
    {
        Task UpdateHostRating(Account user);
        // this will add a host to the system

        Task AddAccountAsync(Account item);

        Task<Account> GetAccountAsync(string id);

        Task UpdateAccountAsync(Account account);

        Task DeleteAccountAsync(string id);

        Task<List<Account>> GetAccountsAsync(string queryString);

        double CalculateRating(List<Event> events);

    }
}
