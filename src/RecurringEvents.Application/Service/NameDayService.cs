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
    private readonly IRepository<NameDayDate> _dataRepository;

    public NameDayService(IEventPeopleRepository<NameDayDate> provider, IRepository<NameDayDate> repository)
    {
        _dataProvider = provider;
        _dataRepository = repository;
    }

    public async Task<IEnumerable<Event>> GetAll()
    {
        var eventPeople = await _dataRepository.GetAll();

        return NameDays2Events(eventPeople);
    }

    public async Task<IEnumerable<Event>> GetEventsByDays(DateRange days)
    {
        var eventPeople = await _dataProvider.GetEventsByDays(days);

        return NameDays2Events(eventPeople);
    }

    public async Task<IEnumerable<Event>> GetEventsByPerson(string Person)
    {
        var eventPeople = await _dataProvider.GetEventsByPerson(Person);

        return NameDays2Events(eventPeople);
    }

    private IEnumerable<Event> NameDays2Events(IEnumerable<NameDayDate> eventPeople)
    {
        var nameDays = from e in eventPeople
                       select new Event(EventType.NameDay, e.date, e.personName);

        return nameDays;
    }
}
