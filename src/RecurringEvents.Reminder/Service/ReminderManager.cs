using RecurringEvents.Reminder.Enums;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;
using Serilog;
using Serilog.Core;
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

        private Logger _log;
        public ReminderManager(IRecurringEventsAPI clientEventsApi, IRecurringEventsBrokerMessage brokerService)
        {
            _eventsApi = clientEventsApi;
            _brokerService = brokerService;

            _log = new LoggerConfiguration()
           .WriteTo.File(@"log/log-.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();

            _log.Information($"ReminderManager Execution:'{DateTime.Now}'");
        }

        public async Task<Models.Reminder> GetReminder()
        {
            try
            {
                //2. Lettura dal db (o da altro) dei giorni delle schedulazioni.                  
                _log.Information("GetReminder");
                _log.Information(" - GetLastExecutions");
                DateTime dateFrom = await _eventsApi.GetLastExecution();
                DateTime date_from = dateFrom.AddDays(1).Date;
                DateTime date_to = DateTime.Now.Date;
                
                _log.Information($"From: {date_from}");
                _log.Information($"To: {date_to}");
                DateRange lastExecution = new DateRange(date_from, date_to);
                


                //3.Inserire su db una riga della schedulazione avviata e farsi restituire un codice identificativo.
                _log.Information(" - StartExecution ");
                int executionID = await _eventsApi.StartExecution(lastExecution);
                _log.Information($" - executionID:'{executionID}'");

                //4.Chiamata all 'api di RecurringEvents.Web per avere eventi nell'intervallo di date indicate.

                _log.Information(" - GetEvents");
                IEnumerable<Event> events = await _eventsApi.GetEvents(lastExecution);
                _log.Information($" - Events Found: {events.Count()}");
                return new Models.Reminder() { Id = executionID, Events = events };
            }
            catch (Exception ex)
            {
                _log.Error($"GetReminder Error: '{ex.Message}', stack:'{ex.StackTrace}'");

                throw;
            }
        }

        public async Task SendReminder(Models.Reminder reminder)
        {
            try
            {
                _log.Information("SendReminder");

                int executionID = reminder.Id;
                /*
                4.Per ogni evento restituito dall'api: 
                                - inviare un messaggio rabbit su TeleScarcy
                                - inserire su db una riga con info dell'evento e il codice indentificativo della schedulazione
                */
                List<Event> events = new List<Event>();
                if (reminder.Events.Any())
                {
                    events = reminder.Events.ToList();                  

                    events.ToList<Event>().ForEach
                        (
                            async e =>
                            {
                                string messageText = string.Empty;
                                string key = string.Empty;
                                switch (e.type)
                                {
                                    case RecurringEvents.Reminder.Enums.EventType.BirthDay:
                                        key = BrokerKeyType.bot_auguri.ToString(); 
                                        messageText = $"Il {e.date.Day}/{e.date.Month}, {e.description} ha compiuto {DateTime.Now.Year - e.date.Year} anni.";
                                        break;
                                    case RecurringEvents.Reminder.Enums.EventType.NameDay:
                                        key = BrokerKeyType.bot_auguri.ToString();
                                        messageText = $"Il {e.date.Day}/{e.date.Month}, {e.description} ha fatto l'onomastico.";
                                        break;
                                    case RecurringEvents.Reminder.Enums.EventType.Anniversary:
                                        key = BrokerKeyType.bot_auguri.ToString();
                                        messageText = $"Il {e.date.Day}/{e.date.Month}, ricorda l'anniversario: {e.description} ";
                                        break;
                                    case RecurringEvents.Reminder.Enums.EventType.Reminder:
                                        key = BrokerKeyType.bot_reminder.ToString();
                                        messageText = $"Il {e.date.Day}/{e.date.Month}, reminder: {e.description} ";
                                        break;
                                         
                                }
                                BrokerMessage message = new BrokerMessage() { Key = key, Message = messageText };
                                _log.Information($" - BrokerMessage: key:'{key}', Message:'{messageText}'");
                                _brokerService.SendMessage(message);
                                _log.Information(" - InsertExecutionDetails");
                                await _eventsApi.InsertExecutionDetails(e, executionID);
                            }
                        );
                    _log.Information(" - FinishExecution");

                }
                else
                {
                    _log.Information($" - Events was not found");
                }

                _log.Information(" - FinishExecution");
                await _eventsApi.FinishExecution(executionID);
            }
            catch (Exception ex)
            {
                _log.Error($"SendReminder Error: '{ex.Message}', stack:'{ex.StackTrace}'");

                throw;
            }
        }
    }
}
