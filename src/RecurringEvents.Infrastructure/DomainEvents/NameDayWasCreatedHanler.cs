using MediatR;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class NameDayWasCreatedHanler : IRequestHandler<NameDayWasCreated>
{
    private readonly ApplicationDbContext _dbContext;

    public NameDayWasCreatedHanler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    async Task IRequestHandler<NameDayWasCreated>.Handle(NameDayWasCreated request, CancellationToken cancellationToken)
    {
        
        var saint   = _dbContext.Saints.Find(request.SaintKeyRif);
        var persona = _dbContext.People.Where(x => x.ObjIDRef == request.PersonKeyRif)?.FirstOrDefault();
        
        if(saint != null && persona !=null)
        {
            NameDay nameDay = new NameDay(persona.Id, saint.Id);
            
            await _dbContext.NameDay.AddAsync(nameDay);
            await _dbContext.SaveChangesAsync();
        }else{
            throw new NotImplementedException();
        }
    }
}
