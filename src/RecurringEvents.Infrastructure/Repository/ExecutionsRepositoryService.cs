using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Repository;

public class ExecutionsRepositoryService : IExecutionsRepository
{
    private readonly ApplicationDbContext _context;

    public ExecutionsRepositoryService(ApplicationDbContext context)
    {
        _context = context;
    }
 
    public async Task<DateTime> GetLastExecution()
    {
        
        var dateTo =  _context.Executions.Select(x => x.DateTo).OrderByDescending(x => x.Date).FirstOrDefault();
        
        return await Task.FromResult(dateTo);
    }

    public int InsertExecution(DateRange dateRange)
    {
        throw new NotImplementedException();
    }

    public void InsertExecutionDetails(Event events, int ExecutionID)
    {
        throw new NotImplementedException();
    }

    public void UpdateExecution(int Id)
    {
        throw new NotImplementedException();
    }
}
