using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExecutionController : ControllerBase
{
    private readonly IExecutionsService _service;
    public ExecutionController(IExecutionsService service)
    {
        _service = service;
    }

    [HttpGet()]
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
}
