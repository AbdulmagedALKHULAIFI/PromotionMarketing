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

        public DateTime? StartDateOperation { get; set; }
        public DateTime? EndDateOperation { get; set; }
    }
}
