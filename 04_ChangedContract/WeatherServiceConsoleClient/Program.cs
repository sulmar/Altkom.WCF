using IServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WeatherServiceConsoleClient.WeatherService;

namespace WeatherServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetWeatherGeneratedTest();
            GetWeatherTest();
        }

        private static void GetWeatherGeneratedTest()
        {
            WeatherService.WeatherServiceClient client = new WeatherService.WeatherServiceClient();
            string result = client.GetWeather(DateTime.Now);
            Console.WriteLine(result);
        }

        private static void GetWeatherTest()
        {
          
                string url = ConfigurationManager.AppSettings["weather-url"];

                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress endpoint = new EndpointAddress(url);

                ChannelFactory<IWeatherService> proxy = new ChannelFactory<IWeatherService>(binding, endpoint);

                 IWeatherService client = proxy.CreateChannel();

                string result = client.GetWeather(DateTime.Now);

                Console.WriteLine(result);
        }
    }
}
