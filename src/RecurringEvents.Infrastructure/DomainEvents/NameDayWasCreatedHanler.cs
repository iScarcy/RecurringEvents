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
        NameDay nameDay = request.NameDay;
        var saint   = _dbContext.Saints.Find(nameDay.IdSaint);
        if(saint != null)
        {
            await _dbContext.NameDay.AddAsync(nameDay);
            await _dbContext.SaveChangesAsync();
        }else{
            throw new NotImplementedException();
        }
    }
}
