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
        private readonly IRepository<BirthDay> _dataRepository;
        public BithDayService(IEventPeopleRepository<BirthDay> provider, IRepository<BirthDay> repository) 
        {
            _dataProvider = provider;
            _dataRepository = repository;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var eventPeople = await _dataRepository.GetAll();
            var birthDays = from e in eventPeople
                    select new Event(EventType.BirthDay, e.DataBirth, e.Name);
            return birthDays;
        }

        public async Task<IEnumerable<Event>> GetEventsByDays(DateRange days)
        {
            var eventPeople = await _dataProvider.GetEventsByDays(days);
            var birthDays = from e in eventPeople
                    select new Event(EventType.BirthDay, e.DataBirth, e.Name);
            return birthDays;
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
