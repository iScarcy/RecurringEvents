namespace RecurringEvents.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
 

public class Saint 
{
    public int Id { get; set; }

    [Display(Name = "Il nome del santo")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
    public string Description { get; set;}

    [Display(Name = "La data del santo")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
    public DateTime Date { get; set; }
    
    public Saint(){
        
    }
    public Saint(string Description, DateTime Date)
    {        
        this.Description = Description;
        this.Date = Date;
    }

  
}