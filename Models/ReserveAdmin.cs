using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Models
{
    public class ReserveAdmin
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }

        public string Mobile { get; set; }

        public string Name { get; set; }
        public string Message { get; set; }
        public int? QuestionId { get; set; }

    }
}
