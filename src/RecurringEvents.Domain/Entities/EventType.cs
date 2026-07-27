using System.ComponentModel.DataAnnotations.Schema;

namespace RecurringEvents.Domain.Entities;

[Table("EventTypes")]
public class EventTypes
{
    public int ID { get; set; }
    public string EventType { get; set; } = string.Empty;
    public int EntityType { get; set; }
}
