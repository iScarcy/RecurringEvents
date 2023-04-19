namespace RecurringEvents.Application.Interface.Service;

using RecurringEvents.Domain.Primitives;
using RecurringEvents.Domain.ValueObject;
public interface IRecurringEventService
{
    IEnumerable<Event> GetEvents(DateRange date);
}
