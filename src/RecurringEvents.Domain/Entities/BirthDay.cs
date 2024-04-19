using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Domain.Events;


public class BirthDay 
{
    public int Id { get; set; }
    [Display(Name = "Il nome della persona")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]

    public string Name { get; set; }

    [Display(Name = "La data di nascita della persona")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]

    public DateTime DataBirth {get; set;}
    
    public BirthDay(int id, string name, DateTime dataBirth) 
    {
        Id = id;
        Name = name;
        DataBirth = dataBirth;
    }
}
