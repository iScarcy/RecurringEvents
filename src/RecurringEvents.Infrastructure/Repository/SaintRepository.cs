using Microsoft.EntityFrameworkCore;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Domain.Entities;
using RecurringEvents.Domain.ValueObject;

namespace RecurringEvents.Infrastructure.Repository;

public class SaintRepository : RepositoryDbService<Saint> 
{
    private readonly ApplicationDbContext _dbContext;

    public SaintRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<NameDay>> GetByPerson(string person)
    {
        //var saint = async _dbContext.Saints.Include<NameDay>().Where(x => x.)
        return await  _dbContext.NameDay.Where(x => x.PersonName == person).ToListAsync();
    }
}
