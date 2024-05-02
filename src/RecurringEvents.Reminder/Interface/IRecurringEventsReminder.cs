using RecurringEvents.Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Reminder.Interface
{
    internal interface IRecurringEventsReminder
    {
       Task<RecurringEvents.Reminder.Models.Reminder> GetReminder();
       Task SendReminder(RecurringEvents.Reminder.Models.Reminder reminder);
    }
}
