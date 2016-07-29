using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketTrader.Models;
using TicketTrader.Data.Access;
using Microsoft.AspNet.Identity;
namespace TicketTrader.Controllers
{
    public class TransactionController : Controller
    {
        private TicketTraderContext db = new TicketTraderContext();

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var listingDao = new ListingDao(db);

            var selectedListing = listingDao.GetListById(id);

            var model = new TransactionViewModel(selectedListing);

            var totalPrice = model.Listings.First().Quantity * model.Listings.First().Price;
            model.Listings.First().Price = totalPrice;

            return View(model);
        }

        //[HttpGet]
        //public ActionResult SubmitPurchase()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Purchase(TransactionViewModel viewModel)
        {
            var buyer = User.Identity.GetUserId();
            var seller = viewModel.SellerId;
            var listing = viewModel.ListingId;

            var transactionDao = new TransactionDao(db);
            transactionDao.SubmitPurchase(seller, buyer, listing);

            return RedirectToAction("Index", "Band");
        }
	}
}