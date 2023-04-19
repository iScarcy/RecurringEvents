using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Application.Service;
using RecurringEvents.Infrastructure.Repository;

namespace RecurringEvents.Infrastructure;

public static class DependencyInjection
{
    private static string DefaultConnection = "server=scarcybox;port=3306;uid=root;pwd=mimi;database=RecurringEvents";
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        
        service.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString: DefaultConnection, 
            new MySqlServerVersion(new Version(10, 4, 17))));
        
        service.AddScoped<INameDayRepository, NameDayRepository>();
        service.AddScoped<ISaintRepository, SaintRepository>();
        return service;
    }
}
