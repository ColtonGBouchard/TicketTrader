using System.Web.Mvc;
using TicketTrader.Models;
using TicketTrader.Data.Access;


namespace TicketTrader.Controllers
{

    [Authorize(Roles="Admin")]
    public class EventController : Controller
    {
        private TicketTraderContext db = new TicketTraderContext();

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string searchTerm)
        {
            var eventDao = new EventDao(db);
            logger.Debug("Entered Event Index");
            return View(eventDao.GetAll(searchTerm));
        }

 
        [HttpGet]
        public ActionResult Create(int bandId)
        {
            logger.Debug("Entered Event Create");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                var eventDao = new EventDao(db);
                eventDao.Add(newEvent);
                logger.Debug("Created event--" + newEvent.EventId);
                return RedirectToAction("Upcoming", new { id = newEvent.BandId });
            }

            return View(newEvent);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventDao = new EventDao(db);
            Event selectedEvent = eventDao.GetById(id);
            if (selectedEvent == null)
            {
                return HttpNotFound();
            }
            logger.Debug("Entered Event Edit");
            return View(selectedEvent);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event selectedEvent)
        {
            if (ModelState.IsValid)
            {
                var eventDao = new EventDao(db);
                eventDao.Edit(selectedEvent);
                logger.Debug("Edited event--" + selectedEvent.EventId);
                return RedirectToAction("Upcoming", "Event", new { id = selectedEvent.BandId });
            }
            return View(selectedEvent);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var eventDao = new EventDao(db);
            Event selectedEvent = eventDao.GetById(id);
            if (selectedEvent == null)
            {
                return HttpNotFound();
            }
            logger.Debug("Entered Event Delete");
            return View(selectedEvent);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var eventDao = new EventDao(db);
            Event selectedEvent = eventDao.GetById(id);
            eventDao.Delete(selectedEvent);
            logger.Debug("Deleted event--" + selectedEvent.EventId);
            return RedirectToAction("Upcoming", "Event", new { id = selectedEvent.BandId });
        }

        [AllowAnonymous]
        public ActionResult Upcoming(int id, string searchTerm)
        {
            DisplayEventViewModel model = new DisplayEventViewModel();

            var eventDao = new EventDao(db);
            var events = eventDao.GetEventsByBand(id, searchTerm);
            
            if (events == null)
            {
                return HttpNotFound();
            }

            model.Events = events;

            var bandDao = new BandDao(db);
            var band = bandDao.GetById(id);

            model.Band = band;

            logger.Debug("Entered Event Upcoming");

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
