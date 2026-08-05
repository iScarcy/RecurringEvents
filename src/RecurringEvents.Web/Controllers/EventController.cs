using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using RecurringEvents.Web.Models;

namespace RecurringEvents.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        
        private readonly IRecurringEventService _eventService;
    
        /// <summary>
        /// costruttore
        /// </summary>
     
        public EventController(IRecurringEventService eventService)
        {
            _eventService   = eventService;
        }

    [HttpGet]
    public async Task<ActionResult> GetAll() 
    {
        try
        {
            
            var events = await _eventService.GetAll();

            return Ok(events);

        }catch(Exception ex)
        {
            return Problem(ex.Message);    
        }
    }
            
        [HttpGet("{objID}")]
        public async Task<ActionResult> GetEventByID(string objID)
        {
            try
            {
                var eventItem = await _eventService.GetEventByID(objID);
                return Ok(eventItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// Restituisce tutti i tipi di eventi
        /// </summary>
        /// <returns></returns>
        [HttpGet("types")]
        public async Task<ActionResult> GetEventTypes()
        {
            try
            {
                var eventTypes = await _eventService.GetEventTypes();
                return Ok(eventTypes);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// Aggiorna un evento tramite objID
        /// </summary>
        /// <param name="objID"></param>
        /// <param name="eventToUpdate"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> UpdateEvent(string objID, Event eventToUpdate)
        {
            try
            {
                await _eventService.UpdateEvent(objID, eventToUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }  

    /// <summary>
    /// Elimina un evento tramite objID
    /// </summary>
    /// <param name="objID"></param>
    /// <returns></returns>
        [HttpDelete("{objID}")]
        public async Task<ActionResult> DeleteEvent(string objID)
        {
            try
            {
                await _eventService.DeleteEvent(objID);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    
    }
}
