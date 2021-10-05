using Microsoft.Azure.Cosmos;
using PartyApplication.IDbServices;
using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.DbServices
{
    public class PartyDbService : IPartyDbService
    {
        private Container _container;

        // Constructor for class
        public PartyDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }



        public async Task AddPartyAsync(Party item)
        {
            string id = item.Id;
            if(item != null)
            {
                try
                {
                    await this._container.CreateItemAsync<Party>(item, new PartitionKey(item.Id.ToString()));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
        }

        public async Task DeletePartyAsync(string id)
        {
            await this._container.DeleteItemAsync<Party>(id, new PartitionKey(id));
        }

        public async Task<Party> GetPartyAsync(string id)
        {
            try
            {
                Party response = await this._container.ReadItemAsync<Party>(id, new PartitionKey(id));
                return response;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<List<Party>> GetPartiesAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Party>(new QueryDefinition(queryString));
            List<Party> results = new List<Party>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
