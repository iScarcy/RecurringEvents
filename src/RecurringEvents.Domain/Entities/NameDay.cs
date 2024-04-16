namespace RecurringEvents.Domain.Entities;
 
public class NameDay 
{
    public int Id { get; set; }
    public string PersonName  {get; init;} 
    public int IdSaint {get; init;}     
    public NameDay(int id, string personName, int idSaint)
    {
        this.Id          = id;
        this.PersonName  = personName;
        this.IdSaint     = idSaint;    
    }
}
