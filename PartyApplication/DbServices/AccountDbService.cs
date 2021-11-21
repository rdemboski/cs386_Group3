using Microsoft.Azure.Cosmos;
using PartyApplication.IDbServices;
using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.DbServices
{
    public class AccountDbService : IAccountDbService
    {
        private Container _container;

        public AccountDbService(CosmosClient dbClient, string dataBaseName, string containerName)
        {
            this._container = dbClient.GetContainer(dataBaseName, containerName);
        }


        public async Task AddAccountAsync(Account account)
        {
            if (account != null)
            {
                try
                {
                    await this._container.CreateItemAsync<Account>(account, new PartitionKey(account.Id.ToString()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
        public async Task<Account> GetAccountAsync(string id)
        {
            try
            {
                ItemResponse<Account> response = await this._container.ReadItemAsync<Account>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
        public async Task UpdateAccountAsync(Account account)
        {
            try
            {
                await this._container.UpsertItemAsync<Account>(account, new PartitionKey(account.Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task DeleteAccountAsync(string id)
        {
            await this._container.DeleteItemAsync<Event>(id, new PartitionKey(id));
        }


        public async Task<List<Account>> GetAccountsAsync(string queryString)
        {
            using (FeedIterator<Account> query = this._container.GetItemQueryIterator<Account>(new QueryDefinition(queryString)))
            {
                List<Account> list = new List<Account>();
                while (query.HasMoreResults)
                {
                    FeedResponse<Account> response = await query.ReadNextAsync();

                    list.AddRange(response.ToList());
                }

                return list;
            }
        }

        public async Task UpdateHostRating(Account user)
        {
            try
            {
                await this._container.UpsertItemAsync<Account>(user, new PartitionKey(user.Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public double CalculateRating(List<Event> events)
        {
            double total = 0;
            double divisor = 0;
            int i = 0;
            while (i < events.Count)
            {
                total += events[i].TotalRatings;
                divisor += events[i].NumRatings;
                i++;
            }
            return (total / divisor);
        }

    }
}

