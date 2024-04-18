using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Repository;

public class SaintRepository : RepositoryDbService<Saint>, ISaintRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SaintRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Delete(int ID)
    {
        throw new NotImplementedException();
    }


    public Task<IEnumerable<Saint>> GetByDateRange(DateRange rangeDate)
    {
        throw new NotImplementedException();
    }

 

    public IEnumerable<Saint> GetBySaintName(string SaintName)
    {
        throw new NotImplementedException();
    }
        
/*
    IEnumerable<Saint> IRepository<Saint, Guid>.GetAll()
    {
        throw new NotImplementedException();
    }*/
}
