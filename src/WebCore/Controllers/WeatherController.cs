using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Weather;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Weather
        public ActionResult Index()
        {
            return View("Index", new WeatherVm()
            {
                WeatherRequest = new WeatherRequest()
            });
        }


        [HttpPost]
        public async Task<ActionResult> GetWeather(WeatherVm reqModel)
        {

            var resultModel = new WeatherVm()
            {
                WeatherRequest = reqModel.WeatherRequest,
                WeatherData = await _mediator.Send(reqModel.WeatherRequest)
            };

            return View("Index", resultModel);

        }

    }
}
