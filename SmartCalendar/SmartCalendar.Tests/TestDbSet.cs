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
        private ObservableCollection<Event> _data;

        public TestProductDbSet()
        {
            _data = new ObservableCollection<Event>();
        }

        public override Event Add(Event entity)
        {
            _data.Add(entity);
            return entity;
        }

        public override Event Remove(Event item)
        {
            _data.Remove(item);
            return item;
        }

        public override Event Find(params object[] keyValues)
        {
            return _data.FirstOrDefault(x => x.Id == (string)keyValues.Single());
        }

        public override async Task<Event> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return _data.FirstOrDefault(x => x.Id == (string)keyValues.Single());
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

