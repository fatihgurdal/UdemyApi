using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyApi.Model
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
