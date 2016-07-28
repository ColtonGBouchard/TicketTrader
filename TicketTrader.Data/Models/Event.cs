using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int BandId { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual Band Band { get; set; }
    }
}