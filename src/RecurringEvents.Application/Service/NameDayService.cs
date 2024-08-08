using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Application.Service;

public class NameDayService : IEventPeopleService<NameDay>
{
    private readonly IEventPeopleRepository<NameDay> _dataProvider;

    public NameDayService(IEventPeopleRepository<NameDay> provider)
    {
        _dataProvider = provider;
    }

    

    public Task ChangeDate(string personRefID, DateTime dateEvent)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RecurringEvent>> GetAll()
    {
        var eventPeople = await _dataProvider.GetAll();

        return NameDays2Events(eventPeople);
    }

    public Task<NameDay> GetEventByPersonRef(string personRefID)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RecurringEvent>> GetEventsByDays(DateRange days)
    {
        var eventPeople = await _dataProvider.GetEventsByDays(days);

        return NameDays2Events(eventPeople);
    }

    public async Task<IEnumerable<RecurringEvent>> GetEventsByPerson(string Person)
    {
        var eventPeople = await _dataProvider.GetEventsByPerson(Person);

        return NameDays2Events(eventPeople);
    }

    private IEnumerable<RecurringEvent> NameDays2Events(IEnumerable<EventPeople> eventPeople)
    {
        var nameDays = from e in eventPeople
                       select new RecurringEvent(EventType.NameDay, e.date, e.personName);

        return nameDays;
    }
}
