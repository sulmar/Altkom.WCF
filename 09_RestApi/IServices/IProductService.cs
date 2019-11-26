using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    [ServiceContract(Namespace = "http://altkom.pl")]
    public interface IProductService
    {
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json,
            UriTemplate ="api/products")]
        IEnumerable<Product> Get();

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/products/{id}")]

        Product GetById(string id);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, 
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/products?from={from}&to={to}")]
        IEnumerable<Product> GetByPrice(decimal from, decimal to);

        [OperationContract]
        [WebInvoke(Method = "POST", 
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/products")]
        void Add(Product product);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/products")]
        void Update(Product product);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/products/{id}")]
        void Remove(string id);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
