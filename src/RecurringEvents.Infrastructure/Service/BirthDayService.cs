using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Service;

public class BirthDayService : IEventPeopleRepository<EventPeople>
{
    private readonly ApplicationDbContext _context;
    public BirthDayService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task ChangeEventDate(string personRefID, DateTime dateEvent)
    { 
        var person = await _context.People.Where(x => x.ObjIDRef == personRefID).FirstOrDefaultAsync();                 

        if (person == null)
            throw new ArgumentNullException(nameof(person));
        else
        {
            person.DateBirth = dateEvent;
            _context.People.Update(person);
            
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EventPeople>> GetAll()
    {
        var compleanni = from p in _context.People.AsNoTracking() 
                         select new EventPeople(p.ObjIDRef, p.DateBirth, p.FullName);

        return await compleanni.ToListAsync();


    }

    public async Task<EventPeople> GetEventByPersonRef(string personRefID)
    {
        var compleanno = from p in _context.People.AsNoTracking()  
                         where p.ObjIDRef == personRefID
                         select new EventPeople(p.ObjIDRef, p.DateBirth, p.FullName);

        if (compleanno != null)
            return await compleanno.FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(compleanno));
    }
 

    public async Task<IEnumerable<EventPeople>> GetEventsByPerson(string person)
    {
        /*
        var compleanni = from x in _context.BirthDay.AsNoTracking()
                         join p in _context.People.AsNoTracking() on x.IdPerson equals p.Id
                         where p.FullName.ToLower() == person.ToLower()
                         select new EventPeople(p.ObjIDRef, x.DataBirth, p.FullName);

        return await compleanni.ToListAsync();
        */
        var compleanni = from p in _context.People.AsNoTracking()
                         where p.FullName.ToLower() == person.ToLower()
                         select new EventPeople(p.ObjIDRef, p.DateBirth, p.FullName);
        return await compleanni.ToListAsync();
    }


}
