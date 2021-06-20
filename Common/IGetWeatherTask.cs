using System;
using System.Threading.Tasks;

namespace Common
{
    public interface IGetWeatherTask
    {
        public Task<WeatherForecast> GetWeatherAsync(string city);
    }
}