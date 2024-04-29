using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Repository;

public interface IExecutionsRepository
{
    Task<DateTime> GetLastExecution();

    int InsertExecution(DateRange dateRange);

    void InsertExecutionDetails(Event events, int ExecutionID);
    void UpdateExecution(int Id);
}

