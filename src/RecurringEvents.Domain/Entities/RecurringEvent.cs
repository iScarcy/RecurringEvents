using System.ComponentModel.DataAnnotations.Schema;

namespace RecurringEvents.Domain.Entities;

[Table("W_Events")]
public class RecurringEvent
{
    public string EventID { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateEvent { get; set; }
    public int EventType { get; set; }
  
}
