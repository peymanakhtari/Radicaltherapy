using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class Statistics
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string IP { get; set; }
        [MaxLength(50)]
        public string OS { get; set; }
        public DateTime datetime { get; set; }


    }
}
