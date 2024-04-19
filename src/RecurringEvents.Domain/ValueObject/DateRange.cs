using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Domain.ValueObject;

public record DateRange ([Required] DateTime From, [Required] DateTime To)
{
    
}

