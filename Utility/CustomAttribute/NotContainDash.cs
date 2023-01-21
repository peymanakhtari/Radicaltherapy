using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Utility.CustomAttribute
{
    public class NotContainDash : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.ToString().Contains("-"))
            {
                return false;
            }
            return true;
        }
    }
}
