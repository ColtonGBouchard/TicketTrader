﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrader.Models;


namespace TicketTrader.Data.Access
{
    public class ListingDao
    {
        private readonly TicketTraderContext context;

        public ListingDao(TicketTraderContext context)
        {
            this.context = context;
        }

        public List<Listing> GetAll()
        {
            var listings = context.Listings.Where(l => l.IsActive == true).ToList();
            return listings;
        }

        public Listing GetById(int id)
        {
            return context.Listings.Where(l => l.IsActive==true && l.ListingId == id).First();
        }

        public List<Listing> GetListById(int id)
        {
            var selectedListing = (from l in context.Listings
                                   where l.ListingId == id && l.IsActive == true
                                   select l).ToList();

            return selectedListing;
        }

        public void Delete(Listing listing)
        {
            context.Listings.Remove(listing);
            context.SaveChanges();
        }

        public void Add(Listing listing)
        {
            listing.IsActive = true;
            context.Listings.Add(listing);
            context.SaveChanges();
        }

        public void Edit(Listing listing) 
        {
            context.Entry(listing).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Listing> GetListingsForEvent(int id)
        {
            var listingsForEvent = (from l in context.Listings
                                    where l.EventId == id && l.IsActive == true
                                    select l).ToList();

            return listingsForEvent;
        }
    }
}
