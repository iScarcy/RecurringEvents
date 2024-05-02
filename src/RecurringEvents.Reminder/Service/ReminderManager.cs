﻿using RecurringEvents.Reminder.Enums;
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
        private StringBuilder _messageLog;
        public ReminderManager(IRecurringEventsAPI clientEventsApi, IRecurringEventsBrokerMessage brokerService, StringBuilder log
            )
        {
            _eventsApi = clientEventsApi;
            _brokerService = brokerService;
            _messageLog = log;
        }

        public async Task<Models.Reminder> GetReminder()
        {
            try
            {
                //2. Lettura dal db (o da altro) dei giorni delle schedulazioni.                  
                _messageLog.AppendLine("GetReminder");
                _messageLog.AppendLine(" - GetLastExecutions");
                DateTime dateFrom = await _eventsApi.GetLastExecutions();
                dateFrom = dateFrom.AddDays(1);
                DateTime dateTo = DateTime.Now;
                DateRange lastExecution = new DateRange(dateFrom, dateTo);
                _messageLog.AppendLine($"lastExecution.From: {lastExecution.From}");
                _messageLog.AppendLine($"lastExecution.To: {lastExecution.To}");
                

                //3.Inserire su db una riga della schedulazione avviata e farsi restituire un codice identificativo.
                _messageLog.AppendLine(" - StartExecution ");
                int executionID = await _eventsApi.StartExecution(lastExecution);
                _messageLog.AppendLine(" - executionID:'{executionID}'");
                
                //4.Chiamata all 'api di RecurringEvents.Web per avere eventi nell'intervallo di date indicate.

                _messageLog.AppendLine(" - GetEvents");
                IEnumerable<Event> events = await _eventsApi.GetEvents(lastExecution);
                _messageLog.AppendLine($" - Events Found: {events.Count()}");
                return new Models.Reminder() { Id = executionID, Events = events };
            }
            catch (Exception ex)
            {
                _messageLog.AppendLine($"GetReminder Error: '{ex.Message}', stack:'{ex.StackTrace}'");

                throw;
            }
        }

        public async Task SendReminder(Models.Reminder reminder)
        {
            try
            {
                _messageLog.AppendLine("SendReminder");
                /*
                4.Per ogni evento restituito dall'api: 
                                - inviare un messaggio rabbit su TeleScarcy
                                - inserire su db una riga con info dell'evento e il codice indentificativo della schedulazione
                */
                List<Event> events = new List<Event>();
                if (reminder.Events.Any())
                {
                    events = reminder.Events.ToList();
                    
                    int executionID = reminder.Id;

                    events.ToList<Event>().ForEach
                        (
                            async e =>
                            {
                                string messageText = string.Empty;
                                string key = string.Empty;
                                switch (e.type)
                                {
                                    case RecurringEvents.Reminder.Enums.EventType.BirthDay:
                                        key = BrokerKeyType.Wish.ToString();
                                        messageText = $"Il {e.date.Day}/{e.date.Month}, {e.description} ha compiuto {DateTime.Now.Year - e.date.Year} anni.";
                                        break;
                                    case RecurringEvents.Reminder.Enums.EventType.NameDay:
                                        key = BrokerKeyType.Wish.ToString();
                                        messageText = $"Il {e.date.Day}/{e.date.Month}, {e.description} ha fatto l'onomastico.";
                                        break;
                                }
                                BrokerMessage message = new BrokerMessage() { Key = key, Message = messageText };
                                _messageLog.AppendLine($" - BrokerMessage: key:'{key}', Message:'{messageText}'");
                                _brokerService.SendMessage(message);
                                _messageLog.AppendLine(" - InsertExecutionDetails");
                                await _eventsApi.InsertExecutionDetails(e, executionID);
                            }
                        );
                    _messageLog.AppendLine(" - FinishExecution");
                    await _eventsApi.FinishExecution(executionID);
                }
            }
            catch (Exception ex)
            {
                _messageLog.AppendLine($"SendReminder Error: '{ex.Message}', stack:'{ex.StackTrace}'");

                throw;
            }
        }
    }
}
