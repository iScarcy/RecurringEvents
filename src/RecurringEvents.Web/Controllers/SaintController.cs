using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaintController : ControllerBase
{
     private readonly ISaintRepository _saintRepository ;

    [Route("AddSaint")]
    [HttpPost]
    public  IActionResult AddSaint(string Description, DateTime Data)
    {
        try
        {
            Saint ss = new Saint(0, Description, Data);
            _saintRepository.Insert(ss);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}
