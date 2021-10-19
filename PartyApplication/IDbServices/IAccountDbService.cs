using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.IDbServices
{
    public interface IAccountDbService
    {
        // this is to get a enumerable of all hosts in zipcode
        Task<List<Account>> GetHostsByZipcode(string query);

        // this gives you a specific host by id (which will also be name)
        Task<Account> GetHostAsync(string id);

        // this will add a host to the system

        Task AddAccountAsync(Account item);

        Task<Account> GetAccountAsync(string id);

        Task DeleteAccountAsync(string id);

    }
}
