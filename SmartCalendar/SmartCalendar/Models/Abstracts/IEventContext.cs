using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartCalendar.Models.Abstracts
{
    public class IEventContext
    {
        DbSet<Event> Events { get; set; }
    }
}