using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.ViewModel
{
    public class ProductsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public List<int> OpIds { get; set; }
    }
}
