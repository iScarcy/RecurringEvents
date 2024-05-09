using MediatR;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.DomainEvents;

public class PersonWasCreated : IRequest
{
    public Person person;
    public BirthDay birthDay;
    
    public PersonWasCreated(Person person, BirthDay birthDay)
    {
        this.person = person;
        this.birthDay = birthDay;
        
    }
}
