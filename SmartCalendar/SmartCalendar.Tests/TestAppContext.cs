using SmartCalendar.Models;
using SmartCalendar.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalendar.Tests
{
    class TestAppContext : IStoreAppContext
    {
        public TestAppContext()
        {
            this.Events = new TestProductDbSet();
        }

        public DbSet<Event> Events { get; set; }
        public void Dispose() { }


        public async Task<int> SaveChangesAsync()
        {
            return 0;
        }
    }
}
