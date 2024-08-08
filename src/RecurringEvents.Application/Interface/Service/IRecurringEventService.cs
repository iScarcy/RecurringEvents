namespace RecurringEvents.Application.Interface.Service;

using RecurringEvents.Domain.ValueObject;
//eventi ricorrenti generici
public interface IRecurringEventService
{
    Task<IEnumerable<RecurringEvent>> GetAll();
    Task<IEnumerable<RecurringEvent>> GetEventsByDays(DateRange days);
}
