using System;
using System.ComponentModel.DataAnnotations;

namespace service.CustomValidation
{
    public class StatusAttribute : ValidationAttribute
    {
        public StatusAttribute()
        {}

        public override bool IsValid(object? value)
        {
            List<string> validStatuses = new List<string>() { "td", "ts", "hu", "ex", "sd", "ss", "lo", "wv", "db" };

            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if (validStatuses.Contains(value.ToString().ToLower()))
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

