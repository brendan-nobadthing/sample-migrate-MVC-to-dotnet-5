using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MigrateFrom4.Models
{
    public class WeatherVm
    {
        public WeatherRequest WeatherRequest { get; set; }

        public WeatherData WeatherData { get; set; }
    }

    public class WeatherData
    {
        public string Description { get; set; }
        public decimal Temp { get; set; }
    }

    public class WeatherRequest
    {
        public string City { get; set; }
    }
}