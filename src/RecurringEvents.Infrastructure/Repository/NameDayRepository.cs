using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Repository;

public class NameDayRepository : INameDayRepository
{
    void IRepository<NameDay, Guid>.Delete(Guid ID)
    {
        throw new NotImplementedException();
    }

    IEnumerable<NameDay> IRepository<NameDay, Guid>.GetAll()
    {
        throw new NotImplementedException();
    }

    IEnumerable<NameDay> IRepository<NameDay, Guid>.GetByDateRange(DateRange rangeDate)
    {
        throw new NotImplementedException();
    }

    NameDay IRepository<NameDay, Guid>.GetByID(Guid ID)
    {
        throw new NotImplementedException();
    }

    void IRepository<NameDay, Guid>.Insert(NameDay entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<NameDay, Guid>.Update(NameDay entity)
    {
        throw new NotImplementedException();
    }
}
