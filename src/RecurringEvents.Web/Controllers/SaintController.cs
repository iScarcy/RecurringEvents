using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaintController : ControllerBase
{
     private readonly IRepository<Saint> _saintRepository ;

    public SaintController(IRepository<Saint> saintRepository)
    {
        _saintRepository = saintRepository;
    }
     
    
    /// <summary>
    /// Add
    /// Censisce un nuovo santo del giorno
    /// </summary>
    /// <param name="Description"></param>
    /// <param name="Data"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Add(Saint saint)
    {
        try
        {
            await _saintRepository.Insert(saint);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    /// <summary>
    /// allSaints
    /// Recupera tutti i santi censiti nel sistema
    /// </summary>
    /// <returns></returns>
    [HttpGet("allSaints")]
    public async Task<ActionResult> Get()
    {
        try 
        { 
            var saints = await _saintRepository.GetAll();
            return Ok(saints);
        }catch(Exception e) 
        {
            return Problem(e.Message);
        }
    } 

}
