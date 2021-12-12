using PromotionMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Services
{
    public interface IOpsService
    {
        Task<IEnumerable<Op>> Get();
        Task<Op> Get(int id);
        Task<Op> Create(Op book);
        Task Update(Op book);
        Task Delete(int id);
    }
}
