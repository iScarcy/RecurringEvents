namespace RecurringEvents.Domain.ValueObject;

public record Event(EventType type, DateTime date, string description)
{
}
