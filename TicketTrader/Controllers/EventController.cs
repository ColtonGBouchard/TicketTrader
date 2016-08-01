using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketTrader.Models;
using TicketTrader.Data.Access;


namespace TicketTrader.Controllers
{
    [Authorize(Roles="Admin")]
    public class EventController : Controller
    {
        private TicketTraderContext db = new TicketTraderContext();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var eventDao = new EventDao(db);
            return View(eventDao.GetAll());
        }

 
        [HttpGet]
        public ActionResult Create(int bandId)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                var eventDao = new EventDao(db);
                eventDao.Add(@event);
                return RedirectToAction("Upcoming", new { id = @event.BandId });
            }

            return View(@event);
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
                return RedirectToAction("Index");
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
            return View(selectedEvent);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var eventDao = new EventDao(db);
            Event selectedEvent = eventDao.GetById(id);
            eventDao.Delete(selectedEvent);
            return RedirectToAction("Index", "Band");
        }

        [AllowAnonymous]
        public ActionResult Upcoming(int id)
        {
            DisplayEventViewModel model = new DisplayEventViewModel();

            var eventDao = new EventDao(db);
            var events = eventDao.GetEventsByBand(id);
            
            if (events == null)
            {
                return HttpNotFound();
            }

            model.Events = events;

            var bandDao = new BandDao(db);
            var band = bandDao.GetById(id);

            model.Band = band;           

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
