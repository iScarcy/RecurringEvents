using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Application.Service;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IEventPeopleService<BirthDay>, BirthDayService>();
        service.AddScoped<IEventPeopleService<NameDay>, NameDayService>();
        service.AddScoped<IRecurringEventService, EventService>();
        service.AddScoped<IExecutionsService, ExecutionsService>();           
        return service;      
    }

}
