namespace RecurringEvents.Reminder
{
    internal class Program
    {
        static void Main(string[] args)
        {
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


        }
    }
}