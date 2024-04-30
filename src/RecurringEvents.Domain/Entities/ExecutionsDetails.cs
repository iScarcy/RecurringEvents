using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Domain.Entities
{
    public class ExecutionsDetails
    {
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public DateTime DateEvent { get; set; }

        public string? Description { get; set; }

        public int ExecutionsId { get; set; }
    }
}
