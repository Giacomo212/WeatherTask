using System;

namespace Common
{
    public class WeatherForecast
    {
        public WeatherForecast(string city, string temperature, string summary, string imageName){
            City = city;
            Temperature = temperature;
            Summary = summary;
            ImageName = imageName;
        }

        public string ImageName{ get; private set; }
        public string City { get; private set; }

        public string Temperature { get; private set; }
        
        public string Summary { get; private set; }
    }
}