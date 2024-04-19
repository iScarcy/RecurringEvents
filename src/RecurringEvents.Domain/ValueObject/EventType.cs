using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurringEvents.Domain.ValueObject
{
    public enum EventType 
    {
        [Display(Name = "Compleanno")]
        BirthDay,
        [Display(Name = "Onomastico")]
        NameDay,
        [Display(Name = "Anniversario")]
        Anniversary,
        [Display(Name = "Promemoria")]
        Reminder
    }
}
