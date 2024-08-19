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
        Task<IEnumerable<EventPeople>> GetAll();
        Task<IEnumerable<EventPeople>> GetEventsByPerson(string personName);
        
        Task<T> GetEventByPersonRef(string personRefID);

        Task ChangeEventDate(string personRefID, DateTime deteEvent);
    }
}
