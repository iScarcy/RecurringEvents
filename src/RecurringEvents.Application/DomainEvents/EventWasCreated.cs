using MediatR;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Application.DomainEvents
{
    public class EventWasCreated : IRequest
    {
      //  public EventType eventType {get;}
        public string EventID {get;} = Guid.NewGuid().ToString();
        public string EventType {get;} = string.Empty;
      
        public DateTime DateEvent  {get;}
        public string Description   {get;} = string.Empty;
        
        public EventWasCreated(string eventType, DateTime dateEvent, string description)
        {
            this.EventType = eventType;
            this.DateEvent = dateEvent;
            this.Description = description;
                                    
        }
    }
}
