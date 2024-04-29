using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Service;

public interface IExecutionsService
{
    Task<DateTime> GetLastExecution();

    int NewExecution(DateRange dateRange);

    void NewExecutionDetails(List<Event> events, int ExecutionID);
    void FinishExecution(int Id);
}
