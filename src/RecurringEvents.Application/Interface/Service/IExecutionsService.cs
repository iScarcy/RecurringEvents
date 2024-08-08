using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Service;

public interface IExecutionsService
{
    Task<DateTime> GetLastExecution();
    Task<int> NewExecution(DateRange dateRange);
    Task NewExecutionDetails(RecurringEvent infoEvent, int ExecutionID);
    Task FinishExecution(int Id);
}
