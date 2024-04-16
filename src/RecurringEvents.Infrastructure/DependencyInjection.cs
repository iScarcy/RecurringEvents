using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.DomainEvents;
using RecurringEvents.Application.Interface.DomainEvents;
using RecurringEvents.Application.Interface.Repository;

using RecurringEvents.Infrastructure.Repository;

namespace RecurringEvents.Infrastructure;

public static class DependencyInjection
{
    private static string DefaultConnection = "server=localhost;port=3306;uid=root;pwd=myPassword1215.admin;database=RecurringEvents";
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, string dbConnString)
    {
        
        service.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString: dbConnString, 
            new MySqlServerVersion(new Version(10, 4, 17))));
        
        
        service.AddScoped<INameDayRepository, NameDayRepository>();
        service.AddScoped<ISaintRepository, SaintRepository>();
        return service;
    }
}
