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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var bandDao = new BandDao(db);
            return View(bandDao.GetAll());
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
