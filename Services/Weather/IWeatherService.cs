using System.Threading.Tasks;
using Weathery.Services.Weather.Model;

namespace Weathery.Services.Weather
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherFromCity(string city);
    }
}