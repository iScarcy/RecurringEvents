using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
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
        
        var dateTo =  _context.Executions.Where(x => x.Cancelled == false).Select(x => x.DateTo).OrderByDescending(x => x.Date).FirstOrDefault();
        
        return await Task.FromResult(dateTo);
    }

    public async Task<int> InsertExecution(DateRange dateRange)
    {
        Executions execution = new Executions();
        execution.DateFrom = dateRange.From;
        execution.DateTo = dateRange.To;
        execution.DateStart = DateTime.Now;
        execution.Cancelled = false;
        await _context.Executions.AddAsync(execution);
        _context.SaveChanges();
        return execution.Id;
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
