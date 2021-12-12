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
    public class OpsController : ControllerBase
    {
        private readonly IOpsService _opsService;


        public OpsController(IOpsService opsService)
        {
            _opsService = opsService;
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

        [HttpPost]
        public async Task<ActionResult<Op>> PostOps([FromBody] Op op)
        {
            var newOp = await _opsService.Create(op);
            return CreatedAtAction(nameof(GetOps), new { id = newOp.Id }, newOp);
        }

        [HttpPut]
        public async Task<ActionResult> PutOps(int id, [FromBody] Op op)
        {
            if (id != op.Id)
            {
                return BadRequest();
            }

            await _opsService.Update(op);

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
