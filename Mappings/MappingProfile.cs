using AutoMapper;
using Weathery.Models;
using Weathery.Services.Weather.Model;

namespace Weathery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherDTO, WeatherModel>().ReverseMap();
        }
    }
}
