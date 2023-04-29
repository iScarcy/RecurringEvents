using Microsoft.EntityFrameworkCore;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.Events;

namespace RecurringEvents.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Saint> Saints{get; set;}

    public DbSet<BirthDay> BirthDay{get; set;}

     public DbSet<NameDay> NameDay{get; set;}
}
