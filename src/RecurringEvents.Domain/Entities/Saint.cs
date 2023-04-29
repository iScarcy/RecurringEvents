namespace RecurringEvents.Domain.Entities;

using System.Threading.Tasks;
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

    public static implicit operator Task<object>(Saint v)
    {
        throw new NotImplementedException();
    }
}