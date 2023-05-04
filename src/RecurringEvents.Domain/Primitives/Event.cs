namespace RecurringEvents.Domain.Primitives;

public  class Event 
{   
    public string Type {get; set;} 
    public DateTime Date {get; set;}
    public string Description {get; set;}
    public Event(string type, DateTime date, string description)
    {
       Type = type;
       Date = date;
       Description = description;
    }
    
    
}
