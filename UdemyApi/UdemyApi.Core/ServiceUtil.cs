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
        public T SendRequest<T>(string url,Method method) where T : new()
        {
            RestSharp.RestRequest request = new RestSharp.RestRequest(url, method);
            request.JsonSerializer = new NewtonsoftJsonSerializer();
            request.AddHeader("Authorization", $"bearer {Token}");
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            var handle = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(handle.Content);
        }
        public UdemyRootModel<List<Question>> GetCourseQuestionsRoot(string courseId)
        {
            return SendRequest<UdemyRootModel<List<Question>>>(string.Format(Endpoints.CourseQuestions, courseId), Method.GET);
        }
        public List<Question> GetCourseQuestions(string courseId)
        {
            return GetCourseQuestionsRoot(courseId).results;
        }
    }
}
