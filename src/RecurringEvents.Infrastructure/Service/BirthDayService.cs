using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Service;

public class BirthDayService : IEventPeopleRepository<BirthDay>
{
    private readonly ApplicationDbContext _context;
    public BirthDayService(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public async Task ChangeEventDate(string personRefID, DateTime dateEvent)
    {
        BirthDay birthDay = new BirthDay();
         var compleanno = from x in _context.BirthDay.AsNoTracking()
                        join p in _context.People.AsNoTracking() on x.IdPerson equals p.Id
                        where p.ObjIDRef == personRefID
                        select x;
        
        if(!compleanno.Any())
            throw new ArgumentNullException(nameof(compleanno));
        else
        {
            birthDay = await compleanno.FirstOrDefaultAsync();
            birthDay.DataBirth = dateEvent;
            _context.BirthDay.Update(birthDay);
            await _context.SaveChangesAsync();
        }    
    }

    public async Task<IEnumerable<EventPeople>> GetAll()
    {
        var compleanni = from n in _context.BirthDay.AsNoTracking()
                         join p in _context.People.AsNoTracking() on n.IdPerson equals p.Id
                         select new EventPeople(n.DataBirth, p.FullName);

       
       
        return await compleanni.ToListAsync();
       
        
    }

    public async Task<BirthDay> GetEventByPersonRef(string personRefID)
    {
        var compleanno = from x in _context.BirthDay.AsNoTracking()
                        join p in _context.People.AsNoTracking() on x.IdPerson equals p.Id
                        where p.ObjIDRef == personRefID
                        select x;
        
        if(compleanno.Any())
            return await compleanno.FirstOrDefaultAsync();
        else 
            throw new ArgumentNullException(nameof(compleanno));
    }

    public async Task<IEnumerable<EventPeople>> GetEventsByDays(DateRange days)
    {
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
                         select new EventPeople(x.DataBirth, p.FullName);

        
          return await compleanni.ToListAsync();
       

    }

    public async Task<IEnumerable<EventPeople>> GetEventsByPerson(string person)
    {
        var compleanni = from x in _context.BirthDay.AsNoTracking()
                         join p in _context.People.AsNoTracking() on x.IdPerson equals p.Id
                         where p.FullName.ToLower() == person.ToLower()
                         select new EventPeople(x.DataBirth, p.FullName);
     
        return await compleanni.ToListAsync();
       
    }

   
}
