using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Service;

public class ExecutionsService : IExecutionsService
{
    private readonly IExecutionsRepository _executionsRepository;
    public ExecutionsService(IExecutionsRepository executionsRepository)
    {
        _executionsRepository = executionsRepository;;
    }
   
    public async Task<DateTime> GetLastExecution()
    {
        DateTime dateFrom = await _executionsRepository.GetLastExecution();
        return await Task.FromResult(dateFrom);
    }

    public async Task<int> NewExecution(DateRange dateRange)
    {
       int executionID = await _executionsRepository.InsertExecution(dateRange);
       return executionID; 
    }

    public async Task NewExecutionDetails(RecurringEvent infoEvent, int ExecutionID)
    {
        await _executionsRepository.InsertExecutionDetails(infoEvent, ExecutionID);
    }

    public async Task FinishExecution(int Id)
    {
        await _executionsRepository.UpdateExecution(Id);
    }
}
