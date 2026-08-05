using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using RecurringEvents.Infrastructure.Repository;

namespace RecurringEvents.Infrastructure;

public static class DependencyInjection
{
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, string dbConnString)
    {
        
        service.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString: dbConnString, 
            new MySqlServerVersion(new Version(10, 4, 17))));
        
        
        service.AddScoped<IRepository<Person>, RepositoryDbService<Person>>();
        service.AddScoped<IRepository<EventTypes>, RepositoryDbService<EventTypes>>();
        service.AddScoped<IRepository<Event>, RepositoryDbService<Event>>();
        service.AddScoped<IRepository<RecurringEvent>, RepositoryDbService<RecurringEvent>>();
       // service.AddScoped<IEventPeopleRepository<EventPeople>, BirthDayService>();
       // service.AddScoped<IEventPeopleRepository<NameDay>, NameDayService>();
  
        
        return service;
    }
}
