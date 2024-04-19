using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Infrastructure.Service
{
    internal class BithDayService: IEventPeopleRepository<BirthDay>
    {
        private readonly ApplicationDbContext _context;

        public BithDayService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BirthDay>> GetEventsByPerson(string person)
        {
            return await _context.BirthDay.Where(x => x.Name == person).ToListAsync();
        }

       
    }
}
