using AutoMapper;
using Model = Weathery.Models;
using DTO = Weathery.Services.Weather.Model;

namespace Weathery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region WeatherMapping

            CreateMap<DTO.Coord, Model.Coord>()
                .ForMember(dest => dest.Longtitude, opt => opt.MapFrom(src => src.Lon))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Lat));
            CreateMap<DTO.Main, Model.Main>();
            CreateMap<DTO.Weather, Model.Weather>();
            CreateMap<DTO.Wind, Model.Wind>();
            CreateMap<DTO.Clouds, Model.Clouds>();
            CreateMap<DTO.WeatherDTO, Model.WeatherModel>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name));

            #endregion
        }
    }
}
