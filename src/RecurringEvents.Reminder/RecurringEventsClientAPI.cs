using System.Net.Http.Headers;
namespace RecurringEvents.Reminder;

public class RecurringEventsClientAPI
{
    public RecurringEventsClientAPI()
    {
  
    }

 public async Task ProcessRepositoriesAsync(HttpClient client)
 {
    
     var json = await client.GetStringAsync(
         "http://localhost:5071/api/Execution");

     Console.Write(json);
 }
    /*
       
*/
}
