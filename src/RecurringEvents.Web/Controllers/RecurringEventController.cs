using Microsoft.AspNetCore.Mvc;

using MediatR;
using models = RecurringEvents.Web.Models;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using Microsoft.AspNetCore.Authorization;
using RecurringEvents.Web.Models;
using RecurringEvents.Application.Interface.Service;

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
    /// Evento invocato quando il sistema si avvia per estrarre gli eventi del giorno
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("EventWasCreated")]
    public Task EventWasCreated(EventRequest request)
    {        
        
        EventWasCreated eventWasCreated = new EventWasCreated(request.EventTypeDescription,  request.DateEvent, request.Description);
        return _mediator.Send(eventWasCreated);
    }

    [HttpPatch("EventWasUpdated")]
    public Task EventWasUpdated(EventRequest request)
    {        
        
        EventWasUpdated eventWasUpdated = new EventWasUpdated(request.EventID, request.EventTypeDescription, request.DateEvent, request.Description);
        return _mediator.Send(eventWasUpdated);
    }
}
