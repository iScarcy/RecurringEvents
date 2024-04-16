using MediatR;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.Interface.DomainEvents;

public interface ISistemWasStarted : IRequest<List<Event>>
{
}
