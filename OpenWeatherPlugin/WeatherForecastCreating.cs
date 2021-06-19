using System;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Common;
using OpenWeatherPlugin;

[assembly: WeatherBuilder(typeof(WeatherForecastCreating))]

namespace OpenWeatherPlugin
{
    public class WeatherForecastCreating : IWeatherForecastCreating
    {
        public async Task<WeatherForecast> GetWeatherAsync( string city)
        {
           
            var client = new HttpClient();
            var responseMessage = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={DotEnv.Key}");
            responseMessage.EnsureSuccessStatusCode();
            var body = await responseMessage.Content.ReadAsStringAsync();
            dynamic data = JsonSerializer.Deserialize<ExpandoObject>(body);
            dynamic weather = JsonSerializer.Deserialize<ExpandoObject>(data.weather[0].ToString()) ;
            dynamic main = JsonSerializer.Deserialize<ExpandoObject> (data.main.ToString() ) ;
            return new WeatherForecast(city,main.temp.ToString() ,weather.main.ToString());
        }
    }
}