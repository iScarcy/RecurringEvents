using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using RecurringEvents.Reminder.Configurations;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;
namespace RecurringEvents.Reminder;

public class RecurringEventsClientAPI : IRecurringEventsAPI
{
    private HttpClient _client = new();
    private RecurringEventSettings _settingsAPI;
    public RecurringEventsClientAPI(HttpClient client, RecurringEventSettings settings)
    {
        _client = client;
        _settingsAPI = settings;
    }

    public async Task<DateTime> GetLastExecutions()
    {
        await using Stream stream =
        await _client.GetStreamAsync(_settingsAPI.UriRecurringEvent+_settingsAPI.ApiLastExecution);
        var dateFrom =
        await JsonSerializer.DeserializeAsync<DateTime>(stream);
        return dateFrom;
    }

    public async Task<int> InsertNewExecution(DateRange date)
    {
        using StringContent jsonContent = new(
           JsonSerializer.Serialize(date),
           Encoding.UTF8,
           "application/json");

        using HttpResponseMessage response = await _client.PostAsync(
       _settingsAPI.UriRecurringEvent + _settingsAPI.ApiExecution,
       jsonContent);

        int executionID = 0;
        switch(response.StatusCode)  
        { 
            case HttpStatusCode.OK:
                executionID = await response.Content.ReadFromJsonAsync<int>();
                break;
            default: throw new Exception($"Errore durante l'inserimento dell'esecuzione, DateFrom:'{date.From}', DateTo:'{date.To}'");
        }

        return executionID;
    }
}
