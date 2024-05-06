using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace RecurringEvents.Domain.ValueObject;

public class DateRange : IValidatableObject
{
    [Required]
    public DateTime From { get;  }

    [Required]   
    public DateTime To { get; }

    public DateRange(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
       if(From > To) 
        {
            yield return new ValidationResult(
                ValidationErrors.DateRangeTo,
                new[] { nameof(DateRange) });
        }
        else
        {
            yield return ValidationResult.Success;
        }
    }
}

