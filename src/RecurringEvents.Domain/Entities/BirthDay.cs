using System.ComponentModel.DataAnnotations;

namespace RecurringEvents.Domain.Events;


public class BirthDay 
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DataBirth {get; set;}
    
    public BirthDay(int id, string name, DateTime dataBirth) 
    {
        Id = id;
        Name = name;
        DataBirth = dataBirth;
    }
}
