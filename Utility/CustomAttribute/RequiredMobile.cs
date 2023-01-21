using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Utility.CustomAttribute
{
    public class RequiredMobile : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string newvalue;
            if (value != null)
            {
                newvalue = value.ToString().Remove(0, 3);
            }
            else
            {
                newvalue = (string)value;
            }
            if (newvalue != "" && newvalue != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
