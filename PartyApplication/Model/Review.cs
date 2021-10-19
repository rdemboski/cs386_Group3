using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.Model
{
    public class Review
    {
        [JsonProperty(PropertyName = "id")]
        public string Reviewee { get; set; }

        [JsonProperty(PropertyName = "id")]

        public string Reviewer { get; set; }

        [JsonProperty(PropertyName = "id")]

        public string Message { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Likes { get; set; }
    }
}
