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

    public async Task<IEnumerable<NameDayDate>> GetEventsByDays(DateRange days)
    {
             //onomastici
        var onomastici = from n in _context.NameDay
                join s in _context.Saints on n.IdSaint equals s.Id
                 where //mesi compresi
                                (   
                                    
                                    (   days.From.Date.Month < s.Date.Date.Month 
                                        && 
                                        days.To.Date.Month > s.Date.Date.Month 
                                    )
                                    || //mese from minore e mese to uguale + giorno to minore uguale al giorno del compleanno
                                    (
                                        (
                                            (days.From.Date.Month < s.Date.Date.Month )
                                            &&
                                            (days.To.Date.Month == s.Date.Date.Month )
                                            &&
                                            (days.To.Date.Day >= s.Date.Date.Day )
                                        )

                                    )|| //mesi uguali e giorno compresi
                                    (
                                       (days.From.Date.Month == s.Date.Date.Month )
                                            &&
                                            (days.To.Date.Month == s.Date.Date.Month )
                                            &&
                                            (days.From.Date.Day >= s.Date.Date.Day )     
                                            &&
                                            (days.To.Date.Day <= s.Date.Date.Day )    
                                    )
                                )
                select new NameDayDate(s.Date, n.PersonName);

        return await onomastici.ToListAsync();
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

   
