namespace RecurringEvents.Domain.Primitives;

public abstract class Event : EntityBase<Guid>
{   
    string Type {get; set;} 
    public Event(int Id, string type): base(Id)
    {
       Type = type;
    }
}
