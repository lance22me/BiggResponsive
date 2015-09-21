using Ninject.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiggResponsive.Controllers
{
    public class HomeController : Controller
    {
        private ILogger logger;

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.logger.Error("Testing from the Home Controller in BiggResponsive");
            return View();
        }

        // This method of routing to partial views is, I think, a pain to maintain and creates an unnecessary step ...

        [HttpGet]
        public ActionResult Home()
        {
            return PartialView("_Home");
        }

        [HttpGet]
        public ActionResult ColumnStacking()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DegradePhoto()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FontDegredation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Links()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult VisibleHidden()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TheWorks()
        {
            return View();
        }

    }
}
