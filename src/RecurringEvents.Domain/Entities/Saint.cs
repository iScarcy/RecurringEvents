namespace RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Primitives;

public class Saint : EntityBase<Guid>
{
    public string Description { get; private init;} 
    public DateTime Date { get; private init; }
    public Saint(int Id, string Description, DateTime Date):base(Id)
    {
        this.Description = Description;
        this.Date = Date;
    }
}