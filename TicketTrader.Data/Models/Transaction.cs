using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ListingId { get; set; }
        public string SellerId { get; set; }
        public string BuyerId { get; set; }
    }
}