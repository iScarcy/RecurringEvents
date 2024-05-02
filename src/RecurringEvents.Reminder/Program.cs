using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using RecurringEvents.Reminder;
using RecurringEvents.Reminder.Configurations;
using RecurringEvents.Reminder.Enums;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;
using RecurringEvents.Reminder.Service;


IRecurringEventsAPI webClientAPI;
IRecurringEventsBrokerMessage brokerService;
ReminderManager reminderManager;

try
{
    /*TO DO STEP:
             1. Lettura file di configurazioni.
             2. Lettura dal db (o da altro) dei giorni delle schedulazioni.
             3. Inserire su db una riga della schedulazione avviata e farsi restituire un codice identificativo.
             4. Chiamata all'api di RecurringEvents.Web per avere eventi nell'intervallo di date indicate.
             5. Per ogni evento restituito dall'api: 
                    - inviare un messaggio rabbit su TeleScarcy
                    - inserire su db una riga con info dell'evento e il codice indentificativo della schedulazione
             6. Aggiornare la schedulazione come completata
             */
    //1.Lettura file di configurazione
    var builder = new ConfigurationBuilder();

    builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration config = builder.Build();
    var optsRecurringEventSettings = new RecurringEventSettings();
    var configRecurringEventSettings = config.GetSection("RecurringEventSettings");

    configRecurringEventSettings.Bind(optsRecurringEventSettings);


    Console.WriteLine($"Batch Size {optsRecurringEventSettings.ApiSystemWasStarted}");

    webClientAPI = new RecurringEventsService(optsRecurringEventSettings);

    var optsRabbitSettings = new RabbitSettings();
    var configRabbitSettings = config.GetSection("RabbitSettings");
    configRabbitSettings.Bind(optsRabbitSettings);
    brokerService = new BrokerMessageService(optsRabbitSettings);

    reminderManager = new ReminderManager(webClientAPI, brokerService);

    Reminder reminder = await reminderManager.GetReminder();

    await reminderManager.SendReminder(reminder);
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}


