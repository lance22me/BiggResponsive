using System.Web.Mvc;

namespace BiggResponsive.Controllers
{
    public class LoDashController : Controller
    {
        public ActionResult AllMeetingCriteria()
        {
            return View("_AllMeetingCriteria");
        }

        public ActionResult IsInCollection()
        {
            return View("_IsInCollection");
        }

        public ActionResult FilterWhileUType()
        {
            return View("_FilterWhileUType");
        }

        public ActionResult FirstOrDefault()
        {
            return View("_FirstOrDefault");
        }

        public ActionResult SingleProperty()
        {
            return View("_SingleProperty");
        }

        public ActionResult RemoveFromCollection()
        {
            return View("_RemoveFromCollection");
        }
	}
}