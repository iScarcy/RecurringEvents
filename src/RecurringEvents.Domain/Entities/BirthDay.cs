using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
 
namespace RecurringEvents.Domain.Events;


public class BirthDay 
{
    public int Id { get; set; }
    [Display(Name = "Il codice indificativo della persona")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]

    public int IdPerson { get; set; }

    [Display(Name = "La data di nascita della persona")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
       
    public DateTime DataBirth {get; set;}
    
    public BirthDay(int id, int idPerson, DateTime dataBirth) 
    {
        Id = id;
        IdPerson = idPerson;
        DataBirth = dataBirth;
    }
}
