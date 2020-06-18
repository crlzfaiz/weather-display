using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Weathery.Service.Weather.Model;

namespace Weathery.Service.Weather
{
    public class WeatherService : IWeatherService
    {
        const string _baseAddress = @"http://api.openweathermap.org";

        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;

        public WeatherService(
            IConfiguration configuration,
            IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<WeatherDTO> GetWeather()
        {
            return new WeatherDTO();
        }
    }
}
