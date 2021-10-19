using Microsoft.Azure.Cosmos;
using PartyApplication.IDbServices;
using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.DbServices
{
    public class EventDbService : IEventDbService
    {
        private Container _container;

        // Constructor for class
        public EventDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }



        public async Task AddPartyAsync(Event item)
        {
            string id = item.Id;
            if(item != null)
            {
                try
                {
                    await this._container.CreateItemAsync<Event>(item, new PartitionKey(item.Id.ToString()));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
        }

        public async Task DeletePartyAsync(string id)
        {
            await this._container.DeleteItemAsync<Event>(id, new PartitionKey(id));
        }

        public async Task<Event> GetPartyAsync(string id)
        {
            try
            {
                ItemResponse<Event> response = await this._container.ReadItemAsync<Event>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }


        public async Task<List<Event>> GetPartiesAsync(string queryString)
        {
            using (FeedIterator<Event> query = this._container.GetItemQueryIterator<Event>(new QueryDefinition(queryString)))
            {
                List<Event> list = new List<Event>();
                while (query.HasMoreResults)
                {
                    FeedResponse<Event> response = await query.ReadNextAsync();

                    list.AddRange(response.ToList());
                }

                return list;
            }
            

/*            using (FeedIterator<MyItem> feedIterator = this.Container.GetItemQueryIterator<MyItem>(
    queryDefinition))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<MyItem> response = await feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        Console.WriteLine(item);
                    }
                }
            }*/
        }
    }
}
