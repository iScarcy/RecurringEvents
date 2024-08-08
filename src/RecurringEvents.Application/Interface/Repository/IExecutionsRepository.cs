using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Repository;

public interface IExecutionsRepository
{
    Task<DateTime> GetLastExecution();

    Task<int> InsertExecution(DateRange dateRange);

    Task InsertExecutionDetails(RecurringEvent infoEvent, int executionID);
    Task UpdateExecution(int Id);
}

