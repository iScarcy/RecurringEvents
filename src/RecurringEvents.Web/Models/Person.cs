namespace RecurringEvents.Web.Models
{
    public class Person
    {
        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime NameDay { get; set; }
        
        public string? ObjIdRef { get; set; }
    }
}
