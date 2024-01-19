using System;
using System.ComponentModel.DataAnnotations;

namespace service.CustomValidation
{
	public class LongitudeHemisphere : ValidationAttribute
    {
		public LongitudeHemisphere()
        {}

        public override bool IsValid(object? value)
        {
            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if (value.ToString() == "West" || value.ToString() == "East")
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

