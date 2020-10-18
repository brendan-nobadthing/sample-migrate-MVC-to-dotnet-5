using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json.Linq;

namespace Application.Weather
{
    public class WeatherRequestHandler: IRequestHandler<WeatherRequest, WeatherData>
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherRequestHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherData> Handle(WeatherRequest request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var serviceResponse =
                await httpClient.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/weather?q={request.City}&appid=c93dfd6d2798577214bba6c58dee1163", cancellationToken);

            var jsonString = await serviceResponse.Content.ReadAsStringAsync();
            var jObj = JObject.Parse(jsonString);

            return new WeatherData()
            {
                Description = jObj["weather"][0]["description"].Value<string>(),
                Temp = jObj["main"]["temp"].Value<decimal>(),
            };
        }
    }
}
