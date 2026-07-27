namespace RecurringEvents.Web.Models
{
    public class PersonRequest
    {
        /// <summary>
        /// The full name of the person. This is used to identify the person in the system and to display their name in the UI.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Date of birth of the person. This is used to calculate the age and to determine if the person is a minor or an adult.
        /// </summary>
        public DateTime DateBirth { get; set; } 
        
        /// <summary>
        ///  The ID of the saint associated with the person. This is used to determine if the person is a saint or not.
        /// </summary>
        public string ObjIdRef { get; set; } = string.Empty;
    }
}
