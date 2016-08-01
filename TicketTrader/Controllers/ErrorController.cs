using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketTrader.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [HandleError]
        public ActionResult NotFound()
        {
            return View();
        }
	}
}