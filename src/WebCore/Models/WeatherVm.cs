using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Weather;

namespace WebCore.Models
{
    public class WeatherVm
    {
        public WeatherRequest WeatherRequest { get; set; }

        public WeatherData WeatherData { get; set; }
    }
}
