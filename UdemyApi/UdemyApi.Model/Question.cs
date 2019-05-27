using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UdemyApi.Model
{
    public class Question
    {
        public string _class { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "created")]
        public DateTime CreateDate { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string QuestionName { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string QuestionBody { get; set; }
        [JsonProperty(PropertyName = "num_replies")]
        public int ReplieCount { get; set; }
        [JsonProperty(PropertyName = "num_follows")]
        public int FollowCount { get; set; }
        [JsonProperty(PropertyName = "num_reply_upvotes")]
        public int ReplyUpvotesCount { get; set; }
        [JsonProperty(PropertyName = "modified")]
        public DateTime ModifiedDate { get; set; }
        [JsonProperty(PropertyName = "last_activity")]
        public DateTime LastActivity { get; set; }
        [JsonProperty(PropertyName = "is_read")]
        public bool IsRead { get; set; }
        [JsonProperty(PropertyName = "course")]
        public Course Course { get; set; }
        [JsonProperty(PropertyName = "is_instructor")]
        public bool IsInstructor { get; set; }

        public override string ToString()
        {
            string noHtml = Regex.Replace(QuestionBody, @"<[^>]*>", String.Empty);
            String minBody = noHtml.Substring(0, Math.Min(noHtml.Length, 50));
            return $"{Course.CourseName} Kursunda {CreateDate.ToString("dd.MM.yyyy hh:mm")} tarihinde => {QuestionName} <= sorusu gelmiştir. Detayının ilk 50 karakteri: {minBody}...";
        }
    }
}
