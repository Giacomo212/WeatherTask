using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Common;

namespace WebApplication.Data
{
    public class WeatherForecastService
    {
      
        public async Task<WeatherForecast> GetForecastAsync(string city){
            
            if (string.IsNullOrEmpty(city))
                city = "pszczyna";
            try{
                var assembly = Assembly.LoadFrom("./plugin/net5.0/OpenWeatherPlugin.dll") ;
                foreach (var attribute in assembly.GetCustomAttributes(true)){
                    if (attribute is not WeatherTaskAttribute forecastCreator) continue;
                    var type = forecastCreator.Type;
                    var weatherCreator = Activator.CreateInstance(type);
                    if (weatherCreator is not IGetWeatherTask weatherForecastCreating) continue;
                    var task = weatherForecastCreating.GetWeatherAsync( city.ToLower());
                    var result = await task;
                    return result;
                }
            }
            catch (Exception e){
                return null;
            }
            return null;
        }
    }
}