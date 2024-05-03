using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Domain.ValueObject;

public class DateRange
{
    [Required]
    public DateTime From { get; set; }

    [Required]
    public DateTime To { get; set; }

    public DateRange(DateTime from, DateTime to)
    {
        if(from > to)
        {
            throw new Exception("Errore, Il from non pu� essere pi� grande del to");
        }
            
        From = from;
        To = to;
    }
}

