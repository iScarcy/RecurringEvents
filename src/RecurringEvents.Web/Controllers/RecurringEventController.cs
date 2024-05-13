using Microsoft.AspNetCore.Mvc;

using MediatR;
using models = RecurringEvents.Web.Models;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using Microsoft.AspNetCore.Authorization;

namespace RecurringEvents.Web.Controllers;

/// <summary>
/// RecurringEventController
/// Controller che contiene i metodi degli eventi ricorrenti
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class RecurringEventController : ControllerBase
{
    private readonly IMediator _mediator;
   
    /// <summary>
    /// costruttori
    /// </summary>
    /// <param name="mediator"></param>
    public RecurringEventController(IMediator mediator)
    {
        _mediator = mediator;       
    }

    /// <summary>
    /// AddBirthDay
    /// Evento evocato per registrare un compleanno 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="DataBirth"></param>
    /// <returns></returns>
   
    [Route("PersonWasCreated")]
    [HttpPost]
    public Task AddBirthDay(models.Person person)
    {
        Person pers = new Person() { FullName = person.FullName, ObjIDRef = person.ObjIdRef };
        BirthDay birthDay = new BirthDay() { DataBirth = person.BirthDay };
    
        var birthDayEvent = new PersonWasCreated(pers, birthDay);
        return _mediator.Send(birthDayEvent);
    }


    /// <summary>
    /// NameDayWasCreated
    /// Evento evocato per registrare un onomastico.
    /// </summary>
    /// <param name="nameDay"></param>    
    /// <returns></returns>
    [Route("NameDayWasCreated")]
    [HttpPost]
    public Task AddNameDay(NameDay nameDay)
    {
        var nameDayEvent = new NameDayWasCreated(nameDay);
        return _mediator.Send(nameDayEvent);
    }


    /// <summary>
    /// Evento invocato quando il sistema si avvia per estrarre gli eventi del giorno
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [HttpPut("SystemWasStarted")]
    public Task<List<Event>> SystemWasStarted(DateRange date) 
    {      
        SistemWasStarted systemEvent = new SistemWasStarted(date);       
        return _mediator.Send(systemEvent);         
    } 

    
}
