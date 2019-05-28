using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyApi.Model
{
    public class Course
    {
        public string _class { get; set; }
        /// <summary>
        /// Kursun sayısal kimliği
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// 	Kursun başlığı
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string CourseName { get; set; }
        /// <summary>
        /// Kursun Udemy'deki URL'si
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string CourseUrl { get; set; }
        /// <summary>
        /// Kurs ücretli (ücretsiz değil)
        /// </summary>
        [JsonProperty(PropertyName = "is_paid")]
        public bool IsPaid { get; set; }
        /// <summary>
        /// Bu kurs URL'sinin benzersiz kısmı
        /// </summary>
        [JsonProperty(PropertyName = "published_title")]
        public string PublishedTitle { get; set; }
        /// <summary>
        /// Ziyaretçilere gösterilen kurs açıklaması
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Ziyaretçilere gösterilen kurs başlığı
        /// </summary>
        [JsonProperty(PropertyName = "headline")]
        public string HeadLine { get; set; }
        /// <summary>
        /// Kurs yayınlandı
        /// </summary>
        [JsonProperty(PropertyName = "is_published")]
        public bool IsPublished { get; set; }
        /// <summary>
        /// Kursun ağırlıklı ortalama puanı
        /// </summary>
        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; }
        /// <summary>
        /// Kursa yapılan yorum sayısı
        /// </summary>
        [JsonProperty(PropertyName = "num_reviews")]
        public int NumReviews { get; set; }
        /// <summary>
        /// Kursun ilk oluşturulma zamanı
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Kursun yayınlandığı zaman
        /// </summary>
        [JsonProperty(PropertyName = "published_time")]
        public DateTime? PublishtedTime { get; set; }

        [JsonProperty(PropertyName = "visible_instructors")]
        public List<User> Instructors { get; set; }
        public override string ToString()
        {
            return $"{CourseName} Eğitmenleri=> {string.Join(", ", this.Instructors)}";
        }
    }
}
