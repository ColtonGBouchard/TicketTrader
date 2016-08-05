using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketTrader.Models
{
    public class DisplayListingsViewModel
    {
        public DisplayListingsViewModel()
        {
        }

        public DisplayListingsViewModel(List<Listing> listings)
        {
            this.Listings = listings;
            var firstListing = listings.FirstOrDefault();
            if (firstListing != null)
            {
                this.Event = firstListing.Event;
            }
        }

        public List<int> ListingIds { get; set; }
        public int EventId { get; set; }

        public string BandName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventVenue { get; set; }


        public List<Listing> Listings { get; set; }
        public Event Event { get; set; }
    }
}