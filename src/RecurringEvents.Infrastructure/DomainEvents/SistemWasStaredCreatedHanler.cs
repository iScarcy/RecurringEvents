using MediatR;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
namespace RecurringEvents.Infrastructure.DomainEvents;

public class SistemWasStartedCreatedHanler : IRequestHandler<SistemWasStarted, List<Event>>
{
   
    private readonly IEventPeopleService<BirthDay> _peopleService;
    private readonly IEventPeopleService<NameDay> _nameDayService;
    
    public SistemWasStartedCreatedHanler(IEventPeopleService<BirthDay> peopleService, IEventPeopleService<NameDay> nameDaysService)
    {
        _peopleService  = peopleService;
        _nameDayService = nameDaysService;
    }
   

    public async Task<List<Event>> Handle(SistemWasStarted request, CancellationToken cancellationToken)
    {
        var birthdays = await _peopleService.GetEventsByDays(request.DateRange);
                
        var namedays = await _nameDayService.GetEventsByDays(request.DateRange);

        return birthdays.Union(namedays).ToList();
        
    }
}
