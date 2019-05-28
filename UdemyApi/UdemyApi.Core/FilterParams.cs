using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyApi.Core
{
    /// <summary>
    /// Entity bazlı filtreleme. URL'de gönderilen alanların entity içinde hangi özelliklerin gelceğini veya gelmeyeceğini belirlemek için kullanılır.
    /// </summary>
    public class FilterParams
    {
        public const string Course = "fields[course]";
        public const string Answer = "fields[answer]";
        public const string CourseReview = "fields[course_review]";
        public const string CourseReviewResponse = "fields[course_review_response]";
        public const string Message = "fields[message]";
        public const string MessageThread = "fields[message_thread]";
        public const string Question = "fields[question]";
        public const string User = "fields[user]";
    }
    public class ReadyParam
    {
        /// <summary>
        /// udemy tarafından belirlenmiş varsayılan alanları çeker.
        /// </summary>
        public const string Default = "@default";
        /// <summary>
        /// Tüm alanları çeker
        /// </summary>
        public const string All = "@all";
        /// <summary>
        /// Gerekli minimum alanlar ile çeker
        /// </summary>
        public const string Min = "@min";
    }
}
