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

    public int NewExecution(DateRange dateRange)
    {
        throw new NotImplementedException();
    }

    public void NewExecutionDetails(List<Event> events, int ExecutionID)
    {
        throw new NotImplementedException();
    }
}
