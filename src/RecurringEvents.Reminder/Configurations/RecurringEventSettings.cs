namespace RecurringEvents.Reminder.Configurations;

public class RecurringEventSettings
{
    public  string? UriRecurringEvent { get; set; }
    public string? ApiSystemWasStarted { get; set; }

    public string? ApiLastExecution { get; set; }

    public string? ApiExecution { get; set; }

    public string? ApiExecutionDetails { get; set; }
}


/*
  "ApiExecution": "/api/Execution",
    "ApiNewExecutionDetails": "/api/Execution/Details",
    "ApiLastExecution": "/api/Execution/LastDate"
 */