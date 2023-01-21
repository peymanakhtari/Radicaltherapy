using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Models
{
    public class DeleteComment
    {
        public int Id { get; set; }
        [Required]
        public int Index { get; set; }
        public string Type { get; set; }
    }
}
