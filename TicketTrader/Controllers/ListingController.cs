using System.Web.Mvc;
using TicketTrader.Models;
using Microsoft.AspNet.Identity;
using TicketTrader.Data.Access;


namespace TicketTrader.Controllers
{
    [Authorize]
    public class ListingController : Controller
    {
        private TicketTraderContext db = new TicketTraderContext();
        
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Create(int eventId)
        {
            logger.Debug("Entered Listing Create");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Listing listing)
        {
            listing.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var listingDao = new ListingDao(db);
                listingDao.Add(listing);
                logger.Debug("Created listing--" + listing.ListingId);
                return RedirectToAction("ViewListingsByEvent", "Listing", new { id = listing.EventId });
            }

            return View(listing);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var listingDao = new ListingDao(db);
            var listing = listingDao.GetById(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            logger.Debug("Entered Listing Edit");
            return View(listing);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Listing listing)
        {
            if (ModelState.IsValid)
            {
                var listingDao = new ListingDao(db);
                listingDao.Edit(listing);
                logger.Debug("Edited listing--" + listing.ListingId);
                return RedirectToAction("ViewListingsByEvent", "Listing", new { id = listing.EventId });
            }
            return View(listing);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var listingDao = new ListingDao(db);
            var listing = listingDao.GetById(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            logger.Debug("Entered Listing Delete");
            return View(listing);
        }


 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var listingDao = new ListingDao(db);
            var listing = listingDao.GetById(id);
            listingDao.Delete(listing);
            logger.Debug("Deleted listing--" + listing.ListingId);
            return RedirectToAction("ViewListingsByEvent", "Listing", new { id = listing.EventId });
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewListingsByEvent(int id)
        {
            
            var listingDao = new ListingDao(db);
            var listingsForEvent = listingDao.GetListingsForEvent(id);

            var model = new DisplayListingsViewModel(listingsForEvent);

            if (model.Event == null)
            {
                var eventDao = new EventDao(db);
                var selectedEvent = eventDao.GetById(id);
                model.Event = selectedEvent;
            }

            logger.Debug("Entered ViewListingsByEvent--" + id);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewSelected(int id)
        {
            var listingDao = new ListingDao(db);

            var selectedListing = listingDao.GetListById(id);
            
            var model = new DisplayListingsViewModel(selectedListing);


            if(model.Event == null)
            {
                var eventDao = new EventDao(db);
                var selectedEvent = eventDao.GetById(id);
                model.Event = selectedEvent;
            }
            logger.Debug("Enter ViewSelected--" + id);
            return View(model);
        }

    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
