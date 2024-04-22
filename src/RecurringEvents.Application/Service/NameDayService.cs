using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Application.Service;

public class NameDayService : IEventPeopleService<NameDayDate>
    {
        private readonly IEventPeopleRepository<NameDayDate> _dataProvider;
        

        public NameDayService(IEventPeopleRepository<NameDayDate> repository) 
        {
            _dataProvider = repository;
        }

    public Task<IEnumerable<Event>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Event>> GetEventsByDays(DateRange days)
    {
         var eventPeople = await _dataProvider.GetEventsByDays(days);
           
            var nameDays = from e in eventPeople
                    select new Event (EventType.NameDay, e.date, e.personName);
           
            return nameDays;
    }

    public async Task<IEnumerable<Event>> GetEventsByPerson(string Person)
        {
           var eventPeople = await _dataProvider.GetEventsByPerson(Person);
           
            var nameDays = from e in eventPeople
                    select new Event (EventType.NameDay, e.date, e.personName);
           
            return nameDays;
        }


    }
