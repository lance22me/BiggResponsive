using System.Web.Mvc;

namespace BiggResponsive.Controllers
{
    public class ShoppingController : Controller
    {

        public ActionResult Products()
        {
            return View("_Products");
        }

        public ActionResult Cart()
        {
            return View("_Cart");
        }

    }
}