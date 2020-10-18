using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MigrateFrom4.Models;
using Newtonsoft.Json.Linq;

namespace MigrateFrom4.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> GetWeather(WeatherVm reqModel)
        {

            var client = new HttpClient();
            var serviceResponse =
                await client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/weather?q={reqModel.WeatherRequest.City}&appid=c93dfd6d2798577214bba6c58dee1163");

            var jsonString  = await serviceResponse.Content.ReadAsStringAsync();
            var jObj = JObject.Parse(jsonString);

            var resultModel = new WeatherVm()
            {
                WeatherRequest = reqModel.WeatherRequest,
                WeatherData = new WeatherData()
                {
                    Description = jObj["weather"][0]["description"].Value<string>(),
                    Temp = jObj["main"]["temp"].Value<decimal>(),
                }
            };

            return View("Index", resultModel);

        } 
    }
}