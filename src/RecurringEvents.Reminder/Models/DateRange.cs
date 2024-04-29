using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecurringEvents.Reminder.Models;

public record DateRange (
    [Required] [property: JsonPropertyName("from")] DateTime From, 
    [Required] [property: JsonPropertyName("to")] DateTime To);

