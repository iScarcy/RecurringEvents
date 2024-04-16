namespace RecurringEvents.Domain.Entities;

using System.Threading.Tasks;
 

public class Saint 
{
    public int Id { get; set; }
    public string Description { get; private init;} 
    public DateTime Date { get; private init; }
    public Saint(int Id, string Description, DateTime Date)
    {
        this.Id = Id;
        this.Description = Description;
        this.Date = Date;
    }

    public static implicit operator Task<object>(Saint v)
    {
        throw new NotImplementedException();
    }
}