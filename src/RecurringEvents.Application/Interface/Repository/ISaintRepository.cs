using RecurringEvents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Application.Interface.Repository
{
    public interface ISaintRepository
    {
        Task<IEnumerable<Saint>> GetByPerson();
    }
}
