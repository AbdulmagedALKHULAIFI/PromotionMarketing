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
    public class PromoController : ControllerBase
    {
        private readonly PromoOneForTwoService _PromoOneForTwoService;

        public PromoController(PromoOneForTwoService PromoOneForTwoService)
        {
            _PromoOneForTwoService = PromoOneForTwoService;
        }

        [HttpGet]
        public async Task<IEnumerable<PromoOneForTwo>> GetPromos()
        {
            return await _PromoOneForTwoService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromoOneForTwo>> GetPromos(int id)
        {
            return await _PromoOneForTwoService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult> PostPromos([FromBody] PromoOneForTwo PromoVM)
        {
            Product product = 
            await _PromoOneForTwoService.Create(PromoVM);
            //return CreatedAtAction(nameof(GetPromos), new { id = newPromo.Id }, newPromo);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutPromos(int id, [FromBody] PromoOneForTwo PromoVM)
        {
            if (id != PromoVM.Id)
            {
                return BadRequest();
            }

            await _PromoOneForTwoService.Update(PromoVM);

            return Ok("Updated successfully ...!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var PromoToDelete = await _PromoOneForTwoService.Get(id);
            if (PromoToDelete == null)
                return NotFound();

            await _PromoOneForTwoService.Delete(PromoToDelete.Id);
            return Ok("Deleted successfully ...!");

        }
    }
}
