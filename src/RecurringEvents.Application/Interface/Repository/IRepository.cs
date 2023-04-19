using RecurringEvents.Domain.Primitives;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Repository;

public interface IRepository<TEntity, TPrimaryKey>
    where TEntity : EntityBase<TPrimaryKey>
{
    IEnumerable<TEntity> GetAll();

    TEntity GetByID(TPrimaryKey ID) ;

    IEnumerable<TEntity> GetByDateRange(DateRange rangeDate);

    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(TPrimaryKey ID);
}
