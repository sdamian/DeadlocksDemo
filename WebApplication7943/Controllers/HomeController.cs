using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient Http = new HttpClient();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = await GetJoke();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private async Task<string> GetJoke()
        {
            var response = await Http.GetAsync("https://api.chucknorris.io/jokes/random");
            var data = await response.Content.ReadAsAsync<JObject>();
            return (string)data["value"];
        }
    }
}