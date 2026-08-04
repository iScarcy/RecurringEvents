using MediatR;

namespace RecurringEvents.Application.DomainEvents
{
    public class EventWasUpdated : IRequest
    {
            public string EventID {get;} = string.Empty;
            public string EventType {get;} = string.Empty;
        
            public DateTime DateEvent  {get;}
            public string Description   {get;} = string.Empty;
            
            public EventWasUpdated(string EventID, string eventType, DateTime dateEvent, string description)
            {
                this.EventID = EventID;
                this.EventType = eventType;
                this.DateEvent = dateEvent;
                this.Description = description;
                                        
            }
    }
}
