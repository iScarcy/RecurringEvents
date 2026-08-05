
using RecurringEvents.Domain.ValueObject;
using System.Collections.Generic;

namespace RecurringEvents.Application.Interface.Repository;

public interface IRepository<T> where T : class
   
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetByID(int ID) ;

    Task<T> GetValueAsync(string key, string value);

    Task<T> Insert(T entity);

    Task Update(T entity);

     Task Delete(string key, string value);
    
}
