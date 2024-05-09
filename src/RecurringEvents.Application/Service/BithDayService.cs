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
    public class BithDayService : IEventPeopleService<BirthDayDate>
    {
        private readonly IEventPeopleRepository<BirthDayDate> _dataProvider;
        public BithDayService(IEventPeopleRepository<BirthDayDate> provider) 
        {
            _dataProvider = provider;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var eventPeople = await _dataProvider.GetAll();
            var birthDays = from e in eventPeople
                    select new Event(EventType.BirthDay, e.date, e.personName);

            return birthDays;
        }

        public async Task<IEnumerable<Event>> GetEventsByDays(DateRange days)
        {
            var eventPeople = await _dataProvider.GetEventsByDays(days);
            var birthDays = from e in eventPeople
                    select new Event(EventType.BirthDay, e.date, e.personName);

            return birthDays;
        }

        public async Task<IEnumerable<Event>> GetEventsByPerson(string Person)
        {
           var eventPeople = await _dataProvider.GetEventsByPerson(Person);
           var birthDays = from e in eventPeople
                    select new Event(EventType.BirthDay, e.date, e.personName);

            return birthDays;
        }


    }
}
