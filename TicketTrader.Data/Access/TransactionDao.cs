using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrader.Models;

namespace TicketTrader.Data.Access
{
    public class TransactionDao
    {
        private readonly TicketTraderContext context;

        public TransactionDao(TicketTraderContext context)
        {
            this.context = context;
        }

        public void SubmitPurchase(string sellerId, string buyerId, int listingId)
        {
            var transaction = new Transaction();
            transaction.BuyerId = buyerId;
            transaction.SellerId = sellerId;
            transaction.ListingId = listingId;
            context.Transactions.Add(transaction);

            var listing = context.Listings.Find(listingId);
            listing.IsActive = false;
            context.Entry(listing).State = EntityState.Modified;
            context.SaveChanges();
        }

        
    }
}
