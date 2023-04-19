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

    void IRepository<Saint, Guid>.Delete(Guid ID)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Saint> IRepository<Saint, Guid>.GetAll()
    {
        throw new NotImplementedException();
    }

    IEnumerable<Saint> IRepository<Saint, Guid>.GetByDateRange(DateRange rangeDate)
    {
        throw new NotImplementedException();
    }

    Saint IRepository<Saint, Guid>.GetByID(Guid ID)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Saint> ISaintRepository.GetBySaintName(string SaintName)
    {
        throw new NotImplementedException();
    }

    void IRepository<Saint, Guid>.Insert(Saint entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<Saint, Guid>.Update(Saint entity)
    {
        throw new NotImplementedException();
    }
}
