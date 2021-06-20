using System;
namespace Common

{
    public class WeatherTaskAttribute : Attribute
    {
        public Type Type { get; private set; }

        public WeatherTaskAttribute(Type type)
        {
            Type = type;
        }

       
    }
}