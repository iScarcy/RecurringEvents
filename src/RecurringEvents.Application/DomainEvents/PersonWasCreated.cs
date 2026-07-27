using MediatR;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.DomainEvents;

public class PersonWasCreated : IRequest
{
    public Person person;
    
    public PersonWasCreated(Person person)
    {
        this.person = person;
    }
}
