using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int EventId { get; set; }

        public string UserId { get; set; }

        public int ListingTypeId { get; set; }

        [Range(1,99)]
        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public bool IsActive { get; set; }

        public virtual Event Event { get; set; }

        public virtual ListingType ListingType { get; set; }

    }
}