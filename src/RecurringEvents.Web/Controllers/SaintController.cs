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
    public async Task Add(Saint saint)
    {
        try
        {
            await _saintRepository.Insert(saint);            
        }
        catch (Exception e)
        {
         
        }
    }
    /// <summary>
    /// allSaints
    /// Recupera tutti i santi censiti nel sistema
    /// </summary>
    /// <returns></returns>
    [HttpGet("allSaints")]
    public async Task<IEnumerable<Saint>> GetAll()
    {
       return await _saintRepository.GetAll();            
    }

    /// <summary>
    /// allSaints
    /// Recupera uno specifico santo censito nel sistema
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<Saint> Get(int idSaint)
    {
        return await _saintRepository.GetByID(idSaint);
    }


    [HttpPatch()]
    public async Task UpdateSaint(Saint saint) 
    { 
        await _saintRepository.Update(saint);
    }

}
