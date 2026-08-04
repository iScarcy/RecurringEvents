using System.ComponentModel.DataAnnotations.Schema;

namespace RecurringEvents.Domain.Entities;

[Table("Events")]
public class Event
{
   public string EventID { get; set; } = string.Empty;
   public int EventType { get; set; }
   public DateTime DateEvent { get; set; }
   public string Description { get; set; } = string.Empty;
  
}
