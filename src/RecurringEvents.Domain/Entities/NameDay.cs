namespace RecurringEvents.Domain.Entities;

using RecurringEvents.Domain.Primitives;
public class NameDay : Event
{
    private string Who  {get; init;} 
    private Saint Saint {get; init;}     
    public NameDay(string personName, Saint saint):base(0, "NameDay") 
    {
        this.Who       = personName;
        this.Saint     = saint;    
    }
}
