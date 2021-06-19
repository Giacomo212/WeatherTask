using System;

namespace Common
{
    public class WeatherForecast
    {
        public WeatherForecast(string city, string temperature, string summary){
            City = city;
            Temperature = temperature;
            Summary = summary;
        }

        public string City { get; set; }

        public string Temperature { get; set; }
        
        public string Summary { get; set; }
    }
}