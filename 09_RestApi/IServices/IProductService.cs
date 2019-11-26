using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    [ServiceContract(Namespace = "http://altkom.pl")]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<Product> Get();

        [OperationContract] 
        Product GetById(int id);

        [OperationContract] 
        IEnumerable<Product> GetByPrice(decimal from, decimal to);

        [OperationContract]
        void Add(Product product);

        [OperationContract]
        void Update(Product product);

        [OperationContract]
        void Remove(int id);
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
