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
    public class PromoOneForTwoService
    {
        private readonly AppDbContext _context;

        public PromoOneForTwoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(PromoOneForTwo promo)
        {
            //PromoOneForTwo promo = new PromoOneForTwo()
            //{
            //    PriceAfterDiscount = 2 * productVM.Price / 3,
            //};

            _context.PromoOnesForTwos.Add(promo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var PromotToDelete = await _context.PromoOnesForTwos.FindAsync(id);
            _context.PromoOnesForTwos.Remove(PromotToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PromoOneForTwo>> Get()
        {
            return await _context.PromoOnesForTwos.ToListAsync();
        }

        public async Task<PromoOneForTwo> Get(int id)
        {
            return await _context.PromoOnesForTwos.FindAsync(id);
        }

        public async Task Update(PromoOneForTwo promo)
        {
            if(promo != null)
            {
                _context.Entry(promo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
