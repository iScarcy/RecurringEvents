using RecurringEvents.Application.DomainEvents;
using MediatR;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class PersonWasCreatedHandler : IRequestHandler<PersonWasCreated>
{
    
    private readonly IRepository<Person> _repoPerson;
    private readonly IRepository<BirthDay> _repoBirth;

    public PersonWasCreatedHandler(IRepository<Person> repoPerson, IRepository<BirthDay> repoBirth)
    {
        _repoBirth= repoBirth;
        _repoPerson= repoPerson;
    }
    

    async Task IRequestHandler<PersonWasCreated>.Handle(PersonWasCreated request, CancellationToken cancellationToken)
    {
        Person person = await _repoPerson.Insert(request.person);
        
        BirthDay birthDay = new BirthDay(person.Id, request.birthDay.DataBirth);
        await _repoBirth.Insert(birthDay);
         
        
    }
}
