using RecurringEvents.Reminder.Models;

namespace RecurringEvents.Reminder.Interface;

public interface IRecurringEventsAPI
{
    Task<DateTime> GetLastExecutions();

    Task<int> StartExecution(DateRange date);

    Task<IEnumerable<Event>> GetEvents(DateRange date);

    Task InsertExecutionDetails(Event infoEvent, int ExecutionsID);

    Task FinishExecution(int ExecutionsID);
}
