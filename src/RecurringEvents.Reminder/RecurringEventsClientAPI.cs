using System.Net.Http.Headers;
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
        await _client.GetStreamAsync(_settingsAPI.UriRecurringEvent+_settingsAPI.ApiLastExecutions);
        var dateFrom =
        await JsonSerializer.DeserializeAsync<DateTime>(stream);
        return dateFrom;
    }

}
