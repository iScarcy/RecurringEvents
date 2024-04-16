namespace RecurringEvents.Domain.ValueObject;

public record Event(string type, DateTime date, string description)
{
}
