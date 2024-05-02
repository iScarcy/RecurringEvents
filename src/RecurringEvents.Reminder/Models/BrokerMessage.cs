using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecurringEvents.Reminder.Models
{
    public class BrokerMessage
    {
        [property: JsonPropertyName("key")]
        public string? Key { get; set; }

        [property: JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
