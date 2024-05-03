using Microsoft.EntityFrameworkCore;
using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Infrastructure.Repository
{
    internal class RepositoryNameDayDateService : RepositoryDbService<NameDayDate>
    {
        private readonly ApplicationDbContext _context;
        public RepositoryNameDayDateService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<IEnumerable<NameDayDate>> GetAll() 
        {
            var onomastici = from n in _context.NameDay
                             join s in _context.Saints on n.IdSaint equals s.Id
                             select new NameDayDate(s.Date, n.PersonName);

            IEnumerable<NameDayDate> nameDayDates= new List<NameDayDate>();
            if(onomastici.Any()) { 
                nameDayDates = await onomastici.ToListAsync<NameDayDate>();
            }
            return nameDayDates;
        }
    }
}
