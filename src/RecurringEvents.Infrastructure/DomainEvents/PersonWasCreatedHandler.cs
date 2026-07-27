using RecurringEvents.Application.DomainEvents;
using MediatR;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class PersonWasCreatedHandler : IRequestHandler<PersonWasCreated>
{
    
    private readonly IRepository<Person> _repoPerson; 

    public PersonWasCreatedHandler(IRepository<Person> repoPerson)
    {
          _repoPerson= repoPerson;
    }
    

    async Task IRequestHandler<PersonWasCreated>.Handle(PersonWasCreated request, CancellationToken cancellationToken)
    {
        Person person = await _repoPerson.Insert(request.person);
        
    }
}
