using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Service;

public class BirthDaysService : IEventPeopleRepository<BirthDay>
    {
        private readonly ApplicationDbContext _context;

        public BirthDaysService(ApplicationDbContext context)
        {
            _context = context;
        }

    public async Task<IEnumerable<BirthDay>> GetEventsByDays(DateRange days)
    {
        var compleanni = from x in  _context.BirthDay
                                where //mesi precedenti
                                (   
                                    
                                    (   days.From.Date.Month <= x.DataBirth.Date.Month 
                                        && 
                                        days.To.Date.Month > x.DataBirth.Date.Month 
                                       
                                    )
                                    || //mese from minore e mese to uguale + giorno to minore uguale al giorno del compleanno
                                    (
                                        (
                                            (days.From.Date.Month < x.DataBirth.Date.Month )
                                            &&
                                            (days.To.Date.Month == x.DataBirth.Date.Month )
                                            &&
                                            (days.To.Date.Day >= x.DataBirth.Date.Day )
                                        )

                                    )|| //mesi uguali e giorno compresi
                                    (
                                       (days.From.Date.Month == x.DataBirth.Date.Month )
                                            &&
                                            (days.To.Date.Month == x.DataBirth.Date.Month )
                                            &&
                                            (days.From.Date.Day <= x.DataBirth.Date.Day )     
                                            &&
                                            (days.To.Date.Day >= x.DataBirth.Date.Day )    
                                    )
                                )                               
                                select x;
            return await compleanni.ToListAsync();                    
    }

    public async Task<IEnumerable<BirthDay>> GetEventsByPerson(string person)
        {
            return await _context.BirthDay.Where(x => x.Name.ToLower() == person.ToLower()).ToListAsync();
        }

       
    }
