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

        private readonly IEventPeopleService<BirthDay> _peopleService;
        private readonly IEventPeopleService<NameDay> _nameDayService;
        private readonly IRecurringEventService _eventService;
    
        /// <summary>
        /// costruttore
        /// </summary>
     
        public EventController(IEventPeopleService<BirthDay> peopleService, IEventPeopleService<NameDay> nameDaysService, IRecurringEventService eventService)
        {
            _peopleService  = peopleService;
            _nameDayService = nameDaysService;
            _eventService   = eventService;
        }
        
        /// <summary>
        /// Restituisce tutti i compleanni 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("birthdays")]
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

                var events = await _eventService.GetAll();

                return Ok(birthdays.Union(namedays).Union(events));

            }
            catch(Exception ex)
            {
                return Problem(ex.Message);    
            }
        }

        /// <summary>
        /// Restituisce tutti gli anniversari
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("anniversary")]
        public async Task<ActionResult> GetAnniversary()
        {
            try
            {

                var events = await _eventService.GetAll();
                var anniversary = events.Where(x=> x.type == EventType.Anniversary)?.ToList(); 
                return Ok(anniversary);

            }
            catch (Exception ex)
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
        public async Task<IEnumerable<RecurringEvent>> GetByPerson(string person)
        {
           
            var birthdays = await _peopleService.GetEventsByPerson(person);
                
            var namedays = await _nameDayService.GetEventsByPerson(person);

            //IEnumerable<RecurringEvent> event = birthdays.Union(namedays);
            return await Task.FromResult(birthdays.Union(namedays));
           
        }


        /// <summary>
        /// Restituisce tutti gli eventi di un determinato giorno
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut("days")]
        public async Task<IEnumerable<RecurringEvent>> GetByDay([FromBody] DateRange rangeDays)
        {
            var birthdays = await _peopleService.GetEventsByDays(rangeDays);

            var namedays = await _nameDayService.GetEventsByDays(rangeDays);

            var events = await _eventService.GetEventsByDays(rangeDays);
            
            return  birthdays.Union(namedays).Union(events);

            
        }


        /// <summary>
        /// ChangeBirthDay
        /// aggiorna la data del compleanno di una persona travata tramite objID
        /// </summary>
        /// <param name="newBirthDay"></param>
        /// <param name="objID"></param>
        /// <returns></returns>
        [HttpPatch("ChangeBirthDay")]
        public async Task ChangeBirthDayDate(ChangeDateRequest changeDateRequest) 
        { 
            await _peopleService.ChangeDate(changeDateRequest.objID,changeDateRequest.newDataEvent);
        }

        /// <summary>
        /// ChangeEventDate
        /// aggiorna la data di un evento
        /// </summary>
        /// <param name="newBirthDay"></param>
        /// <param name="objID"></param>
        /// <returns></returns>
        [HttpPatch("ChangeEventDate")]
        public async Task ChangeEventDate(ChangeDateRequest changeDateRequest)
        {
            await _eventService.ChangeDate(changeDateRequest.objID, changeDateRequest.newDataEvent);
        }


    }
}
