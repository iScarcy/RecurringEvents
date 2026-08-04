using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Web.Models
{
    public class EventRequest
    {
        public string EventID { set; get; } = string.Empty;
        public string EventTypeDescription { set; get; }
        public DateTime DateEvent { set; get; }
        public string Description { set; get; } = string.Empty;
    }
}
