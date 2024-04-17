using Microsoft.AspNetCore.Mvc;

using MediatR;
using RecurringEvents.Domain.Events;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using Microsoft.AspNetCore.Authorization;

namespace RecurringEvents.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecurringEventController : ControllerBase
{
    private readonly IMediator _mediator;
   
    public RecurringEventController(IMediator mediator)
    {
        _mediator = mediator;       
    }

    [Authorize]
    [Route("PersonWasCreated/{Name}/{DataBirth}")]
    [HttpPost]
    public Task AddBirthDay(string Name, DateTime DataBirth)
    {
        BirthDay birthDay = new BirthDay(0,Name, DataBirth);
        var birthDayEvent = new PersonWasCreated(birthDay);
        return _mediator.Send(birthDayEvent);
    }



    [Route("NameDayWasCreated")]
    [HttpPost]
    public Task AddNameDay(string personName, int idSaint)
    {
        NameDay nameDay  = new NameDay(0, personName, idSaint);
        var nameDayEvent = new NameDayWasCreated(nameDay);
        return _mediator.Send(nameDayEvent);
    } 

   
    
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
