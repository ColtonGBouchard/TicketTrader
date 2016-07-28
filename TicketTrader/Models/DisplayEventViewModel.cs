using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class DisplayEventViewModel
    {
        public int BandId { get; set; }
        public List<int> EventIds { get; set; }
        //public string BandName { get; set; }
        //public DateTime Date { get; set; }
        //public string Venue { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }

        public Band Band { get; set; }
        public List<Event> Events { get; set; }
        
    }
}