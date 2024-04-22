using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Application.Service
{
    public class BithDayService : IEventPeopleService<BirthDay>
    {
        private readonly IEventPeopleRepository<BirthDay> _dataProvider;
        public BithDayService(IEventPeopleRepository<BirthDay> repository) 
        {
            _dataProvider = repository;
        }

        public async Task<IEnumerable<Event>> GetEventsByDays(DateRange days)
        {
            var eventDays = await _dataProvider.GetEventsByDays(days);
            var nameDays = from e in eventDays
                    select new Event(EventType.BirthDay, e.DataBirth, e.Name);
            return nameDays;
        }

        public async Task<IEnumerable<Event>> GetEventsByPerson(string Person)
        {
           var eventPeople = await _dataProvider.GetEventsByPerson(Person);
            var birthDays = from e in eventPeople
                    select new Event(EventType.BirthDay, e.DataBirth, e.Name);
            return birthDays;
        }


    }
}
