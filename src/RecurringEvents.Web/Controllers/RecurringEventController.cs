using Microsoft.AspNetCore.Mvc;

using MediatR;
using RecurringEvents.Domain.Events;
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
    [Authorize]
    [Route("PersonWasCreated/{Name}/{DataBirth}")]
    [HttpPost]
    public Task AddBirthDay(string Name, DateTime DataBirth)
    {
        BirthDay birthDay = new BirthDay(0,Name, DataBirth);
        var birthDayEvent = new PersonWasCreated(birthDay);
        return _mediator.Send(birthDayEvent);
    }


    /// <summary>
    /// NameDayWasCreated
    /// Evento evocato per registrare un onomastico.
    /// </summary>
    /// <param name="personName"></param>
    /// <param name="idSaint"></param>
    /// <returns></returns>
    [Route("NameDayWasCreated")]
    [HttpPost]
    public Task AddNameDay(string personName, int idSaint)
    {
        NameDay nameDay  = new NameDay(0, personName, idSaint);
        var nameDayEvent = new NameDayWasCreated(nameDay);
        return _mediator.Send(nameDayEvent);
    } 

   
    /// <summary>
    /// Evento invocato quando il sistema si avvia per estrarre gli eventi del giorno
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    [HttpGet("SystemWasStarted/{from}/{to}")]
    public Task<List<Event>> SystemWasStarted(DateTime from, DateTime to) 
    {
        DateRange date = new DateRange(from, to);
        Console.WriteLine(date.From);
        Console.WriteLine(date.To);
        
        SistemWasStarted systemEvent = new SistemWasStarted(date);       
        return _mediator.Send(systemEvent);
         
    } 

    
}
