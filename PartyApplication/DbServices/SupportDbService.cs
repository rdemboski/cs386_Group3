using Microsoft.Azure.Cosmos;
using PartyApplication.IDbServices;
using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.DbServices
{

    public class SupportDbService : ISupportDbService
    {

        private Container _container;


        public SupportDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddSupportAsync(Support item)
        {

            if (item != null)
            {
                try
                {
                    await this._container.CreateItemAsync<Support>(item, new PartitionKey(item.SupportFormId.ToString()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
