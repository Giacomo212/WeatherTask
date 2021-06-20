using System;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Common;

namespace ConsoleTest{
    class Program{
        static async Task Main(string[] args){
            
            var assembly = Assembly.LoadFrom("./plugin/OpenWeatherPlugin.dll") ;
            foreach (var attribute in assembly.GetCustomAttributes(true)){
                if (attribute is WeatherTaskAttribute forecastCreator){
                    var type = forecastCreator.Type;
                    var weatherCreator = Activator.CreateInstance(type);
                    if (weatherCreator is IGetWeatherTask weatherForecastCreating){
                        var task = weatherForecastCreating.GetWeatherAsync( "pszczyna");
                        var result = await task;
                        Console.WriteLine("The weather in {0} is {1}, temperature {2}",result.City,result.Summary,result.Temperature);
                    }
                }
            }
          
        }
        
    }
}