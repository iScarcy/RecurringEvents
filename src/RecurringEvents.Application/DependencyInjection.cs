using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Application.Service;

namespace RecurringEvents.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
      //  service.AddScoped<IRecurringEventService, NameDayService>();
        return service;
      
    }
}
