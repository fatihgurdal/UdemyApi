using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyApi.Model
{
    public class Course
    {
        public string _class { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string CourseName { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string CourseUrl { get; set; }
    }
}
