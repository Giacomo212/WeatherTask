using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Common;

namespace WebApplication.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            var assembly = Assembly.LoadFrom("./plugin/OpenWeatherPlugin.dll") ;
            foreach (var attribute in assembly.GetCustomAttributes(true)){
                if (attribute is WeatherBuilderAttribute forecastCreator){
                    var type = forecastCreator.Type;
                    var weatherCreator = Activator.CreateInstance(type);
                    if (weatherCreator is IWeatherForecastCreating weatherForecastCreating){
                        var task = weatherForecastCreating.GetWeatherAsync( "pszczyna");
                        var result = await task;
                        return new[]{result};
                    }
                }
            }

            return null;
        }
    }
}