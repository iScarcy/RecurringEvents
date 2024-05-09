using RecurringEvents.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Domain.Entities
{
    [Table("ExecutionsDetails")]
    public class ExecutionsDetail
    {
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public DateTime DateEvent { get; set; }

        public string? Description { get; set; }

        public int ExecutionsId { get; set; }
    }
}
