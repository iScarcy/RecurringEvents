using Microsoft.AspNetCore.Mvc;

using MediatR;
using RecurringEvents.Domain.Events;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecurringEventController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISaintRepository _saintRepository ;
  
    public RecurringEventController(IMediator mediator, ISaintRepository saintRepository)
    {
        _mediator = mediator;
        _saintRepository = saintRepository;
    }

    [Route("PersonWasCreated")]
    [HttpPost]
    public Task AddBirthDay(string Name, DateTime DataBirth)
    {
        BirthDay birthDay = new BirthDay(0,Name, DataBirth);
        var birthDayEvent = new PersonWasCreated(birthDay);
        return _mediator.Send(birthDayEvent);
    }

    [Route("AddSaint")]
    [HttpPost]
    public IActionResult AddSaint(string Description, DateTime Data)
    {
        try
        {
            Saint ss = new Saint(0, Description, Data);
            _saintRepository.Insert(ss);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    /*
    [HttpPost]
public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
{
    _context.TodoItems.Add(todoItem);
    await _context.SaveChangesAsync();

    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
}
    */
}
