using RecurringEvents.Domain.Primitives;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Repository;

public interface IRepository<TEntity, TPrimaryKey>
    where TEntity : EntityBase<TPrimaryKey>
{
    IEnumerable<TEntity> GetAll();

    Task<TEntity> GetByID(int ID) ;

    Task<IEnumerable<TEntity>> GetByDateRange(DateRange rangeDate);

    Task Insert(TEntity entity);

    Task Update(TEntity entity);

    Task Delete(int ID);
}
