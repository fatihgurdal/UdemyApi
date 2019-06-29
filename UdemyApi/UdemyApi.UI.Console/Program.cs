using System;
using UdemyApi.Core;

namespace UdemyApi.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello Udemy!");
            System.Console.WriteLine("Start Test rest request");

            ServiceUtil serviceUtil = new ServiceUtil(args[0]); //https://www.udemy.com/instructor/account/api/ Generate Instructor API Token

            #region Kurslarım
            var courses = serviceUtil.GetMyCourses($"{FilterParams.Course}={ReadyParam.All}&{FilterParams.User}={ReadyParam.All}");
            System.Console.WriteLine("Kurslarım ↓");
            for (var i = 0; i < courses.Count; i++)
            {
                System.Console.WriteLine(string.Format("Sıra:{0} -> {1}", i, courses[i].ToString()));
                System.Console.WriteLine(new string('-', 30));
                System.Console.WriteLine("");
            }
            #endregion
            System.Console.Write("Kurs Sırasını Giriniz: ");
            var courseIndex = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("{0} Kursunun ilk 10 Sorusu ↓", courses[courseIndex].CourseName);
            #region - Bir kurusun soruları -
            var questions = serviceUtil.GetCourseQuestions(courses[courseIndex].Id, 1, 10); //Course Id

            foreach (var item in questions)
            {
                System.Console.WriteLine(item.ToString());
                System.Console.WriteLine(new string('-', 30));
                System.Console.WriteLine("");
            }
            #endregion
            var exitAnswer = string.Empty;
            do
            {
                exitAnswer = System.Console.ReadLine();
            } while (exitAnswer != "bye");

            System.Console.WriteLine("Esen kalın...");
            System.Threading.Thread.Sleep(2000);

        }
    }
}
