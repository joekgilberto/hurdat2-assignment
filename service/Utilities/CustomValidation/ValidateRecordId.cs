using System;
using System.ComponentModel.DataAnnotations;

namespace service.CustomValidation
{
    public class RecordIdAttribute : ValidationAttribute
    {
        public RecordIdAttribute()
        {}

        public override bool IsValid(object? value)
        {
            List<string> validIds = new List<string>() {"n/a","c","g","i","l","p","r","s","t","w"};

            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if(validIds.Contains(value.ToString().ToLower()))
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

