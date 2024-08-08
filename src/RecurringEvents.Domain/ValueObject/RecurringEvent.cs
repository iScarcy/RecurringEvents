namespace RecurringEvents.Domain.ValueObject;

public record RecurringEvent(EventType type, DateTime date, string description)
{
}
