using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using RecurringEvents.Reminder.Configurations;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;

namespace RecurringEvents.Reminder.Service;

public class RecurringEventsService : IRecurringEventsAPI
{
    private HttpClient _client = new();
    private RecurringEventSettings _settingsAPI;
    public RecurringEventsService(RecurringEventSettings settings)
    {
        
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        
    }



    public async Task<DateTime> GetLastExecution()
    {
        await using Stream stream =
        await _client.GetStreamAsync(_settingsAPI.UriRecurringEvent + _settingsAPI.ApiLastExecution);
        var dateFrom =
        await JsonSerializer.DeserializeAsync<DateTime>(stream);
        return dateFrom;
    }

    public async Task<int> StartExecution(DateRange date)
    {
        using StringContent jsonContent = new(
           JsonSerializer.Serialize(date),
           Encoding.UTF8,
           "application/json");

        using HttpResponseMessage response = await _client.PostAsync(
       _settingsAPI.UriRecurringEvent + _settingsAPI.ApiExecution,
       jsonContent);

        int executionID = 0;
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                executionID = await response.Content.ReadFromJsonAsync<int>();
                break;
            default: throw new Exception($"Errore durante l'inserimento dell'esecuzione, DateFrom:'{date.From}', DateTo:'{date.To}'");
        }

        return executionID;
    }

    public async Task<IEnumerable<Event>> GetEvents(DateRange date)
    {
        await using Stream stream =
        await _client.GetStreamAsync(_settingsAPI.UriRecurringEvent + string.Format(_settingsAPI.ApiSystemWasStarted, date.From.ToString("yyy-MM-dd"), date.To.ToString("yyy-MM-dd")));
        var events =
        await JsonSerializer.DeserializeAsync<List<Event>>(stream);
        return events;
    }

    public async Task InsertExecutionDetails(Event infoEvent, int ExecutionsID)
    {
        using StringContent jsonContent = new(
           JsonSerializer.Serialize(new
           {
               infoEvent,
               ExecutionID = ExecutionsID
           }),
          Encoding.UTF8,
          "application/json");

        using HttpResponseMessage response = await _client.PostAsync(
            _settingsAPI.UriRecurringEvent + _settingsAPI.ApiExecutionDetails,
            jsonContent);


    }

    public async Task FinishExecution(int ExecutionsID)
    {
        StringContent content = new StringContent(String.Empty);
        
        using HttpResponseMessage response = await _client.PatchAsync(
                _settingsAPI.UriRecurringEvent + string.Format(_settingsAPI.ApiFinishExecution, ExecutionsID), content
            );
    }
}
