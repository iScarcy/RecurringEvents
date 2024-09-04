namespace RecurringEvents.Domain.ValueObject;

public record RecurringEvent(string codEvent, EventType type, DateTime date, string description)
{
}
