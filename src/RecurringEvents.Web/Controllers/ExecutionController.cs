using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Web.Controllers;

/// <summary>
/// Controller per gestire le esecuzione
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ExecutionController : ControllerBase
{
    
    private readonly IExecutionsService _service;
    
    /// <summary>
    /// costruttore
    /// </summary>
    public ExecutionController(IExecutionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// prendi la data dell'ultima esecuzione 
    /// </summary>
    /// <returns></returns>
    [HttpGet("LastDate")]
    public async Task<ActionResult> GetDate()
    {
        try
        {
            var result = await _service.GetLastExecution();
            return Ok(result);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Inserimento di una nuova esecuzione
    /// </summary>
    /// <param name="dateRange"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<ActionResult> AddExecution(DateRange dateRange)
    {
        try 
        {
            var result = await _service.NewExecution(dateRange);
            return Ok(result);
        }catch(Exception ex)
        {
            return Problem(ex.Message + Environment.NewLine + ex.StackTrace);
        }
    }

    /// <summary>
    /// Inserisce il dettaglio di un evento
    /// </summary>
    /// <param name="infoEvent"></param>
    /// <param name="executionId"></param>
    /// <returns></returns>
    [HttpPost("details")]
    public async Task<ActionResult> AddExecDetails(Event infoEvent, int executionId) 
    { 
        try 
        {
            await _service.NewExecutionDetails(infoEvent, executionId);
            return Ok();
        }catch(Exception ex) 
        { 
            return Problem(ex.Message+ Environment.NewLine + ex.StackTrace);
        }
    }

}
