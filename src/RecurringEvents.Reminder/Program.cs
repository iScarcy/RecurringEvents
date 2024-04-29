 using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using RecurringEvents.Reminder;
using RecurringEvents.Reminder.Configurations;
using RecurringEvents.Reminder.Interface;
using RecurringEvents.Reminder.Models;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

Console.WriteLine("Hello, World!");

    /*TO DO STEP:
             1. Lettura file di configurazioni.
             2. Lettura dal db (o da altro) dei giorni delle schedulazioni.
             3. Inserire su db una riga della schedulazione avviata e farsi restituire un codice identificativo.
             3. Chiamata all'api di RecurringEvents.Web per avere eventi nell'intervallo di date indicate.
             4. Per ogni evento restituito dall'api: 
                    - inviare un messaggio rabbit su TeleScarcy
                    - inserire su db una riga con info dell'evento e il codice indentificativo della schedulazione
             5. Aggiornare la schedulazione come completata
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
    
    //2. Lettura dal db (o da altro) dei giorni delle schedulazioni.                  
    IRecurringEventsAPI webClientAPI = new RecurringEventsClientAPI(client,optsRecurringEventSettings);

    DateTime dateFrom = await webClientAPI.GetLastExecutions();
    dateFrom = dateFrom.AddDays(1);
    DateTime dateTo = DateTime.Now;
    DateRange lastExecution = new DateRange(dateFrom, dateTo);
    Console.WriteLine(lastExecution.From);
    Console.WriteLine(lastExecution.To);