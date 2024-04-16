using MediatR;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class SistemWasStartedCreatedHanler : IRequestHandler<SistemWasStarted, List<Event>>
{
   
    private readonly ApplicationDbContext _dbContext;

    public SistemWasStartedCreatedHanler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
   

    public async Task<List<Event>> Handle(SistemWasStarted request, CancellationToken cancellationToken)
    {
    
       List<Event> eventi = new List<Event>(); 
        //compleanni
        
       var compleanni = from x in  _dbContext.BirthDay
                                where //mesi precedenti
                                (   
                                    
                                    (   request.DateRange.From.Date.Month <= x.DataBirth.Date.Month 
                                        && 
                                        request.DateRange.To.Date.Month > x.DataBirth.Date.Month 
                                       
                                    )
                                    || //mese from minore e mese to uguale + giorno to minore uguale al giorno del compleanno
                                    (
                                        (
                                            (request.DateRange.From.Date.Month < x.DataBirth.Date.Month )
                                            &&
                                            (request.DateRange.To.Date.Month == x.DataBirth.Date.Month )
                                            &&
                                            (request.DateRange.To.Date.Day >= x.DataBirth.Date.Day )
                                        )

                                    )|| //mesi uguali e giorno compresi
                                    (
                                       (request.DateRange.From.Date.Month == x.DataBirth.Date.Month )
                                            &&
                                            (request.DateRange.To.Date.Month == x.DataBirth.Date.Month )
                                            &&
                                            (request.DateRange.From.Date.Day <= x.DataBirth.Date.Day )     
                                            &&
                                            (request.DateRange.To.Date.Day >= x.DataBirth.Date.Day )    
                                    )
                                )                               
                                select new Event("Compleanno", x.DataBirth,x.Name);
      
       
       //onomastici
      var onomastici = from n in _dbContext.NameDay
                join s in _dbContext.Saints on n.IdSaint equals s.Id
                 where //mesi compresi
                                (   
                                    
                                    (   request.DateRange.From.Date.Month < s.Date.Date.Month 
                                        && 
                                        request.DateRange.To.Date.Month > s.Date.Date.Month 
                                       
                                    )
                                    || //mese from minore e mese to uguale + giorno to minore uguale al giorno del compleanno
                                    (
                                        (
                                            (request.DateRange.From.Date.Month < s.Date.Date.Month )
                                            &&
                                            (request.DateRange.To.Date.Month == s.Date.Date.Month )
                                            &&
                                            (request.DateRange.To.Date.Day >= s.Date.Date.Day )
                                        )

                                    )|| //mesi uguali e giorno compresi
                                    (
                                       (request.DateRange.From.Date.Month == s.Date.Date.Month )
                                            &&
                                            (request.DateRange.To.Date.Month == s.Date.Date.Month )
                                            &&
                                            (request.DateRange.From.Date.Day >= s.Date.Date.Day )     
                                            &&
                                            (request.DateRange.To.Date.Day <= s.Date.Date.Day )    
                                    )
                                )
                select new Event("Onomastico", s.Date, n.PersonName);
    
       foreach(var compleanno in compleanni){
            eventi.Add(compleanno);
        }
      
       
        foreach(var onomastico in onomastici){
            eventi.Add(onomastico);
        }
   
      return await Task.FromResult<List<Event>>(eventi);
        
    }
}
