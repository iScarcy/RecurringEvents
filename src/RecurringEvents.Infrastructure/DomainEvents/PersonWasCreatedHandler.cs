using RecurringEvents.Application.DomainEvents;
using MediatR;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class PersonWasCreatedHandler : IRequestHandler<PersonWasCreated>
{
    private readonly ApplicationDbContext _dbContext;

    public PersonWasCreatedHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    

    async Task IRequestHandler<PersonWasCreated>.Handle(PersonWasCreated request, CancellationToken cancellationToken)
    {
        var birthDay = request.BirthDay;
        await _dbContext.BirthDay.AddAsync(birthDay);
        await _dbContext.SaveChangesAsync();
        
    }
}
