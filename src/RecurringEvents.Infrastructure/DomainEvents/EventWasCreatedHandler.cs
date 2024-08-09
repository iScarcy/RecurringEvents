using MediatR;
using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Infrastructure.DomainEvents
{
    public class EventWasCreatedHandler : IRequestHandler<EventWasCreated>
    {
        private readonly ApplicationDbContext _dbContext;
        public EventWasCreatedHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task IRequestHandler<EventWasCreated>.Handle(EventWasCreated request, CancellationToken cancellationToken)
        {


            if(request == null ) 
                 throw new Exception("EventWasCreated request is null");

            Event envt = new Event(request.eventType, request.dateEvent, request.description);
           
            
            await _dbContext.Events.AddAsync(envt);
            await _dbContext.SaveChangesAsync();
            
            
        }
    }
}
