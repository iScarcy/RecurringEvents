using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Application.Interface.Repository;

public interface ISaintRepository : IRepository<Saint, Guid>
{
    IEnumerable<Saint> GetBySaintName(string SaintName);
}
