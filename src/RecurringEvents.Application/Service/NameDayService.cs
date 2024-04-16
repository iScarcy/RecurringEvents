namespace RecurringEvents.Application.Service;

using System.Collections.Generic;
using RecurringEvents.Application.Interface.Repository;
using RecurringEvents.Application.Interface.Service;
using RecurringEvents.Domain.ValueObject;

public class NameDayService : IRecurringEventService
{
    private readonly INameDayRepository _nameDayRepository;

    public NameDayService(INameDayRepository nameDayRepository)
    {
        _nameDayRepository = _nameDayRepository;
    }

    IEnumerable<Event> IRecurringEventService.GetEvents(DateRange date)
    {
        throw new NotImplementedException();
    }
}
