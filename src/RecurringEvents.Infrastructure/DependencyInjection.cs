using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Events;
using RecurringEvents.Domain.ValueObject;
using RecurringEvents.Infrastructure.Repository;
using RecurringEvents.Infrastructure.Service;
namespace RecurringEvents.Infrastructure;

public static class DependencyInjection
{
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, string dbConnString)
    {
        
        service.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString: dbConnString, 
            new MySqlServerVersion(new Version(10, 4, 17))));
        
        
        service.AddScoped<IRepository<Saint>, RepositoryDbService<Saint>>();
     
     
        service.AddScoped<IEventPeopleRepository<BirthDayDate>, BirthDayService>();
        service.AddScoped<IEventPeopleRepository<NameDayDate>, NameDayService>();
        service.AddScoped<IExecutionsRepository, ExecutionsRepositoryService>();
        
        return service;
    }
}
