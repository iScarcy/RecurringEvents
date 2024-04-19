namespace RecurringEvents.Application.Interface.Service;

using RecurringEvents.Domain.ValueObject;
//eventi ricorrenti generici
public interface IRecurringEventService
{

    IEnumerable<Event> GetEventsByRange(DateRange dataRange);
}
