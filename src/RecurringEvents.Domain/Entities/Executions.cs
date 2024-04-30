namespace RecurringEvents.Domain.Entities;

public class Executions
{
     
    public int Id { get; set; }

    public DateTime DateFrom {get; set;}

    public DateTime DateTo {get; set;}

    public DateTime DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public bool Cancelled {get; set;}
}
