using System;
using System.Web;
using System.Web.Mvc;

namespace BiggResponsive.Controllers
{
    public class ModalsController : Controller
    {

        /// <summary>
        /// Form for adding a person
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddEditPerson()
        {
            return PartialView("_AddEditPerson");
        }

        /// <summary>
        /// Form for adding a person
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeletePerson()
        {
            return PartialView("_DeletePerson");
        }
    }
}