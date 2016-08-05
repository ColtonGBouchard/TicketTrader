using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class DisplaySelectedListingViewModel
    {
        public DisplaySelectedListingViewModel()
        {
        }

        public DisplaySelectedListingViewModel(Listing listing)
        {
            this.Listing = listing;
            
            if (listing != null)
            {
                this.Event = listing.Event;
            }
        }

        public int ListingId { get; set; }
        public int EventId { get; set; }

        public string BandName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventVenue { get; set; }


        public Listing Listing { get; set; }
        public Event Event { get; set; }
    }
}