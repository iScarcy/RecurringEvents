using MediatR;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Application.DomainEvents;

public class NameDayWasCreated : IRequest
{
    
    public NameDay NameDay { get; set; }

    public NameDayWasCreated(NameDay nameDay)
    {
        
        NameDay = nameDay;
    }
}
