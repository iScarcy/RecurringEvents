using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Application.Service
{
    public class EventService : IRecurringEventService 
    {
        private readonly IRepository<Event> _repository;
        public EventService(IRepository<Event> dataProvider)
        {
            _repository= dataProvider;
        }

        public async Task<IEnumerable<RecurringEvent>> GetAll()
        {
           IEnumerable<Event> events =  await _repository.GetAll();
           var recurringEvents = from e in events
                          select new RecurringEvent(e.EventType, e.DateEvent, e.Description);
           return recurringEvents;
        }

        public async Task<IEnumerable<RecurringEvent>> GetEventsByDays(DateRange days)
        {
            IEnumerable<Event> events = await _repository.GetAll();
            var recurringEvents = from e in events
                                 where (days.From.Month <= e.DateEvent.Date.Month && days.From.Day <= e.DateEvent.Date.Day && days.To.Month > e.DateEvent.Date.Month)
                                 ||
                                 (days.From.Month <= e.DateEvent.Date.Month && days.To.Month == e.DateEvent.Date.Month && days.To.Day >= e.DateEvent.Date.Day)
                                 select new RecurringEvent(e.EventType, e.DateEvent, e.Description);
            return recurringEvents;
        }
    }
}
