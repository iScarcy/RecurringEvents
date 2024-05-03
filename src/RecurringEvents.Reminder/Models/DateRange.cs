using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecurringEvents.Reminder.Models;


public class DateRange
{
    [Required]
    [property: JsonPropertyName("from")]
    public DateTime From { get; set; }

    [Required]
    [property: JsonPropertyName("to")]
    public DateTime To { get; set; }

    public DateRange(DateTime from, DateTime to)
    {
        if (from > to)
        {
            throw new Exception("Errore, Il from non può essere più grande del to");
        }

        From = from;
        To = to;
    }
}
