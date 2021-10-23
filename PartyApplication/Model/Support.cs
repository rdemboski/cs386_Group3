using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.Model
{
    public class Support
    {
        [JsonProperty(PropertyName = "id")]
        public string SupportFormId { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string TicketMessage { get; set; }
    }
}