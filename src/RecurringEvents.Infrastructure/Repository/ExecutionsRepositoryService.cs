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
        var dateTo = _context.Executions.Where(x => x.Cancelled == false).Select(x => x.DateTo).OrderByDescending(x => x.Date).FirstOrDefault();
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

    public async Task InsertExecutionDetails(Event infoEvent, int executionID)
    {
        ExecutionsDetails executionsDetails = new ExecutionsDetails();
        executionsDetails.EventType = infoEvent.type;
        executionsDetails.DateEvent = infoEvent.date;
        executionsDetails.Description = infoEvent.description;
        executionsDetails.ExecutionsId = executionID;
        await _context.ExecutionsDetails.AddAsync(executionsDetails);
        _context.SaveChanges();
    }

    public async Task UpdateExecution(int Id)
    {
        var exec = await _context.Executions.Where(x => x.Id == Id).FirstOrDefaultAsync<Executions>();
        if (exec != null)
        {
            exec.DateEnd = DateTime.Now;
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("UpdateExecution non è stato trovata nessuna exec da aggionare");
        }
    }
}
