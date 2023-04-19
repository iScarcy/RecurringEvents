using MediatR;
using RecurringEvents.Domain.Events;

namespace RecurringEvents.Application.DomainEvents;

public class PersonWasCreated : IRequest
{
    public BirthDay BirthDay;

    public PersonWasCreated(BirthDay birthDay)
    {
        BirthDay = birthDay;
    }
}
