using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Service;

public interface IExecutionsService
{
    Task<DateTime> GetLastExecution();

    Task<int> NewExecution(DateRange dateRange);

    void NewExecutionDetails(Event infoEvent, int ExecutionID);
    void FinishExecution(int Id);
}
