using RecurringEvents.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Web.Validation.Validators
{
    public class DateEventAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime dateRange = (DateTime)value;
            if (dateRange.Year < 1900)
                return false;

            return true;

        }
    }
}
