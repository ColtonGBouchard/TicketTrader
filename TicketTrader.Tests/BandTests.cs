using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrader.Controllers;
using TicketTrader.Models;
using Xunit;
using System.Web.Mvc;

namespace TicketTrader.Tests
{
    public class BandTests
    {
        [Fact]
        public void ShouldBeEqual()
        {
            int four = 2 + 2;
            Assert.Equal(4, four);
        }
 
        [Fact]
        public void ShouldNotBeEqual()
        {
            int four = 2 + 2;
            Assert.NotEqual(four, 3);
        }

    }
}
