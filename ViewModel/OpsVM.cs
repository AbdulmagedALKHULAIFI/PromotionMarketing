using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionMarketing.ViewModel
{
    public class OpsVM
    {
        public int Id { get; set; }
        public string Enseigne { get; set; }
        public string OpName { get; set; }

        public DateTime? StartDateOperation { get; set; }
        public DateTime? EndDateOperation { get; set; }

        public List<int> ProductsIds { get; set; }
    }
}
