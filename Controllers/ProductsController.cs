using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionMarketing.Models;
using PromotionMarketing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productsService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _productsService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts([FromBody] Product product)
        {
            var newProduct = await _productsService.Create(product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> PutProducts(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productsService.Update(product);

            return Ok("Updated successfully ...!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productsService.Get(id);
            if (productToDelete == null)
                return NotFound();

            await _productsService.Delete(productToDelete.Id);
            return Ok("Deleted successfully ...!");

        }
    }
}
