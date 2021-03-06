using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Models
{
    public class Product
    {
        public int Id{ get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        //Navigations Properties
        public List<Product_Op> Product_Ops { get; set; }
    }
}
