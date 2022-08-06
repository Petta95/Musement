using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CityApplication
{
    public class City
    {
        //url = https://api.musement.com/api/v3/cities/1.json

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("uuid")]
        public string uuid { get; set; }

        [JsonProperty("top")]
        public string top { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("content")]
        public string content { get; set; }

        [JsonProperty("latitude")]
        public double latitude { get; set; }

        [JsonProperty("longitude")]
        public double longitude { get; set; }

    }
}
