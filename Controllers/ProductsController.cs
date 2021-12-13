using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionMarketing.Models;
using PromotionMarketing.Services;
using PromotionMarketing.ViewModel;
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
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
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
        public async Task<ActionResult> PostProducts([FromBody] ProductsVM productVM)
        {
            await _productsService.Create(productVM);
            //return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutProducts(int id, [FromBody] ProductsVM productVM)
        {
            if (id != productVM.Id)
            {
                return BadRequest();
            }

            await _productsService.Update(productVM);

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
