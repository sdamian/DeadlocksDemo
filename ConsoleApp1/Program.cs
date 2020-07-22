using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly HttpClient Http = new HttpClient();

        static void Main(string[] args)
        {
            string joke = GetJoke().Result; // no synchronization context no deadlock
            Console.WriteLine(joke);
        }

        private static async Task<string> GetJoke()
        {
            var response = await Http.GetAsync("https://api.chucknorris.io/jokes/random");
            var data = await response.Content.ReadAsAsync<JObject>();
            return (string)data["value"];
        }
    }
}
