using System;
using System.ComponentModel.DataAnnotations;

namespace service.CustomValidation
{
    public class LatitudeHemisphere : ValidationAttribute
    {
        public LatitudeHemisphere()
        {}

        public override bool IsValid(object? value)
        {
            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if (value.ToString() == "North" || value.ToString() == "South")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

