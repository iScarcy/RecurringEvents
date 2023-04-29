using Microsoft.AspNetCore.Mvc;

using MediatR;
using RecurringEvents.Domain.Events;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;

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

    [Route("PersonWasCreated")]
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


}
