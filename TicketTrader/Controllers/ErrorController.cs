using System.Web.Mvc;

namespace TicketTrader.Controllers
{
    public class ErrorController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [HandleError]
        public ActionResult NotFound()
        {
            logger.Error("404 Error");   
            return View();
        }

        [HttpGet]
        [HandleError]
        public ActionResult Forbidden()
        {
            logger.Error("403 Error");
            return View();
        }

        [HttpGet]
        [HandleError]
        public ActionResult Internal()
        {
            logger.Error("500 Error");
            return View();
        }
	}
}