using RecurringEvents.Domain.Entities;

namespace RecurringEvents.Application.Interface.Repository;

public interface ISaintRepository  
{
    IEnumerable<Saint> GetBySaintName(string SaintName);
}
