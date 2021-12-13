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
    public class OpsController : ControllerBase
    {
        private readonly OpsService _opsService;


        public OpsController(OpsService opsService)
        {
            _opsService = opsService;
        }

        [HttpPost]
        public async Task<ActionResult> PostOps([FromBody] OpsVM opsVM)
        {
            await _opsService.Create(opsVM);
            //return CreatedAtAction(nameof(GetOps), new { id = newOp.Id }, newOp);
            return Ok();
        }


        [HttpGet]
        public async Task <IEnumerable<Op>> GetOps()
        {
            return await _opsService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Op>> GetOps(int id)
        {
            return await _opsService.Get(id);
        }



        [HttpPut]
        public async Task<ActionResult> PutOps(int id, [FromBody] OpsVM opsVM)
        {
            if (id != opsVM.Id)
            {
                return BadRequest();
            }

            await _opsService.Update(opsVM);

            return Ok("Updated successfully ...!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var opToDelete = await _opsService.Get(id);
            if (opToDelete == null)
                return NotFound();

            await _opsService.Delete(opToDelete.Id);
            return Ok("Deleted successfully ...!");

        }
    }
}
