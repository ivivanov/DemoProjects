using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CSharp6.Helpers;
using System.Net.Http;
using System.Linq.Expressions;

namespace CSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(MultiplyBy8(4));

            var stars = new Dictionary<string, string>()
            {
                ["Michael Jordan"] = "Basketball",
                ["Peyton Manning"] = "Football",
                ["Babe Ruth"] = "Baseball"
            };

            //String Interpolation
            string firstName = "Michael";
            string lastName = "Crump";
            WriteLine($"{firstName} {lastName} is my name!");

            WriteLine(nameof(firstName));

            //exception handiling
            try
            {
                var httpStatusCode = 400;
                throw new Exception(httpStatusCode.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Write("Bad Request");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Write("Unauthorized");
                ReadLine();
            }

            string word = "interpolation";
            Expression<Func<string>> expression =
                () => $"The word {word} contains {word.Length} characters, which is more than {word.Length - 1}";
            var methodCallExpression = expression.Body as MethodCallExpression;

            ReadLine();
        }

    }

    public static class Helpers
    {
        public static int MultiplyBy8(int x) => x * 8;
    }

    public class Customer
    {
        public Guid customerID { get; set; } = Guid.NewGuid();
    }

}

namespace CSharpSix
{
    class Program
    {
        private void Start()
        {
            Task.Factory.StartNew(() => GetPage());
            ReadLine();
        }

        private async static Task GetPage()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync("http://www.telerik.com");
                WriteLine(result);
            }
            catch (Exception)
            {
                try
                {
                    //This asynchronous request will run if the first request failed. 
                    var result = await client.GetStringAsync("http://www.progress.com");
                    WriteLine(result);
                }
                catch
                {
                    WriteLine("Entered Catch Block");
                }
                finally
                {
                    WriteLine("Entered Finally Block");
                }
            }
        }
    }
}
