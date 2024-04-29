using RecurringEvents.Reminder.Models;

namespace RecurringEvents.Reminder.Interface;

public interface IRecurringEventsAPI
{
    Task<DateTime> GetLastExecutions();
}
