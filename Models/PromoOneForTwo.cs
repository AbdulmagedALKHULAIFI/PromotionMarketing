using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Models
{
    public class PromoOneForTwo
    {
        public int Id { get; set; }
        public int PriceAfterDiscount { get; set; }

        public Op op { get; set; }
    }
}
