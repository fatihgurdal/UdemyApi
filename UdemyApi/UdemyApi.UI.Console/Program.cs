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

            var questions = serviceUtil.GetCourseQuestions("1287382"); //Course Id

            foreach (var item in questions)
            {
                System.Console.WriteLine(item.ToString());
                System.Console.WriteLine(new string('-', 30));
                System.Console.WriteLine("");
            }

            System.Console.ReadKey();

        }
    }
}
