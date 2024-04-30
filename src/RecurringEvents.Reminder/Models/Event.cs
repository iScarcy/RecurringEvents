using RecurringEvents.Reminder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Reminder.Models
{
    public record Event(EventType type, DateTime date, string description)
    {
    }
}
