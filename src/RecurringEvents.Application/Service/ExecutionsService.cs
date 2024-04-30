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
    public void FinishExecution(int Id)
    {
        throw new NotImplementedException();
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

    public async Task NewExecutionDetails(Event infoEvent, int ExecutionID)
    {
        await _executionsRepository.InsertExecutionDetails(infoEvent, ExecutionID);
    }

    Task IExecutionsService.FinishExecution(int Id)
    {
        throw new NotImplementedException();
    }
}
