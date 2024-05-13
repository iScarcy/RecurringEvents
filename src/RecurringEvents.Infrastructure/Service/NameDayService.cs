using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Service;

public class NameDayService : IEventPeopleRepository<NameDay>
{
    private readonly ApplicationDbContext _context;

    public NameDayService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ChangeEventDate(string personRefID, DateTime deteEvent)
    {
          
         var onomastico = from x in _context.NameDay.AsNoTracking()
                        join p in _context.People.AsNoTracking() on x.idPerson equals p.Id
                        join s in _context.Saints.AsNoTracking() on x.IdSaint equals s.Id
                        where p.ObjIDRef == personRefID
                        select new NameDay(x.idPerson, x.IdSaint);
        
        if(!onomastico.Any())
            throw new ArgumentNullException(nameof(onomastico));
        else
        {
            NameDay nameDay = await onomastico.FirstAsync();
            Saint saint = new Saint();
            var ss = from s in _context.Saints.AsNoTracking()
            where s.Date == deteEvent
            select s;

            if(!ss.Any())
                throw new ArgumentNullException(nameof(saint));
            else 
                saint = ss.FirstOrDefault();
                
            nameDay.IdSaint = saint.Id;
            _context.NameDay.Update(nameDay);

            await _context.SaveChangesAsync();
        }  
    }

    public async Task<IEnumerable<EventPeople>> GetAll()
    {
        var onomastici = from n in _context.NameDay.AsNoTracking()
                         join s in _context.Saints.AsNoTracking() on n.IdSaint equals s.Id
                         join p in _context.People.AsNoTracking() on n.idPerson equals p.Id
                         select new EventPeople(s.Date, p.FullName);

        
        return await onomastici.ToListAsync();
      

    }

    public async Task<NameDay> GetEventByPersonRef(string personRefID)
    {
        var onomastico = from n in _context.NameDay.AsNoTracking()
                         join s in _context.Saints.AsNoTracking() on n.IdSaint equals s.Id
                         join p in _context.People.AsNoTracking() on n.idPerson equals p.Id
                         where p.ObjIDRef == personRefID
                         select n;
        
                          

        if (onomastico.Any())
            return await onomastico.FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(onomastico));
    }

    public async Task<IEnumerable<EventPeople>> GetEventsByDays(DateRange days)
    {
        //onomastici
        var onomastici = from n in _context.NameDay.AsNoTracking()
                         join s in _context.Saints.AsNoTracking() on n.IdSaint equals s.Id
                         join p in _context.People.AsNoTracking() on n.idPerson equals p.Id
                         where //mesi compresi
                                        (

                                            (days.From.Date.Month < s.Date.Date.Month
                                                &&
                                                days.To.Date.Month > s.Date.Date.Month
                                            )
                                            || //mese from minore e mese to uguale + giorno to minore uguale al giorno del compleanno
                                            (
                                                (
                                                    (days.From.Date.Month < s.Date.Date.Month)
                                                    &&
                                                    (days.To.Date.Month == s.Date.Date.Month)
                                                    &&
                                                    (days.To.Date.Day >= s.Date.Date.Day)
                                                )

                                            ) || //mesi uguali e giorno compresi
                                            (
                                               (days.From.Date.Month == s.Date.Date.Month)
                                                    &&
                                                    (days.To.Date.Month == s.Date.Date.Month)
                                                    &&
                                                    (days.From.Date.Day >= s.Date.Date.Day)
                                                    &&
                                                    (days.To.Date.Day <= s.Date.Date.Day)
                                            )
                                        )
                         select new EventPeople(s.Date, p.FullName);

        return await onomastici.ToListAsync();
    }

    public async Task<IEnumerable<EventPeople>> GetEventsByPerson(string person)
    {
        var nameDays = from n in _context.NameDay.AsNoTracking()
                       join s in _context.Saints.AsNoTracking() on n.IdSaint equals s.Id
                       join p in _context.People.AsNoTracking() on n.idPerson equals p.Id
                       where p.FullName == person
                       select new EventPeople(s.Date, p.FullName);


        return await nameDays.ToListAsync();
    }

}  


