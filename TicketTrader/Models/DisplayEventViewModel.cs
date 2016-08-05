using System.Collections.Generic;

namespace TicketTrader.Models
{
    public class DisplayEventViewModel
    {
        public int BandId { get; set; }
        public List<int> EventIds { get; set; }
      
        public Band Band { get; set; }
        public List<Event> Events { get; set; }
        
    }
}