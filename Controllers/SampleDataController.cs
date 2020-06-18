using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Weathery.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {        
        private readonly IConfiguration _configuration;
        private readonly string _appId;
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public SampleDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _appId = _configuration["OWA:appid"];
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

        //[HttpPost]
        //public async Task<IActionResult> WeatherByCity(string city)
        //{
        //    //TODO: sanitize string city input
        //    string requestString = $"/data/2.5/weather?q={city}&appid={_appId}";
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            client.BaseAddress = new Uri(_baseAddress);
        //            var response =
        //                await client.PostAsync(requestString);
        //        }
        //        catch ()
        //        {

        //        }
        //    }
        //}

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
    }
}
