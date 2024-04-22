using RecurringEvents.Domain.ValueObject;


namespace RecurringEvents.Application.Interface.Service
{
    //Eventi legati ad una persona
    public interface IEventPeopleService<T> : IRecurringEventService<T> where T : class
    {
       Task<IEnumerable<Event>> GetEventsByPerson(string Person);

       
    }
}
