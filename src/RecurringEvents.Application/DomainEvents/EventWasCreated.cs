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
        public EventType eventType {get;}
        public DateTime dateEvent  {get;}
        public string description  {get;} 
      
        public EventWasCreated(EventType eventType, DateTime dateEvent, string des)
        {
            this.eventType = eventType;
            this.dateEvent = dateEvent; 
            this.description = des;
        }
    }
}
