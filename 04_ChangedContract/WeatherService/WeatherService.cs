using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public class WeatherService : IWeatherServiceChanged
    {
        public string GetWeather(DateTime datetime)
        {
            return $"Cloudy at {datetime.Hour}";
        }
    }
}
