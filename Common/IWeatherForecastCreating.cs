using System;
using System.Threading.Tasks;

namespace Common
{
    public interface IWeatherForecastCreating
    {
        public Task<WeatherForecast> GetWeatherAsync(string city);
    }
}