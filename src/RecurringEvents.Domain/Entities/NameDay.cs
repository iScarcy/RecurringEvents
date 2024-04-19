using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Domain.Entities;
 
public class NameDay 
{
    public int Id { get; set; }
    
    [Required]
    public string PersonName  {get; init;}

    [Required]
    public int IdSaint {get; init;}     
    public NameDay(int id, string personName, int idSaint)
    {
        this.Id          = id;
        this.PersonName  = personName;
        this.IdSaint     = idSaint;    
    }
}
