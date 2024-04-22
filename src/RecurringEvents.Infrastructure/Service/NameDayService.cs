using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Service;

public class NameDayService : IEventPeopleRepository<NameDayDate>
    {
        private readonly ApplicationDbContext _context;

        public NameDayService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NameDayDate>> GetEventsByPerson(string person)
        {
            var nameDays = from n in _context.NameDay
                    join s in _context.Saints on n.IdSaint equals s.Id
                    where n.PersonName == person
                    select new NameDayDate(s.Date,n.PersonName);
                     

            return await nameDays.ToListAsync<NameDayDate>();
        }

       
    }

    /*
    
    */

