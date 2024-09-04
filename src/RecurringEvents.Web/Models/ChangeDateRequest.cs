using RecurringEvents.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Web.Models
{
    /// <summary>
    /// Classe input per il cambio data di un evento appartenente ad una persona riconducile tramite objID
    /// </summary>
    public class ChangeDateRequest
    {
        [Required]
        public DateTime newDataEvent { get; set; }
        [Required]
        public string objID { get; set; }      
    }
}
