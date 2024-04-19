using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RecurringEvents.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// costruttore
        /// </summary>
        public EventController()
        {

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
        [HttpGet("{day}")]
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
        [HttpGet("{person}")]
        public Task<ActionResult> GetByPerson(string person)
        {
            throw new NotImplementedException();
        }
    }
}
