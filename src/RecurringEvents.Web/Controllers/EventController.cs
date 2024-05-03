using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;


namespace RecurringEvents.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventPeopleService<BirthDay> _peopleService;
        private readonly IEventPeopleService<NameDayDate> _nameDayService;
    
        /// <summary>
        /// costruttore
        /// </summary>
     
        public EventController(IEventPeopleService<BirthDay> peopleService, IEventPeopleService<NameDayDate> nameDaysService)
        {
            _peopleService  = peopleService;
            _nameDayService = nameDaysService;
        }
        
        /// <summary>
        /// Restituisce tutti i compleanni 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("birdays")]
        public async Task<ActionResult> GetBirthdays() 
        {
            try
            {
                
                var birthdays = await _peopleService.GetAll(); 

                return Ok(birthdays);

            }catch(Exception ex)
            {
                return Problem(ex.Message);    
            }
        }

        /// <summary>
        /// Restituisce tutti gli onomastici
        /// </summary>
        /// <returns></returns>
        [HttpGet("namedays")]
        public async Task<ActionResult> GetNameDays()
        {
            try
            {
                
                 var namedays = await _nameDayService.GetAll();

                return Ok(namedays);

            }catch(Exception ex)
            {
                return Problem(ex.Message);    
            }
        }

        /// <summary>
        /// Restituisce tutti gli eventi
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                
                var birthdays = await _peopleService.GetAll();
                
                var namedays = await _nameDayService.GetAll();

                return Ok(birthdays.Union(namedays));

            }
            catch(Exception ex)
            {
                return Problem(ex.Message);    
            }
        }

        /// <summary>
        /// Restituisce tutti gli eventi di un determinato giorno
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("days/{from}/{to}")]
        public async Task<ActionResult> GetByDay(DateTime from, DateTime to)
        {
            try
            {
                DateRange rangeDays = new DateRange(from, to);
                var birthdays = await _peopleService.GetEventsByDays(rangeDays);
                
                var namedays = await _nameDayService.GetEventsByDays(rangeDays);

                return Ok(birthdays.Union(namedays));

            }catch(Exception ex)
            {
                return Problem(ex.Message);    
            }
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
            try
            {
                var birthdays = await _peopleService.GetEventsByPerson(person);
                
                var namedays = await _nameDayService.GetEventsByPerson(person);

                //IEnumerable<Event> event = birthdays.Union(namedays);
                return Ok( birthdays.Union(namedays));
            }catch(Exception ex)
            {
                return Problem(ex.Message);    
            }
        }
    }
}
