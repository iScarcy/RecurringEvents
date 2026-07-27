namespace RecurringEvents.Application.Interface.Service;

using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
//eventi ricorrenti generici
public interface IRecurringEventService
{
    Task<IEnumerable<Event>> GetAll();
   // Task<IEnumerable<Event>> GetEventsByDays(DateRange days);

   // Task ChangeDate(string objID, DateTime dateEvent);
}
