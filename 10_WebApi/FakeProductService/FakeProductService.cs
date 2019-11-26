using Bogus;
using IProductService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeProductService
{
    public class FakeProductService : IProductService.IProductService
    {
        private readonly ICollection<Product> products;

        public FakeProductService()
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
        }

        public IEnumerable<Product> Get()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> Get(decimal from, decimal to)
        {
            return products.Where(p => p.UnitPrice >= from && p.UnitPrice <= to).ToList();
        }

        public void Remove(int id)
        {
            products.Remove(Get(id));
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
