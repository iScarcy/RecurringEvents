using MediatR;
using RecurringEvents.Domain.Primitives;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.DomainEvents;

public class SistemWasStared : IRequest<List<Event>>
{
    DateRange DateRange;

    public SistemWasStared(DateRange dateRange)
    {
        DateRange = dateRange;
    }
}
