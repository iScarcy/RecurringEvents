namespace RecurringEvents.Domain.Events;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Primitives;

public class BirthDay : Event
{
    public string Name { get; set; }
    public DateTime DataBirth {get; set;}
    
    public BirthDay(int id, string Name, DateTime DataBirth) : base (0, "BirthDay")
    {
        this.Name = Name;
        this.DataBirth = DataBirth;
    }
}
