using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Infrastructure.Repository;

namespace RecurringEvents.Infrastructure;

public static class DependencyInjection
{
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, string dbConnString)
    {
        
        service.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString: dbConnString, 
            new MySqlServerVersion(new Version(10, 4, 17))));
        
        
      //  service.AddScoped<IRepository<NameDay>, NameDayRepository>();
        service.AddScoped<IRepository<Saint>, RepositoryDbService<Saint>>();
        return service;
    }
}
