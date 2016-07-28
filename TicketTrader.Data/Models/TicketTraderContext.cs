using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class TicketTraderContext : DbContext
    {
        public TicketTraderContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingType> ListingTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}