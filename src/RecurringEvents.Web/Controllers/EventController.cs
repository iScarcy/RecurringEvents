using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Events;

namespace RecurringEvents.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventPeopleService<BirthDay> _peopleService;

        /// <summary>
        /// costruttore
        /// </summary>
     
        public EventController(IEventPeopleService<BirthDay> peopleService)
        {
            _peopleService  = peopleService;
        }
        
        /// <summary>
        /// Restituisce tutti i compleanni 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("birdays")]
        public Task<ActionResult> GetBirthdays() 
        {
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restituisce tutti gli onomastici
        /// </summary>
        /// <returns></returns>
        [HttpGet("namedays")]
        public Task<ActionResult> GetNameDays()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restituisce tutti gli eventi
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("all")]
        public Task<ActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restituisce tutti gli eventi di un determinato giorno
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("day/{day}")]
        public Task<ActionResult> GetByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cerca tutti gli eventi legati ad una persona
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("person/{person}")]
        public async Task<ActionResult> GetByPerson(string person)
        {
            var birdays = await _peopleService.GetEventsByPerson(person);
            return Ok(birdays);
        }
    }
}
