namespace RecurringEvents.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
 

public class Saint 
{
    public int Id { get; set; }
    
    [Required]
    public string Description { get; private init;}

    [Required]
    public DateTime Date { get; private init; }
    
    
    public Saint(int Id, string Description, DateTime Date)
    {
        this.Id = Id;
        this.Description = Description;
        this.Date = Date;
    }

  
}