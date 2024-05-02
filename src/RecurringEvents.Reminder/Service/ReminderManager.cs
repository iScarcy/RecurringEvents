using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Reminder.Service
{
    public class ReminderManager : IRecurringEventsReminder
    {
        private readonly IRecurringEventsAPI _eventsApi;
        private readonly IRecurringEventsBrokerMessage _brokerService;
        public ReminderManager(IRecurringEventsAPI clientEventsApi, IRecurringEventsBrokerMessage brokerService) 
        { 
            _eventsApi= clientEventsApi;
            _brokerService = brokerService;
        }

        public Models.Reminder GetReminder()
        {
            throw new NotImplementedException();
        }

        public void SendReminder(Models.Reminder reminder)
        {
            throw new NotImplementedException();
        }
    }
}
