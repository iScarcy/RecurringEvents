using System.Text.Json.Serialization;
using RecurringEvents.Worker.Models.Type;

namespace RecurringEvents.Worker.Models;

public class Message
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ServiceType service { get; set; }
     [JsonConverter(typeof(JsonStringEnumConverter))]
    public ActionType action { get; set; }
    public MessageContent content { get; set; } = new MessageContent();
}

 