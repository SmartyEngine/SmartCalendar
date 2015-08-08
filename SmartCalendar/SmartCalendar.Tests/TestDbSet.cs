using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalendar.Tests
{    
    class TestProductDbSet : DbSet<Event>
    {
        public override Event Find(params object[] keyValues)
        {
            return GetDemoEvent();
        }

        public override async Task<Event> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return GetDemoEvent();
        }

        Event GetDemoEvent()
        {
            return new Event()
            {
                Id = "1",
                Title = "test",
                Description = "test",
                Location = "test",
                Category = Category.Fun,
                DateAdd = DateTime.Now,
                DateEnd = DateTime.Now,
                DateStart = DateTime.Now
            };
        }
    }
}

