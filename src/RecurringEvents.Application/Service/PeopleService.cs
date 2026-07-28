using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Service;

public class PeopleService : IEventPeopleService<Person>
{
    public Task<IEnumerable<RecurringEvent>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetEventByPersonRef(string personRefID)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecurringEvent>> GetEventsByPerson(string Person)
    {
        throw new NotImplementedException();
    }
}
