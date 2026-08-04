using MediatR;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Infrastructure.DomainEvents;

public class EventWasUpdatedHandler : IRequestHandler<EventWasUpdated>
{
    private readonly ApplicationDbContext _dbContext;

    public EventWasUpdatedHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // async Task IRequestHandler<EventWasCreated>.Handle(EventWasCreated request, CancellationToken cancellationToken)
    async Task IRequestHandler<EventWasUpdated>.Handle(EventWasUpdated request, CancellationToken cancellationToken)
    {
         if(request == null ) 
                 throw new Exception("EventWasCreated request is null");

            EventTypes eventTypes = _dbContext.EventTypes.Where(x => x.EventType == request.EventType).FirstOrDefault();
            if(eventTypes == null)
            {
                throw new Exception("EventType not found");
            }
            
            Event envt = _dbContext.Events.Where(x => x.EventID == request.EventID).FirstOrDefault();
            if(envt == null)
            {
                throw new Exception("Event not found");
            }
            envt.EventType = eventTypes.ID;
            envt.DateEvent = request.DateEvent;
            envt.Description = request.Description;
            _dbContext.Events.Update(envt);
            await _dbContext.SaveChangesAsync();

        
    }
 
}
