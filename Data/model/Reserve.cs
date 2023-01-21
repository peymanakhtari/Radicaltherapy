using RadicalTherapy.Utility.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class Reserve
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public DateTime Datetime { get; set; }

        [NotContainDash(ErrorMessage = "کارکتر - در شماره نباشد ")]
        [RequiredMobile(ErrorMessage = "شماره واتساپ خود را وارد کنید")]
        [StringLength(maximumLength: 16, MinimumLength = 12, ErrorMessage = " شماره واتساپ اشتباه میباشد")]
        public string Mobile { get; set; }

        [NotContainDash(ErrorMessage = "کارکتر - در نام نباشد ")]
        [Required(ErrorMessage = "نام خود را وارد کنید")]
        public string Name { get; set; }
       // public Question Question { get; set; }
    }
}
