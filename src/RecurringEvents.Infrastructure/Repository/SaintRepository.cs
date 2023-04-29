using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Repository;

public class SaintRepository : ISaintRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SaintRepository(ApplicationDbContext dbContext){
        _dbContext = dbContext;
    }

    public Task Delete(int ID)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Saint>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Saint>> GetByDateRange(DateRange rangeDate)
    {
        throw new NotImplementedException();
    }

    public async Task<Saint> GetByID(int ID)
    {
        Saint? saint = await _dbContext.Saints.FindAsync(ID);
        return saint;
    }

    public IEnumerable<Saint> GetBySaintName(string SaintName)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(Saint entity)
    {
         _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task Update(Saint entity)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Saint> IRepository<Saint, Guid>.GetAll()
    {
        throw new NotImplementedException();
    }
}
