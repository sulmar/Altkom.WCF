using IProductService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProductServiceHost.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService.IProductService productService;

        public ProductsController(IProductService.IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.Get();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productService.Get();

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            productService.Update(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productService.Remove(id);

            return Ok();
        }
    }
}
