using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Application.Service;
using RecurringEvents.Domain.Events;

namespace RecurringEvents.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IEventPeopleService<BirthDay>, BithDayService>();
        return service;      
    }

}
