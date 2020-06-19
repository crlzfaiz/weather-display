using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Weathery.Models;
using Weathery.Services.Weather;

namespace Weathery.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private IWeatherService _weatherService;
        private readonly IMapper _mapper;
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherController(
            IWeatherService weatherService,
            IMapper mapper)
        {
            _weatherService = weatherService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> GetWeatherFromCity(string city)
        {
            try
            {
                // Sanitize string input
                var dto = await _weatherService.GetWeatherFromCity(city);
                var model = _mapper.Map<WeatherModel>(dto);

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
