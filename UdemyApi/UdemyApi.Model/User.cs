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

        /// <summary>
        /// Kullanıcının tam adı
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Kullanıcının kısa adı (genellikle ilk adı)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Kullanıcının dili ve ülkesi
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
