using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Models
{
    public class Product_Op
    {

        public int Id{ get; set; }

        public int ProductId{ get; set; }
        public Product Product{ get; set; }

        public int OpId { get; set; }
        public Op Op { get; set; }

    }
}
