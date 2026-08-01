using Microsoft.EntityFrameworkCore;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecurringEvents.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecurringEvent>()
            .HasKey(e => new { e.EventID, e.EventType });
    }

    public DbSet<Saint> Saints{get; set;}

    
    public DbSet<Person> People { get; set;}
 

    public DbSet<NameDay> NameDay{get; set;}

    public DbSet<Event> Events { get; set; }

    public DbSet<RecurringEvent> RecurringEvents { get; set; }
}
