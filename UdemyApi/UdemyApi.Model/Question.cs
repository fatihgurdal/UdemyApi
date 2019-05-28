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
        /// <summary>
        /// Sorunun sayısal kimliği
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// Sorunun oluşturulduğu zaman
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Sorunun başlığı
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string QuestionName { get; set; }
        /// <summary>
        /// Sorunun gövde metni
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string QuestionBody { get; set; }
        /// <summary>
        /// Soruya verilen yanıt sayısı
        /// </summary>
        [JsonProperty(PropertyName = "num_replies")]
        public int ReplieCount { get; set; }
        /// <summary>
        /// Soruyu takip eden kullanıcı sayısı
        /// </summary>
        [JsonProperty(PropertyName = "num_follows")]
        public int FollowCount { get; set; }
        /// <summary>
        /// Soruya olumlu oy veren kullanıcı sayısı
        /// </summary>
        [JsonProperty(PropertyName = "num_reply_upvotes")]
        public int ReplyUpvotesCount { get; set; }
        /// <summary>
        /// Sorunun değiştirilme zamanı
        /// </summary>
        [JsonProperty(PropertyName = "modified")]
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Soru *içeriğinin* değiştirilme zamanı (olumlu oy verme gibi işlemler hariç
        /// </summary>
        [JsonProperty(PropertyName = "last_activity")]
        public DateTime LastActivity { get; set; }
        /// <summary>
        /// Sorunun eğitmen tarafından okunma durumu
        /// </summary>
        [JsonProperty(PropertyName = "is_read")]
        public bool IsRead { get; set; }
        /// <summary>
        /// Soruda bahsedilen kurs
        /// </summary>
        [JsonProperty(PropertyName = "course")]
        public Course Course { get; set; }
        /// <summary>
        /// Sorunun yazarı, kursun aktif bir eğitmeni
        /// </summary>
        [JsonProperty(PropertyName = "is_instructor")]
        public bool IsInstructor { get; set; }
        /// <summary>
        /// Bu sorunun ile ilgili dersin kimliği (varsa)
        /// </summary>
        [JsonProperty(PropertyName = "related_lecture_id")]
        public string RelatedLectureId { get; set; }
        /// <summary>
        /// Bu sorunla ilgili dersin adı (varsa)
        /// </summary>
        [JsonProperty(PropertyName = "related_lecture_title")]
        public string RelatedLectureTitle { get; set; }
        /// <summary>
        /// Bu sorunla ilgili dersin kurs içi URL adresi (varsa)
        /// </summary>
        [JsonProperty(PropertyName = "related_lecture_url")]
        public string RelatedLectureUrl { get; set; }
        /// <summary>
        /// Soruyu soran kullanıcı
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }
        /// <summary>
        /// Soruya verilen cevaplar
        /// </summary>
        [JsonProperty(PropertyName = "replies")]
        public List<Answer> Replies { get; set; }

        public override string ToString()
        {
            string noHtml = Regex.Replace(QuestionBody, @"<[^>]*>", String.Empty);
            String minBody = noHtml.Substring(0, Math.Min(noHtml.Length, 50));
            return $"{Course.CourseName} Kursunda {CreateDate.ToString("dd.MM.yyyy hh:mm")} tarihinde => {QuestionName} <= sorusu gelmiştir. Detayının ilk 50 karakteri: {minBody}...";
        }
    }
}
