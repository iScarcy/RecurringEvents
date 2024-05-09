using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Application.Service;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IEventPeopleService<BirthDayDate>, BithDayService>();
        service.AddScoped<IEventPeopleService<NameDayDate>, NameDayService>();        
        service.AddScoped<IExecutionsService, ExecutionsService>();    
        return service;      
    }

}
