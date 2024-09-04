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

        public async Task ChangeDate(string objID, DateTime dateEvent)
        {
          int ID = Int32.Parse(objID);
          Event nvt = await _repository.GetByID(ID);
          if (nvt != null) 
          {
                nvt.DateEvent = dateEvent;
                await _repository.Update(nvt);
            }
            else
            {
                throw new Exception("Evento non trovato");
            }
        }

        public async Task<IEnumerable<RecurringEvent>> GetAll()
        {
           IEnumerable<Event> events =  await _repository.GetAll();
           var recurringEvents = from e in events
                          select new RecurringEvent(e.Id.ToString(), e.EventType, e.DateEvent, e.Description);
           return recurringEvents;
        }

        public async Task<IEnumerable<RecurringEvent>> GetEventsByDays(DateRange days)
        {
            IEnumerable<Event> events = await _repository.GetAll();           
            var recurringEvents = from x in events
                            where
                               (new DateTime(1900, x.DateEvent.Month, x.DateEvent.Day)).CompareTo((new DateTime(1900, days.From.Month, days.From.Day))) >= 0
                               &&
                               (new DateTime(1900, x.DateEvent.Month, x.DateEvent.Day)).CompareTo((new DateTime(1900, days.To.Month, days.To.Day))) <= 0
                            select new RecurringEvent(x.Id.ToString(), x.EventType, x.DateEvent, x.Description);

            return recurringEvents;
        }
    }
}
