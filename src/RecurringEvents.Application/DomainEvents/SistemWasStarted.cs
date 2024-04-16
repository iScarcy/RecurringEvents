using MediatR;
using RecurringEvents.Application.Interface.DomainEvents;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.DomainEvents;


public record SistemWasStarted(DateRange DateRange) : IRequest<List<Event>>;