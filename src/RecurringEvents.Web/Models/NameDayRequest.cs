using RecurringEvents.Domain;
using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Web.Models
{
    public class NameDayRequest
    {
        [Display(Name = "La GUID della persona")]
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
        public string ObjID { get; set; }


        [Display(Name = "Il codice identificativo del santo")]
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = nameof(ValidationErrors.Mandatory))]
                
        public int IdSaint { get; set; }
    }
}
