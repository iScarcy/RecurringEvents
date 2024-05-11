namespace RecurringEvents.Application.Interface.Service;

using RecurringEvents.Domain.ValueObject;
//eventi ricorrenti generici
public interface IRecurringEventService
{
    Task<IEnumerable<Event>> GetAll();
    Task<IEnumerable<Event>> GetEventsByDays(DateRange days);
}
