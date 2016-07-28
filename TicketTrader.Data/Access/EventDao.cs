using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrader.Models;

namespace TicketTrader.Data.Access
{
    public class EventDao
    {
        private readonly TicketTraderContext context;

        public EventDao(TicketTraderContext context)
        {
            this.context = context;
        }

        public List<Event> GetAll()
        {
            return context.Events.ToList();
        }

        public Event GetById(int id)
        {
            return context.Events.Find(id);
        }

        public void Delete(Event selectedEvent)
        {
            context.Events.Remove(selectedEvent);
            context.SaveChanges();
        }

        public void Add(Event newEvent)
        {
            context.Events.Add(newEvent);
            context.SaveChanges();
        }

        public void Edit(Event selectedEvent)
        {
            context.Entry(selectedEvent).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Event> GetEventsByBand(int id) 
        {
            var events = (from e in context.Events
                          where e.Band.BandId == id
                          orderby e.Date
                          select e).ToList();

            return events;
        }
    }
}
