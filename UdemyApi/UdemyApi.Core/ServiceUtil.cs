using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyApi.Model;

namespace UdemyApi.Core
{
    public class ServiceUtil
    {
        public string Token { get; private set; }
        private const string UdemyApiPrefix = "https://www.udemy.com/instructor-api/v1/";
        RestClient client;
        public ServiceUtil(string token)
        {
            this.Token = token;
            client = new RestClient(UdemyApiPrefix);
        }
        public T SendRequest<T>(string url, string filters, Method method) where T : new()
        {
            if (!string.IsNullOrWhiteSpace(filters))
            {
                url += "?" + filters.Trim('&');
            }
            RestSharp.RestRequest request = new RestSharp.RestRequest(url, method);
            request.JsonSerializer = new NewtonsoftJsonSerializer();
            request.AddHeader("Authorization", $"bearer {Token}");
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            var handle = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(handle.Content);
        }

        #region GetCourseQuestions
        /// <summary>
        /// Bir kursa gelmiş soruları listeler
        /// </summary>
        /// <param name="courseId">Kursun benzersiz numarası</param>
        /// <returns></returns>
        public UdemyRootModel<List<Question>> GetCourseQuestionsRoot(string courseId, string filters, int page, int pageSize)
        {
            filters += $"&page={page}&page_size={pageSize}";
            return SendRequest<UdemyRootModel<List<Question>>>(string.Format(Endpoints.CourseQuestions, courseId), filters, Method.GET);
        }
        /// <summary>
        /// Bir kursa gelmiş soruları listeler
        /// </summary>
        /// <param name="courseId">Kursun benzersiz numarası</param>
        /// <param name="filters">İlişkili nesneleri doldurma filtrelemleri</param>
        /// <returns></returns>
        public List<Question> GetCourseQuestions(string courseId, string filters, int page, int pageSize)
        {
            return GetCourseQuestionsRoot(courseId, filters, page, pageSize).results;
        }
        /// <summary>
        /// Bir kursa gelmiş soruları listeler
        /// </summary>
        /// <param name="courseId">Kursun benzersiz numarası</param>
        /// <returns></returns>
        public List<Question> GetCourseQuestions(string courseId, int page, int pageSize)
        {
            var filters = $"{FilterParams.Question}={ReadyParam.All}&{FilterParams.Answer}={ReadyParam.All}&{FilterParams.User}={ReadyParam.All}";
            return GetCourseQuestionsRoot(courseId, filters, page, pageSize).results;
        }
        #endregion

        #region GetMyCourses
        /// <summary>
        /// Verdiğim eğitimleri listeler
        /// </summary>
        /// <returns></returns>
        public UdemyRootModel<List<Course>> GetMyCoursesRoot(string filters = "")
        {
            return SendRequest<UdemyRootModel<List<Course>>>(Endpoints.MyCourses, filters, Method.GET);
        }
        /// <summary>
        /// Verdiğim eğitimleri listeler
        /// </summary>
        /// <returns></returns>
        public List<Course> GetMyCourses(string filters = "")
        {
            return GetMyCoursesRoot(filters).results;
        }
        #endregion
    }
}
