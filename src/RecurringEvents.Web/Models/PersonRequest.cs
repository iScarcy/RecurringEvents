namespace RecurringEvents.Web.Models
{
    public class PersonRequest
    {
        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }      
        
        public string? ObjIdRef { get; set; }
    }
}
