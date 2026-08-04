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
        private readonly IRepository<RecurringEvent> _recurringEventRepository;
        private readonly IRepository<EventTypes> _eventTypesRepository;
        public EventService(IRepository<Event> dataProvider, IRepository<RecurringEvent> recurringEventRepository, IRepository<EventTypes> eventTypesRepository)
        {
            _repository= dataProvider;
            _recurringEventRepository = recurringEventRepository;
            _eventTypesRepository = eventTypesRepository;
        }

        /* 
        public async Task ChangeDate(string objID, DateTime dateEvent)
        {
          int ID = Int32.Parse(objID);
          W_Event nvt = await _repository.GetByID(ID);
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
        */
        public async Task<IEnumerable<RecurringEvent>> GetAll()
        {
           IEnumerable<RecurringEvent> events =  await _recurringEventRepository.GetAll();
           return events;
        }
 

        public  async Task<IEnumerable<EventTypes>> GetEventTypes()
        {
            IEnumerable<EventTypes> eventTypes = await _eventTypesRepository.GetAll();
            return eventTypes;
        }

        public Task UpdateEvent(string objID, Event eventToUpdate)
        {
             var eventItem = _repository.GetValueAsync("EventID", objID)?.Result;
             if(eventItem == null)
             {
                 throw new Exception("Evento non trovato");
             }
             
             eventItem.DateEvent = eventToUpdate.DateEvent;
             eventItem.Description = eventToUpdate.Description;
             eventItem.EventType = eventToUpdate.EventType;

             return _repository.Update(eventItem);
        }

        Task<RecurringEvent> IRecurringEventService.GetEventByID(string objID)
        {
            var eventItem = _recurringEventRepository.GetValueAsync("EventID", objID)?.Result;
            if(eventItem == null)
            {
                throw new Exception("Evento non trovato");
            }
            return Task.FromResult(eventItem);
        }
        /*
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
}*/
    }
}
