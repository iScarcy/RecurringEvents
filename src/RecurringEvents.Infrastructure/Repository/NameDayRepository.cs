using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Repository;

public class NameDayRepository : INameDayRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NameDayRepository(ApplicationDbContext dbContext){
        _dbContext = dbContext;
    }
    public Task Delete(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<NameDay>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<NameDay>> GetByDateRange(DateRange rangeDate)
    {
        throw new NotImplementedException();
    }

    public Task<NameDay> GetByID(int ID)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(NameDay entity)
    {
         _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task Update(NameDay entity)
    {
        throw new NotImplementedException();
    }

    IEnumerable<NameDay> IRepository<NameDay, Guid>.GetAll()
    {
        throw new NotImplementedException();
    }
}
