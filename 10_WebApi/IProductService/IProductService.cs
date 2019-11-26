using System;
using System.Collections.Generic;

namespace IProductService
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        IEnumerable<Product> Get(decimal from, decimal to);
        void Add(Product product);
        void Update(Product product);
        void Remove(int id);
    }
}
