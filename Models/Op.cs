using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.Models
{
    public class Op
    {

        public int Id { get; set; }
        public string Enseigne { get; set; }
        public string OpName { get; set; }

        public DateTime? StartDateOperation { get; set; }
        public DateTime? EndDateOperation { get; set; }
        public IPromo Promo { get; set; }

        //Navigations Properties
        public List<Product_Op> Product_Ops { get; set; }
    }
}
