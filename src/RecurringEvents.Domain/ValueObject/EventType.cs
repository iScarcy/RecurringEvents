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
        BirthDay = 0,
        [Display(Name = "Onomastico")]
        NameDay = 1,
        [Display(Name = "Anniversario")]
        Anniversary = 2,
        [Display(Name = "Promemoria")]
        Reminder = 3
    }
}
