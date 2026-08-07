namespace RecurringEvents.Worker.Models.Content;

public class Event : MessageContent
{
    
    public string EventID { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
}