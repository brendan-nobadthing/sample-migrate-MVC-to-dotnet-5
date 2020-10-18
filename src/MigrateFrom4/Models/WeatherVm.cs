using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Weather;

namespace MigrateFrom4.Models
{
    public class WeatherVm
    {
        public WeatherRequest WeatherRequest { get; set; }

        public WeatherData WeatherData { get; set; }
    }

    
}