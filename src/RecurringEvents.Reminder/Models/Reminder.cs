using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Reminder.Models
{
    public class Reminder
    {
        public int Id { get; set; }

        public IEnumerable<Event>? Events { get; set; }
    }
}
