namespace RecurringEvents.Domain.Entities;

using RecurringEvents.Domain.Primitives;
public class NameDay 
{
    public string personName  {get; init;} 
    public int IdSaint {get; init;}     
    public NameDay(int id, string personName, int idSaint)
    {
        this.personName  = personName;
        this.IdSaint     = idSaint;    
    }
}
