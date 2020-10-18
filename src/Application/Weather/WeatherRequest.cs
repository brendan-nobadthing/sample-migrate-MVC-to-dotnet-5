using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Weather
{
    public class WeatherRequest: IRequest<WeatherData>
    {
        public string City { get; set; }    
    }
}
