using RecurringEvents.Domain.ValueObject;


namespace RecurringEvents.Application.Interface.Service
{
    //Eventi legati ad una persona
    public interface IEventPeopleService<T> where T : class  
    {
       Task<IEnumerable<T>> GetEventsByPerson(string Person);
    }
}
