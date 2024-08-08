using MediatR;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application.DomainEvents;

public record SistemWasStarted(DateRange DateRange) : IRequest<List<RecurringEvent>>;