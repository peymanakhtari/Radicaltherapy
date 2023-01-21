using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string[] Text { get; set; }
        public string[] Answer { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public int subjectId { get; set; }

        [Required]
        public string  NewText { get; set; }
        public string endpoint { get; set; }
        public string p256dh { get; set; }
        public string auth { get; set; }

    }
}
