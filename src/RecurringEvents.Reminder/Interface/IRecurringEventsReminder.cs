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
        RecurringEvents.Reminder.Models.Reminder GetReminder();
        void SendReminder(RecurringEvents.Reminder.Models.Reminder reminder);
    }
}
