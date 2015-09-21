using System.Web.Mvc;
using Newtonsoft.Json;
using BiggResponsive.Domain.Interfaces;
namespace BiggResponsive.Controllers
{
    public class DemosController : Controller
    {
        private readonly IMemberService memberService;

        public DemosController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        public ActionResult EndlessScrolling()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EndlessScrollingWithAjax()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ScrollToTop()
        {
            return View();
        }

    }
}
