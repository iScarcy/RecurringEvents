using RecurringEvents.Domain.ValueObject;


namespace RecurringEvents.Application.Interface.Service
{
    //Eventi legati ad una persona
    public interface IEventPeopleService<T> : IRecurringEventService where T : class
    {
       Task<IEnumerable<RecurringEvent>> GetEventsByPerson(string Person);

       Task<T> GetEventByPersonRef(string personRefID);

      Task ChangeDate(string personRefID, DateTime dateEvent);

    }
}
