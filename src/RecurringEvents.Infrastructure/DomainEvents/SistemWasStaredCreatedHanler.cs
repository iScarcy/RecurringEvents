using MediatR;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.Primitives;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class SistemWasStaredCreatedHanler : IRequestHandler<SistemWasStared, List<Event>>
{
   
    private readonly ApplicationDbContext _dbContext;

    public SistemWasStaredCreatedHanler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
   

    async Task<List<Event>> IRequestHandler<SistemWasStared, List<Event>>.Handle(SistemWasStared request, CancellationToken cancellationToken)
    {
    
       List<Event> eventi = new List<Event>(); 
        //compleanni
       List<Event> compleanni = (List<Event>)_dbContext.BirthDay.Where(x => x.DataBirth.Date >= request.DateRange.From.Date && x.DataBirth.Date <= request.DateRange.From.Date );
       
      
       //onomastici
       List<Event> onomastici = (List<Event>)(from n in _dbContext.NameDay
                join s in _dbContext.Saints on n.IdSaint equals s.Id
                where s.Date.Date >= request.DateRange.From.Date && s.Date.Date <= request.DateRange.To.Date
                select new Event("Onomastico", s.Date, n.personName));
                
      foreach(Event compleanno in compleanni)
            eventi.Add(compleanno);

      foreach(Event onomastico in onomastici)
            eventi.Add(onomastico);

      return await Task.FromResult<List<Event>>(eventi);
        
    }
}
