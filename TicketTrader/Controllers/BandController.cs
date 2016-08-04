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
    public class BandController : Controller
    {
        private TicketTraderContext db = new TicketTraderContext();

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string searchTerm)
        {
            var bandDao = new BandDao(db);

            logger.Debug("Entered Band Index");
            return View(bandDao.GetAll(searchTerm));
        }

       
        [HttpGet]
        public ActionResult Create()
        { 
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Band band)
        {
            if (ModelState.IsValid)
            {
                var bandDao = new BandDao(db);
                bandDao.Add(band);
                logger.Debug("Created band--" + band.Name);
                return RedirectToAction("Index");
            }

            return View(band);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bandDao = new BandDao(db);
            Band band = bandDao.GetById(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Band band)
        {
            if (ModelState.IsValid)
            {
                var bandDao = new BandDao(db);
                bandDao.Edit(band);
                logger.Debug("Edited Band--" + band.Name);
                return RedirectToAction("Index");
            }
            return View(band);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bandDao = new BandDao(db);
            Band band = bandDao.GetById(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bandDao = new BandDao(db);
            var band = bandDao.GetById(id);
            bandDao.Delete(band);
            logger.Debug("Deleted band--" + band.Name);
            return RedirectToAction("Index");
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
