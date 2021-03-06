﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weathery.Services.Weather.Model;

namespace Weathery.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        const string _baseAddress = @"http://api.openweathermap.org";

        private HttpClient _httpClient;
        private readonly string _appId;

        public WeatherService(
            IConfiguration configuration,
            IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            _appId = configuration["OWA:appid"];
        }

        public async Task<WeatherDTO> GetWeatherFromCity(string city)
        {            
            var response =
                await _httpClient.GetAsync($"/data/2.5/weather?q={city}&appid={_appId}");
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherDTO>(stringResult);
        }
    }
}
