using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace IServices
{
    // add reference System.ServiceModel
    [ServiceContract(Name = "IWeatherService")]
    public interface IWeatherServiceChanged
    {
        [OperationContract]
        string GetWeather(DateTime datetime);
    }
}
