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
    public class BithDayService : IEventPeopleService<BirthDay>
    {
        private readonly IEventPeopleRepository<BirthDay> _dataProvider;
        public BithDayService(IEventPeopleRepository<BirthDay> provider) 
        {
            _dataProvider = provider;
        }

        public async Task ChangeDate(string personRefID, DateTime dateEvent)
        {
           if(string.IsNullOrWhiteSpace(personRefID))
                throw new ArgumentNullException(nameof(personRefID));

           await _dataProvider.ChangeEventDate(personRefID, dateEvent);
        }

        public async Task<IEnumerable<RecurringEvent>> GetAll()
        {
            
            var eventPeople = await _dataProvider.GetAll();
            var birthDays = from e in eventPeople
                    select new RecurringEvent(EventType.BirthDay, e.date, e.personName);

            return birthDays;
        }

        public async Task<BirthDay> GetEventByPersonRef(string personRefID)
        {
           if(string.IsNullOrWhiteSpace(personRefID))
                throw new ArgumentNullException(nameof(personRefID));
           
           return await _dataProvider.GetEventByPersonRef(personRefID);
        }

        public async Task<IEnumerable<RecurringEvent>> GetEventsByDays(DateRange days)
        {
            var eventPeople = await _dataProvider.GetEventsByDays(days);
            var birthDays = from e in eventPeople
                    select new RecurringEvent(EventType.BirthDay, e.date, e.personName);

            return birthDays;
        }

        public async Task<IEnumerable<RecurringEvent>> GetEventsByPerson(string Person)
        {
           var eventPeople = await _dataProvider.GetEventsByPerson(Person);
           var birthDays = from e in eventPeople
                    select new RecurringEvent(EventType.BirthDay, e.date, e.personName);

            return birthDays;
        }


    }
}
