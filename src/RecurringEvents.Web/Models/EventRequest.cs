using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Web.Models
{
    public class EventRequest
    {
        public EventTypes EventType { set; get; }
        public DateTime DateEvent { set; get; }
        public string Description { set; get; } = string.Empty;
    }
}
