using System;
using System.Data.Entity;

namespace EventsApp.Models
{
    public class EventAppContext : DbContext
    {
        public EventAppContext() : base("name=EventsAppDB")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<EventsApp.Models.Event> Events { get; set; }

    }
}