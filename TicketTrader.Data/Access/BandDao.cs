using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrader.Models;

namespace TicketTrader.Data.Access
{
    public class BandDao
    {
        private readonly TicketTraderContext context;

        public BandDao(TicketTraderContext context)
        {
            this.context = context;
        }

        public List<Band> GetAll(string searchTerm)
        {
            return context.Bands.OrderBy(b=>b.Name).Where(b => searchTerm == null || b.Name.Contains(searchTerm)).ToList();
        }

        public Band GetById(int id)
        {
            return context.Bands.Find(id);
        }

        public void Delete(Band band)
        {
            context.Bands.Remove(band);
            context.SaveChanges();
        }

        public void Add(Band band)
        {
            context.Bands.Add(band);
            context.SaveChanges();
        }

        public void Edit(Band band)
        {
            context.Entry(band).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
