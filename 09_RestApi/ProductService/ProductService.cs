using Bogus;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    public class ProductService : IProductService
    {
        private readonly ICollection<Product> products;

        public ProductService()
        {
            products = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()))
                .Generate(30);
        }

        public void Add(Product product)
        {
            products.Add(product);

            Uri uri = new Uri($"http://localhost:8080/api/products/{product.Id}");

            WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(uri);
        }

        public IEnumerable<Product> Get() => products;

        public Product GetById(string id)
        {
            Product product = Get(int.Parse(id));

            if (product == null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();

            return product;
        }

        private Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByPrice(decimal from, decimal to)
        {
            return products.Where(p => p.UnitPrice >= from && p.UnitPrice <= to).ToList();
        }

        public void Remove(string id)
        {
            Remove(int.Parse(id));
        }

        private void Remove(int id)
        {
            products.Remove(Get(id));
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
