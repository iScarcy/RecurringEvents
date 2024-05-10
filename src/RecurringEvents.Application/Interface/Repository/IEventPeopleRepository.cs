using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.Repository
{
    public interface IEventPeopleRepository<T> where T : class    
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetEventsByPerson(string personName);
        
        Task<IEnumerable<T>> GetEventsByDays(DateRange days);

        Task<T> GetEventByPersonRef(string personRefID);

        Task ChangeDate(T entity, DateTime newDate);
    }
}
