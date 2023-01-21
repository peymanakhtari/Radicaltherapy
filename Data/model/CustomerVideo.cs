using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class CustomerVideo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int? Sequence { get; set; }
    }
}
