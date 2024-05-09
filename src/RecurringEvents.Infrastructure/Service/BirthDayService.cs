using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Service;

public class BirthDayService : IEventPeopleRepository<BirthDayDate>
{
    private readonly ApplicationDbContext _context;

    public BirthDayService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BirthDayDate>> GetAll()
    {
        var compleanni = from n in _context.BirthDay.AsNoTracking()
                         join p in _context.People.AsNoTracking() on n.IdPerson equals p.Id
                         select new BirthDayDate(n.DataBirth, p.FullName);

        IEnumerable<BirthDayDate> birthDayDates = new List<BirthDayDate>();
        if (compleanni.Any())
        {
            birthDayDates = await compleanni.ToListAsync();
        }
        return birthDayDates;
    }

    public async Task<IEnumerable<BirthDayDate>> GetEventsByDays(DateRange days)
    {
        IEnumerable<BirthDayDate> birthDayDates = new List<BirthDayDate>();
        var compleanni = from x in _context.BirthDay.AsNoTracking()
                         join p in _context.People.AsNoTracking() on x.IdPerson equals p.Id
                         where //mesi precedenti
                                (

                                    (days.From.Date.Month <= x.DataBirth.Date.Month
                                        &&
                                        days.To.Date.Month > x.DataBirth.Date.Month

                                    )
                                    || //mese from minore e mese to uguale + giorno to minore uguale al giorno del compleanno
                                    (
                                        (
                                            (days.From.Date.Month < x.DataBirth.Date.Month)
                                            &&
                                            (days.To.Date.Month == x.DataBirth.Date.Month)
                                            &&
                                            (days.To.Date.Day >= x.DataBirth.Date.Day)
                                        )

                                    ) || //mesi uguali e giorno compresi
                                    (
                                       (days.From.Date.Month == x.DataBirth.Date.Month)
                                            &&
                                            (days.To.Date.Month == x.DataBirth.Date.Month)
                                            &&
                                            (days.From.Date.Day <= x.DataBirth.Date.Day)
                                            &&
                                            (days.To.Date.Day >= x.DataBirth.Date.Day)
                                    )
                                )
                         select new BirthDayDate(x.DataBirth, p.FullName);

        if (compleanni.Any())
        {
            birthDayDates = await compleanni.ToListAsync();
        }

        return birthDayDates;
    }

    public async Task<IEnumerable<BirthDayDate>> GetEventsByPerson(string person)
    {
        IEnumerable<BirthDayDate> birthDayDates = new List<BirthDayDate>();
        var compleanni = from x in _context.BirthDay.AsNoTracking()
                         join p in _context.People.AsNoTracking() on x.IdPerson equals p.Id
                         where p.FullName.ToLower() == person.ToLower()
                         select new BirthDayDate(x.DataBirth, p.FullName);
        return birthDayDates;
        
    }


}
