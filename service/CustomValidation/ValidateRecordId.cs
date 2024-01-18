using System;
using System.ComponentModel.DataAnnotations;
using service.Models;

namespace service.Middleware
{
    public class RecordIdAttribute : ValidationAttribute
    {
        public RecordIdAttribute()
        {}

        public override bool IsValid(object? value)
        {
            List<string> validIds = new List<string>() {"c","g","i","l","p","r","s","t","w"};

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

