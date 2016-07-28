using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class ListingType
    {
        [Key]
        public int ListingTypeId { get; set; }

        
        public string Type { get; set; }
    }
}