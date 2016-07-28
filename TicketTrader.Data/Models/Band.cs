using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketTrader.Models
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }

        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}