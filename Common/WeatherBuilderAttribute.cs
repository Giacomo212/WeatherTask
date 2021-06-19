using System;
namespace Common

{
    public class WeatherBuilderAttribute : Attribute
    {
        public Type Type { get; private set; }

        public WeatherBuilderAttribute(Type type)
        {
            Type = type;
        }

       
    }
}