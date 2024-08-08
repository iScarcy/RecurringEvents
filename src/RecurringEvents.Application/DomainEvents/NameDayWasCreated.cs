using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using RecurringEvents.Domain;
 

namespace RecurringEvents.Application.DomainEvents;

public class NameDayWasCreated : IRequest
{
    [Display(Name = "La GUID della persona")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]

    public string PersonKeyRif { get; set; }

    [Display(Name = "Il codice identificativo del santo")]
    [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]

    public int SaintKeyRif { get; set; }

    public NameDayWasCreated(string personaKeyRif, int saintKeyRif)
    {
        this.PersonKeyRif = personaKeyRif;
        this.SaintKeyRif = saintKeyRif;        
    }
}
