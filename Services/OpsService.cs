using Microsoft.EntityFrameworkCore;
using PromotionMarketing.Data;
using PromotionMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Services
{
    public class OpsService : IOpsService
    {
        private readonly AppDbContext _context;

        public OpsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Op> Create(Op op)
        {
            _context.Ops.Add(op);
            await _context.SaveChangesAsync();

            return op;
        }

        public async Task Delete(int id)
        {
            var OpToDelete = await _context.Ops.FindAsync(id);
            _context.Ops.Remove(OpToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Op>> Get()
        {
            return await _context.Ops.ToListAsync();
        }

        public async Task<Op> Get(int id)
        {
            return await _context.Ops.FindAsync(id);
        }

        public async Task Update(Op op)
        {
            _context.Entry(op).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
