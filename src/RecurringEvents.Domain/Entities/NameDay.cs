using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Domain.Entities;
 
public class NameDay 
{
    public int Id { get; set; }
    [Display(Name = "Il nome della persona")]    
    
    [Required(ErrorMessageResourceType =typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
    public int idPerson  {get; init;}

    [Display(Name = "Il codice identificativo del santo")]
    [Range(1,int.MaxValue, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
    public int IdSaint {get; set;}     
 
    public NameDay(int idPerson, int idSaint)
    {
        this.idPerson    = idPerson;
        this.IdSaint     = idSaint;    
    }

}
