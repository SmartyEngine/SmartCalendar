using SmartCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartCalendar.Helpers
{
    public class AppDbInit : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var testEvent = new Event()
            {
                Id = "1",
                DateAdd = DateTime.Now,
                DateEnd = DateTime.Now,
                DateStart = DateTime.Now,
                Category = Category.Fun,
                Description = "test",
                Location = "test",
                Title = "test"
            };
            context.Events.Add(testEvent);
            base.Seed(context);
        }
        public AppDbInit() { this.Seed(ApplicationDbContext.Create()); }

    }
}