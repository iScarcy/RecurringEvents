using MediatR;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using System.Linq;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class SistemWasStartedCreatedHanler : IRequestHandler<SistemWasStarted, List<RecurringEvent>>
{
   
    private readonly IEventPeopleService<BirthDay> _peopleService;
    private readonly IEventPeopleService<NameDay> _nameDayService;
    private readonly IRecurringEventService _eventService;
    
    public SistemWasStartedCreatedHanler(IEventPeopleService<BirthDay> peopleService, IEventPeopleService<NameDay> nameDaysService, IRecurringEventService eventService)
    {
        _peopleService  = peopleService;
        _nameDayService = nameDaysService;
        _eventService   = eventService;
    }
   

    public async Task<List<RecurringEvent>> Handle(SistemWasStarted request, CancellationToken cancellationToken)
    {
        var birthdays = await _peopleService.GetEventsByDays(request.DateRange);
                
        var namedays = await _nameDayService.GetEventsByDays(request.DateRange);

        var events = await _eventService.GetEventsByDays(request.DateRange);

        return (birthdays.Union(namedays).Union(events)).ToList().OrderBy(x => x.date).ToList<RecurringEvent>();
        
    }
}
