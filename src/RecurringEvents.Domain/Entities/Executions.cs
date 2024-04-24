namespace RecurringEvents.Domain.Entities;

public class Executions
{
     
    public int Id { get; set; }

    public DateTime DateFrom {get; set;}

    public DateTime DateTo {get; set;}

    public bool Cancelled {get; set;}
}
