using PromotionMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task<Product> Create(Product book);
        Task Update(Product book);
        Task Delete(int id);
    }
}
