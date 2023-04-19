namespace RecurringEvents.Application.Service;

using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
public class SaintService : ISaintService
{
    private readonly ISaintRepository _saintRepository;

    public SaintService(ISaintRepository saintRepository)
    {
        _saintRepository = saintRepository;
    }

}
