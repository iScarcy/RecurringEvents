using MediatR;
using RecurringEvents.Domain.Primitives;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.DomainEvents;

public class SistemWasStared : IRequest<List<Event>>
{
    public DateRange DateRange;

    public SistemWasStared(DateRange dateRange)
    {
        DateRange = dateRange;
    }
}
