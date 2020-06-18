using System.Threading.Tasks;
using Weathery.Service.Weather.Model;

namespace Weathery.Service.Weather
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherFromCity(string city);
    }
}