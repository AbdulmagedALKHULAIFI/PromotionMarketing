using Microsoft.EntityFrameworkCore;
using PromotionMarketing.Data;
using PromotionMarketing.Models;
using PromotionMarketing.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Services
{
    public class OpsService 
    {
        private readonly AppDbContext _context;

        public OpsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(OpsVM opsVM)
        {
            //List<Product> products = new List<Product>();
            //foreach(var id in opsVM.ProductsIds)
            //{
            //    products.Add(await _context.Products.FindAsync(id));
            //}

            Op op = new Op()
            {
                Enseigne = opsVM.Enseigne,
                OpName = opsVM.OpName,
                StartDateOperation = opsVM.StartDateOperation,
                EndDateOperation = opsVM.EndDateOperation,
                //Products = products
            };

            _context.Ops.Add(op);
            await _context.SaveChangesAsync();

            ////To get the id of the recent created/added Op 
            //var tmp = await _context.Ops.ToListAsync();
            //foreach(var product in products)
            //{
            //    product.OpId = op.Id;
            //    await _context.SaveChangesAsync();
            //}

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

        public async Task Update(OpsVM opsVM)
        {

            var op = await _context.Ops.FindAsync(opsVM.Id);

            List<Product> products = new List<Product>();

            foreach (var id in opsVM.ProductsIds)
            {
                products.Add(await _context.Products.FindAsync(id));
            }


            op.Enseigne = opsVM.Enseigne;
            op.OpName = opsVM.OpName;
            op.StartDateOperation = opsVM.StartDateOperation;
            op.EndDateOperation = opsVM.EndDateOperation;
            //op.Products = products;
            
            await _context.SaveChangesAsync();
        }
    }
}
