using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Events;

namespace RecurringEvents.Infrastructure.Service;

public class BirthDaysService : IEventPeopleRepository<BirthDay>
    {
        private readonly ApplicationDbContext _context;

        public BirthDaysService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BirthDay>> GetEventsByPerson(string person)
        {
            return await _context.BirthDay.Where(x => x.Name == person).ToListAsync();
        }

       
    }
