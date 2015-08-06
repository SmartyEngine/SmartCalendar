using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SmartCalendar.Models.EFRepositories
{
    public class EventRepository
    {
        private ApplicationDbContext context;

        public EventRepository()
            : this(ApplicationDbContext.Create())
        { }

        public EventRepository(ApplicationDbContext appContext)
        {
            context = appContext;
        }

        public IQueryable<Event> List
        {
            get { return context.Events; }
        }

        public async Task<IdentityResult> Update(Event item)
        {
            IdentityResult result;

            Event dbEntry = await context.Events.FindAsync(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Title = item.Title;
                dbEntry.Description = item.Description;
                dbEntry.Category = item.Category;
                dbEntry.DateAdd = item.DateAdd;
                dbEntry.DateStart = item.DateStart;
                dbEntry.DateEnd = item.DateEnd;
                dbEntry.Location = item.Location;
            }
            else
            {
                result = IdentityResult.Failed("Object not found.");
                return result;
            }
            result = await SaveChangesAsync();
            return result;
        }
        private async Task<IdentityResult> SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                return IdentityResult.Failed(e.Message);
            }
        }
    }
}