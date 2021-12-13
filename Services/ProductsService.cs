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
    public class ProductsService 
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductsVM productVM)
        {
            Product product = new Product()
            {
                Name = productVM.Name,
                Brand = productVM.Brand,
                Price = productVM.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            foreach (var id in productVM.OpIds)
            {
                var _product_op = new Product_Op()
                {
                    ProductId = product.Id,
                    OpId = id
                };
                _context.Products_Ops.Add(_product_op);
                _context.SaveChanges();
            }
        }

        public async Task Delete(int id)
        {
            var ProductToDelete = await _context.Products.FindAsync(id);
            _context.Products.Remove(ProductToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(ProductsVM productVM)
        {
            //if(productVM.OpId != null)
            //{
            //    var op = await _context.Ops.FindAsync(productVM.OpId);
            //}

            Product product = new Product()
            {
                Name = productVM.Name,
                Brand = productVM.Brand,
                Price = productVM.Price,
                //OpId = productVM.OpId
            };
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
