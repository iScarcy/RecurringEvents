namespace RecurringEvents.Application.Interface.Service;

using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
//eventi ricorrenti generici
public interface IRecurringEventService
{
    Task<IEnumerable<RecurringEvent>> GetAll();
    Task<IEnumerable<EventTypes>> GetEventTypes();
    Task<RecurringEvent> GetEventByID(string objID);
    Task UpdateEvent(string objID, Event eventToUpdate);
    Task DeleteEvent(string objID);
}
