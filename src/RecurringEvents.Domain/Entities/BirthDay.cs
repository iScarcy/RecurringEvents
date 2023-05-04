namespace RecurringEvents.Domain.Events;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Primitives;

public class BirthDay : Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DataBirth {get; set;}
    
    public BirthDay(int id, string Name, DateTime DataBirth) : base ("BirthDay", DataBirth, Name)
    {
        Id = id;
    }
}
